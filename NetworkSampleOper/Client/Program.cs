using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            String[] oper = { "+", "-", "*", "/" };

            for (int i = 0; i < 100; ++i)
            {
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);
                //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 4000);
                serverSocket.Connect(serverEndPoint); //bind

                byte[] buffer;

                //5 
                //[][][][][][][][][]
                String messge = $"{random.Next(1, 99)}{oper[random.Next(0, 4)]}{random.Next(1, 99)}";
                buffer = Encoding.UTF8.GetBytes(messge);
                int SendLength = serverSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);

                byte[] buffer2 = new byte[1024];
                int RecvLength = serverSocket.Receive(buffer2);

                Console.WriteLine(Encoding.UTF8.GetString(buffer2));

                serverSocket.Close();
            }
        }
    }
}
