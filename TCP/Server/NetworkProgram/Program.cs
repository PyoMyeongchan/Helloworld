using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MySqlConnector;

namespace Server
{
    class Message
    {
        public string message;
    }
    class Program
    {
        static Socket listenSocket;

        static List<Socket> clientSockets = new List<Socket>();

        static Object _lock = new Object();


        static void AcceptThread()
        {
            while (true)
            {
                Socket clientSocket = listenSocket.Accept();

                lock (_lock)
                {
                    clientSockets.Add(clientSocket); // 반복문에서 리스트가 변화해서 오류남 그래서 clientSockets을 만들어 리스트 따로 만들었음!
                }
                Console.WriteLine($"Connect client : {clientSocket.RemoteEndPoint}");

                Thread workThread = new Thread(new ParameterizedThreadStart(WorkThread));
                workThread.IsBackground = true;
                workThread.Start(clientSocket);
                // threadManager.Add(workThread);

            }

            
        }

        static void WorkThread(Object clientObjectSocket)
        {
            Socket clientSocket = clientObjectSocket as Socket;

            while (true)
            {
                try
                {
                    // recvbyte > 0
                    byte[] headerBuffer = new byte[2];
                    int RecvLength = clientSocket.Receive(headerBuffer, 2, SocketFlags.None);

                    if (RecvLength > 0)
                    {
                        short packetlength = BitConverter.ToInt16(headerBuffer, 0);
                        packetlength = IPAddress.NetworkToHostOrder(packetlength);

                        // [][][][]
                        // 실제 패킷 (header 길이 만큼)
                        byte[] dataBuffer = new byte[4096];
                        RecvLength = clientSocket.Receive(dataBuffer, packetlength, SocketFlags.None);
                        string JsonString = Encoding.UTF8.GetString(dataBuffer);

                        Console.WriteLine(JsonString);

                        string connectString = "server=localhost;user=root;database=membership;password=416089ey~!";
                        MySqlConnection mySqlConnector = new MySqlConnection(connectString);

                        JObject clientData = JObject.Parse(JsonString);
                        // DB연결 과정
                        string code = clientData.Value<string>("code");

                        try
                        {
                            if (code.CompareTo("Login") == 0)
                            {

                                string user_id = clientData.Value<string>("user_id");
                                string user_password = clientData.Value<string>("user_password");

                                mySqlConnector.Open();


                                // 데이터 확인하는 코드
                                MySqlCommand mySqlCommand = new MySqlCommand();
                                mySqlCommand.Connection = mySqlConnector;

                                mySqlCommand.CommandText = "select* from users where user_id = @user_id and user_password = @user_password";
                                mySqlCommand.Prepare();
                                mySqlCommand.Parameters.AddWithValue("@user_id", user_id);
                                mySqlCommand.Parameters.AddWithValue("@user_password", user_password);

                                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                                if (mySqlDataReader.Read())
                                {
                                    // 로그인 성공
                                    JObject result = new JObject();
                                    result.Add("code", "Loginresult");
                                    result.Add("message", "success");
                                    result.Add("user_name", mySqlDataReader["user_name"].ToString());
                                    result.Add("user_email", mySqlDataReader["user_email"].ToString());
                                    sendPacket(clientSocket, result.ToString());
                                }
                                else
                                {
                                    // 로그인 실패
                                    JObject result = new JObject();
                                    result.Add("code", "Loginresult");
                                    result.Add("message", "failed");
                                    sendPacket(clientSocket, result.ToString());
                                }


                            }
                            else if (code.CompareTo("SignUp") == 0)
                            {

                                string user_id = clientData.Value<string>("user_id");
                                string user_password = clientData.Value<string>("user_password");
                                string user_name = clientData.Value<string>("user_name");
                                string user_email = clientData.Value<string>("user_email");

                                mySqlConnector.Open();
                                MySqlCommand mySqlCommand1 = new MySqlCommand();
                                mySqlCommand1.Connection = mySqlConnector;

                                mySqlCommand1.CommandText = "insert into users (user_id, user_password, user_name, user_email) values ( @user_id, @user_password, @user_name, @user_email)";
                                mySqlCommand1.Prepare();
                                mySqlCommand1.Parameters.AddWithValue("@user_id", user_id);
                                mySqlCommand1.Parameters.AddWithValue("@user_password", user_password);
                                mySqlCommand1.Parameters.AddWithValue("@user_name", user_name);
                                mySqlCommand1.Parameters.AddWithValue("@user_email", user_email);
                                mySqlCommand1.ExecuteNonQuery();

                                JObject result = new JObject();
                                result.Add("code", "signupresult");
                                result.Add("message", "Success");

                                sendPacket(clientSocket, result.ToString());
                            }
 
                        }
                        catch (Exception es)
                        {
                            Console.WriteLine(es.Message);
                            JObject result = new JObject();
                            result.Add("code", "signupresult");
                            result.Add("message", "failed");
                            sendPacket(clientSocket, result.ToString());
                        }
                        finally
                        {
                            mySqlConnector.Close();
                        }

                    }
                    else
                    {
                        string message = "{ \"message\" : \" Disconnect : " + clientSocket.RemoteEndPoint + " \"}";

                        sendPacket(clientSocket, message);  

                        lock (_lock)
                        {
                            clientSockets.Remove(clientSocket);
                        }
                        clientSocket.Close();
                        return;
                    }
                }
                catch (SocketException e)
                {

                    Console.WriteLine($"Error 낸 놈 : {e.Message} {clientSocket.RemoteEndPoint}");

                    string message = "{ \"message\" : \" Disconnect : " + clientSocket.RemoteEndPoint + " \"}";

                    sendPacket(clientSocket, message);


                    lock (_lock)
                    {
                        clientSockets.Remove(clientSocket);
                    }

                    clientSocket.Close();
                    return;

                }
            }
        }

        static void sendPacket(Socket tosocket, string message)
        {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);

            byte[] headerBuffer = BitConverter.GetBytes(length);

            byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];

            Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

            int SendLength = tosocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);
        }


        static void ChatSendPacket(Socket tosocket,string msg)
        {
            while (true)
            {
                byte[] message = Encoding.UTF8.GetBytes(msg);
                ushort length = (ushort)message.Length;

                byte[] lengthBuffer = new byte[2];
                lengthBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)length));

                byte[] buffer = new byte[2 + length];

                Buffer.BlockCopy(lengthBuffer, 0, buffer, 0, 2);
                Buffer.BlockCopy(message, 0, buffer, 2, length);

                int sendLength = tosocket.Send(buffer, buffer.Length, SocketFlags.None);
            }
        }

        static void Main(string[] args)
        {

            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);

            listenSocket.Bind(listenEndPoint);


            listenSocket.Listen(10);

            Task acceptTask = new Task(AcceptThread);

            acceptTask.Start();

            acceptTask.Wait();

            listenSocket.Close();

        }

    }
}
