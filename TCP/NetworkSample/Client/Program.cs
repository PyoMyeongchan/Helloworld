using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) // 서버에 10명 수용
            {

                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // IPAddress.Parse("127.0.0.1"), Loopback : 자기 자신  - 암기할 것
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000); // 강사님 IP Parse("192.168.0.22")
                //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 4000);
                //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("자신의 IP"), 4000);

                // 서버의 연결 한번에 다 해주는 함수 : 서버의 새로운 포트와 자신의 포트 연결, 소켓과도 연결 즉, bind까지 다 되는 것
                serverSocket.Connect(serverEndPoint);

                byte[] buffer;

                //[H][e][l][l][o][][W][o][r][l][d]                
                String message = "Hello World";


                // message를 string에서 바이트 형식으로 바꿔주세요
                buffer = Encoding.UTF8.GetBytes(message);

                // message를  string에서 바이트 형식으로 바꿔주세요
                // buffer = Encoding.UTF8.GetBytes(message);

                // OS가 buffer를 가지고있다. 소켓 네트워크는 OS가 다한다!
                // OS에서 복사하여 모아놓은 후 네트워크에 보낼 수 있을때 보낸다.

                
                // 오류로 다 못보낼 경우 대비설정, 보통 SocketFlags.None이면 충분하다!
                int sendLength = serverSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);

                // 다 못보냈다면
                while (sendLength < buffer.Length)
                {
                    serverSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
                }
                
                byte[] buffer2 = new byte[1024];

                // OS에 있는 buffer를 받아오도록 한다. / 블록킹 = 받을때까지 대기한다.
                int recvLength = serverSocket.Receive(buffer2, 0, buffer.Length, SocketFlags.None);

                Console.WriteLine(Encoding.UTF8.GetString(buffer2));

                serverSocket.Close();
            }
        }
    }
}
