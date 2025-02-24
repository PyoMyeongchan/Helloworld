using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class Input
    {
        public Input() { }
        ~Input() { }

        static public void Process()
        { 
            keyInfo = Console.ReadKey();
        }

        static protected ConsoleKeyInfo keyInfo;


        static public bool GetKeyDown(ConsoleKey key)
        {
            return(keyInfo.Key == key);

        }

    }
}
