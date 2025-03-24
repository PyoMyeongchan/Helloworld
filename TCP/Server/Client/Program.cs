using Newtonsoft.Json;
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

        static void ChatInput()
        {
            while (true)
            {
                string inputChat;
                Console.Write("채팅 : ");
                inputChat = Console.ReadLine();

                // packet
                string jsonString = "{\"id\" : \"표명찬\",  \"message\" : \"" + inputChat + ".\"}";
                byte[] message = Encoding.UTF8.GetBytes(jsonString);
                ushort length = (ushort)message.Length;

                // 길이   자료
                // [][]   [][][][][][][][]
                byte[] lengthBuffer = new byte[2];
                lengthBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)length));

                //[][][][][][][][][][]
                byte[] buffer = new byte[2 + length];

                Buffer.BlockCopy(lengthBuffer, 0, buffer, 0, 2);
                Buffer.BlockCopy(message, 0, buffer, 2, length);

                int sendLength = clientSocket.Send(buffer, buffer.Length, SocketFlags.None);
            }
        }

        static void ReceiveMessage()
        {
            while (true)
            {
                byte[] lengthBuffer = new byte[2];

                int recvLength = clientSocket.Receive(lengthBuffer, 2, SocketFlags.None);

                ushort length = BitConverter.ToUInt16(lengthBuffer, 0);

                length = (ushort)IPAddress.NetworkToHostOrder((short)length);


                byte[] recvBuffer = new byte[4096];

                recvLength = clientSocket.Receive(recvBuffer, length, SocketFlags.None);

                string JsonString = Encoding.UTF8.GetString(recvBuffer);

                Console.WriteLine(JsonString);
                                
            }

        }


        static void Main(string[] args)
        {

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);

            clientSocket.Connect(serverEndPoint);

            Thread chatInputThread = new Thread(new ThreadStart(ChatInput));

            Thread ReceiveMessageThread = new Thread(new ThreadStart(ReceiveMessage));

            chatInputThread.IsBackground = true;
            ReceiveMessageThread.IsBackground = true;

            chatInputThread.Start();
            ReceiveMessageThread.Start();

            chatInputThread.Join();
            ReceiveMessageThread.Join();


            clientSocket.Close();


        }
    }
}
