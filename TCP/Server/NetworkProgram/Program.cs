using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // user mode, kernel mode
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Tcp = 데이터, 패킷의 보내진 순서보장, 에러없이 패킷 전달 확인, 제어 구현
            // 오류시 다시 받기


            // port = 1024 ~ 65534
            // well known port = 1 ~ 1024 일반인이 쓰지않음
            // sockaddr
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);

            listenSocket.Bind(listenEndPoint);
            
            // 상태처리 - 10명까지
            listenSocket.Listen(10);

            Socket clientSocket = listenSocket.Accept();

            // 패킷 : header + 메세지(data) 실제 패킷 + Custom패킷
            // 패킷 길이 받기(header)
            byte[] headerBuffer = new byte[2];
            int RecvLength = clientSocket.Receive(headerBuffer, 2, SocketFlags.None);
            short packetlength = BitConverter.ToInt16(headerBuffer, 0);
            packetlength = IPAddress.NetworkToHostOrder(packetlength);

            // [][][][]
            // 실제 패킷 (header 길이 만큼)
            byte[] dataBuffer = new byte[4096];
            RecvLength = clientSocket.Receive(dataBuffer, packetlength, SocketFlags.None);
            string JsonString = Encoding.UTF8.GetString(dataBuffer);

            Console.WriteLine(JsonString);

            // Custom 패킷 만들기
            // 다시 전송 메시지
            string message = "{\"message\" : \"클라이언트에서 받고 서버에서 패킷 추가.\"}";
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);
            // 길이  자료
            // [][]  [][][][][][][][]
            headerBuffer = BitConverter.GetBytes(length);

            // [][][][][][][][][][]
            byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];

            Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

            int sendLength = clientSocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);

            clientSocket.Close();


            /*
            bool isRunning = true;
            while (isRunning)
            {
                // 블록킹


                byte[] buffer = new byte[1024]; // 1kb

                // 네트워크에서 바로 받는 것이 아닌, OS에서 미리 받아온거 일정 크기 잘라오는것
                // OS 내부 버퍼에서 복사해옴, 자료의 전부를 가져오는게 아님
                int recvLength = clientSocket.Receive(buffer);
               
                string JsonString = Encoding.UTF8.GetString(buffer);

                JObject json = JObject.Parse(JsonString);

                if (json.Value<string>("message").ToString().CompareTo("안녕하세요") == 0)
                {
                    byte[] message;
                    JObject result = new JObject();
                    result.Add("message", "반가워요");
                    Encoding.UTF8.GetBytes(result.ToString());
                    message = Encoding.UTF8.GetBytes(result.ToString());

                    // OS 내부 버퍼에 복사해옴, 자료의 전부를 보내는게 아님(컴퓨터가 바쁠때)
                    int sendLength = clientSocket.Send(message);

                }
            
                clientSocket.Close();
            }
            */
            listenSocket.Close();
        }




    }
}
