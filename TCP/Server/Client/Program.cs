using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {   // 숫자형을 byte에 넣어보고, byte를 숫자 자료형으로 넣어보기 작업
        // [][]

        static Socket clientSocket;

        static void Main(string[] args)
        {

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);

            clientSocket.Connect(serverEndPoint);
            
            JObject result = new JObject();
            
            result.Add("code", "Login");
            result.Add("user_id", "명찬");
            result.Add("user_password", "1234");
            sendPacket(clientSocket, result.ToString());
            
            /*
            result.Add("code", "SignUp");
            result.Add("user_id", "표명찬123");
            result.Add("user_password", "1234");
            result.Add("user_name", "명찬");
            result.Add("user_email", "robot@a.com");
            sendPacket(clientSocket, result.ToString());
            */
            string jsonString;
            RecvPacket(clientSocket, out jsonString);

            Console.WriteLine(jsonString);

            clientSocket.Close();


        }

        static void RecvPacket(Socket toSocket, out string jsonString)
        {
            byte[] lengthBuffer = new byte[2];

            int recvLength = clientSocket.Receive(lengthBuffer, 2, SocketFlags.None);

            ushort length = BitConverter.ToUInt16(lengthBuffer, 0);

            length = (ushort)IPAddress.NetworkToHostOrder((short)length);


            byte[] recvBuffer = new byte[4096];

            recvLength = clientSocket.Receive(recvBuffer, length, SocketFlags.None);

            jsonString = Encoding.UTF8.GetString(recvBuffer);

        }


        static void sendPacket(Socket tosocket, string message)
        {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);
            // 길이  자료
            // [][]  [][][][][][][][]
            byte[] headerBuffer = BitConverter.GetBytes(length);

            // [][][][][][][][][][]
            byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];

            Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

            int SendLength = tosocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);
        }

    }
}
