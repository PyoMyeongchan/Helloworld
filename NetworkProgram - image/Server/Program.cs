using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
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

            bool isRunning = true;

            while (isRunning)
            {
                // 블록킹
                Socket clientSocket = listenSocket.Accept();

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

            listenSocket.Close();
        }




    }

}
