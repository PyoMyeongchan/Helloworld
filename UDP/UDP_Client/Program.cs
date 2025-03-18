using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Client
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 6000);
                        

            byte[] buffer = new byte[1024]; // UDP는 다 받아야한다.

            string message = "안녕하세요";
            buffer = Encoding.UTF8.GetBytes(message);
            int sendLegth = serverSocket.SendTo(buffer, buffer.Length, SocketFlags.None, serverEndPoint);

            byte[] buffer2 = new byte[1024];
            EndPoint remoteEndPoint = serverEndPoint;
            int recvLegth = serverSocket.ReceiveFrom(buffer2, ref remoteEndPoint);

            string message2 = Encoding.UTF8.GetString(buffer);

            Console.WriteLine(message2);

            serverSocket.Close();
            

            // 도매인으로 IP받아오기
            IPHostEntry host = Dns.GetHostEntry("login.gameserver.co.kr");
            foreach (IPAddress address in host.AddressList)
            {
                Console.WriteLine(address);
            }

        }
        
    }
}
