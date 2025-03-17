using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);
            listenSocket.Bind(listenEndPoint);

            listenSocket.Listen(10);

            bool isRunning = true;
            while (isRunning)
            {
                //동기, 블록킹 
                Socket clientSocket = listenSocket.Accept();

                byte[] buffer = new byte[1024];
                int RecvLength = clientSocket.Receive(buffer);

                //100+200
                string message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(message);

                String[] numbers = null;
                int first = 0;
                int second = 0;
                int result = 0;

                if (message.Contains("+"))
                {
                    numbers = message.Split('+');
                    first = int.Parse(numbers[0]);
                    second = int.Parse(numbers[1]);
                    result = first + second;
                }
                else if (message.Contains("-"))
                {
                    numbers = message.Split('-');
                    first = int.Parse(numbers[0]);
                    second = int.Parse(numbers[1]);
                    result = first - second;
                }
                else if (message.Contains("*"))
                {
                    numbers = message.Split('*');
                    first = int.Parse(numbers[0]);
                    second = int.Parse(numbers[1]);
                    result = first * second;
                }
                else // "/"
                {
                    numbers = message.Split('/');
                    first = int.Parse(numbers[0]);
                    second = int.Parse(numbers[1]);
                    result = first / second;
                }

                buffer = Encoding.UTF8.GetBytes(result.ToString());
                int SendLength = clientSocket.Send(buffer);


                clientSocket.Close();
            }

            listenSocket.Close();
        }
    }
}
