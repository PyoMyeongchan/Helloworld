using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            clientSocket.Connect(listenEndPoint);

            FileStream fsOutput = new FileStream("1_copy.webp", FileMode.Create);
            int RecvLength = 0;
            do
            {
                byte[] buffer = new byte[1096];
                RecvLength = clientSocket.Receive(buffer);
                fsOutput.Write(buffer, 0, RecvLength);
            } while (RecvLength > 0);

            clientSocket.Close();
            fsOutput.Close();
        }
    }
}
