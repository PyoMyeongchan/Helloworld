using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_client_image
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fsInput = new FileStream("1.webp", FileMode.Open);
            FileStream fsOutput = new FileStream("1_copy.webp", FileMode.CreateNew);

            byte[] buffer = new byte[4096];

            int ReadSize = 0;
            do
            {
                ReadSize = fsInput.Read(buffer, 0, buffer.Length);
                fsOutput.Write(buffer, 0, ReadSize);

            }
            while (ReadSize > 0);



            fsInput.Close();
            fsOutput.Close();
        }
    }
}
