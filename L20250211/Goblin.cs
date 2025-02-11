using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Goblin : Monster
    {

        public Goblin()
        {
            Console.WriteLine("고블린 생성자");
        }

        ~Goblin() { Console.WriteLine("고블린 소멸자"); }


        
        public override void Move()
        {
            Console.WriteLine("고블린이 걷는다");
        }

        

    }
}
