using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 6000);

            serverSocket.Bind(serverEndPoint);

            byte[] buffer = new byte[1024]; // UDP는 다 받아야한다.
            EndPoint clientEndPoint = (EndPoint)serverEndPoint;

            // 블락킹
            int recvLegth = serverSocket.ReceiveFrom(buffer, ref clientEndPoint);

            int sendLegth = serverSocket.SendTo(buffer, clientEndPoint);

            serverSocket.Close();

        }
    }
}
