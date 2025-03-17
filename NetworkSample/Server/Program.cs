using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

// C언어 형식으로 제작 / 형식 암기할 것!

// IOCP

namespace Server
{
    // 썼으면 반납해야한다!

    class Program
    {
        static void Main(string[] args)
        {
            // 컴퓨터 + OS와 프로그램은 소켓으로 연결시킨다.
            // 컴퓨터 + OS 에 소켓을 만드는 과정
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 랜선과 소켓을 연결하는 과정
            // IP Address  = 인터넷의 주소 -> IPv4 - 32비트 / Any(연습이니까) 나중에는 주소 삽입하기, 모든 랜카드로 다들어오기때문에 이렇게 만들지는 않는다!
            // cmb에 ipconfig 엔터 자신의 주소 알 수 있다.
            // 컴퓨터 주소를 찾았다면 어떤 프로그램인지 찾아야한다. -> 프로그램 주소 : port 포트

            IPEndPoint ListenEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);

            // 랜선과 소켓 연결, 묶다
            listenSocket.Bind(ListenEndPoint);

            // 랜선에서 얼마나 반응을 받을지, 들을지
            // 숫자 늘어나면 오래걸림
            listenSocket.Listen(10);

            // 영업 오픈시
            bool isRunning = true;
            while (isRunning) 
                {
                // 동기, 블록킹 : 들어오도록 허락 -> 손님을 맞이하기위해 소켓과 포트 새로 만들어 연결함, 이전 반응을 받은 소켓, 포트로 들어가지 않음
                Socket clientSocket = listenSocket.Accept();
                                

                // 서버는 받거나 주거나 2가지만 한다.

                // 손님에게 주문을 받는다. 
                byte[] buffer = new byte[1024];
                int RecvLength = clientSocket.Receive(buffer);


               /*
                if (RecvLength <= 0)
                { 
                    // close
                    // Error
                    isRunning = false;
                }
               */

                // 손님에게 보낸다. byte로만 보낼 수 있다.
                int sendLength = clientSocket.Send(buffer);
                /*
                if (sendLength <= 0)
                {
                    // close
                    // Error
                    isRunning = false;
                }
                */

                Console.WriteLine(Encoding.UTF8.GetString(buffer));

                // 영업 종료 : 클라이언트의 포트와 서버의 포트의 연결 끊는다.
                clientSocket.Close();
            }

            listenSocket.Close();

        }
    }
}
