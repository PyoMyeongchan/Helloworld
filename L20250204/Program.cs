using System;
using System.Collections;
using System.Formats.Asn1;
using System.Runtime.Serialization;

namespace L20250204
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "표명찬";
            string message = string.Format("{0}님 {1} 안녕하세요", name, "정말", 2);
            Console.WriteLine(message.Replace("안녕", "고생"));
            Console.WriteLine(message.Substring(6, 2));

            string data = "10, 20, 30, 40";
            string[] datas = data.Split(",");

            for (int i = 0; i < datas.Length; i++)
            {
                Console.WriteLine(datas[i].Trim());
            }

            
            int A = 2;
            float B = 3.0f;
            long C = 0;
            char D = (char)65;


            B = (float)A;
            A = (int)B;
            C = (long)B;

            int.TryParse(datas[1], out A);

            A.ToString();

            Console.WriteLine(((int)D).ToString()+"_");               


            Console.WriteLine(A);

        
        
        
        
        }

    }
}