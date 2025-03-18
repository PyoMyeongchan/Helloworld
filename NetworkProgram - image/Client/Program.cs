using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint servetEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);

            clientSocket.Connect(servetEndPoint);

            string jsonString = "{\"message\" : \"안녕하세요\"}";
            byte[] message = Encoding.UTF8.GetBytes(jsonString);
            int sendLength = clientSocket.Send(message, 0, message.Length, SocketFlags.None);

            byte[] buffer = new byte[1024];
            int recvLength = clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            string JsonString = Encoding.UTF8.GetString(buffer);

            Console.WriteLine(JsonString);


            clientSocket.Close();


        }
    }
}
