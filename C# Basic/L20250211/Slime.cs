using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Slime : Monster
    {
       

        public Slime() { }
        ~Slime() { }
        public void Attck()
        {

        }

        public override void Move()
        {
            Console.WriteLine("스라임이 미끄러져온다");
        }

        
    }
}
