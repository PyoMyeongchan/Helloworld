using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            listenSocket.Bind(listenEndPoint);

            listenSocket.Listen(10);

            Socket clientSocket = listenSocket.Accept();

            FileStream fsInput = new FileStream("1.webp", FileMode.Open);

            byte[] buffer = new byte[1096];

            int ReadSize = 0;
            do
            {
                ReadSize = fsInput.Read(buffer, 0, buffer.Length);
                int SendSize = clientSocket.Send(buffer, ReadSize, SocketFlags.None);

            } while (ReadSize > 0);

            fsInput.Close();

            clientSocket.Close();
            listenSocket.Close();

        }

    }
}
