using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Monster : GameObject
    {
        private Random rand = new Random();

        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }

        public override void Update()
        {
           
            int Direction = rand.Next(0,4);

            if (Direction == 0)
            {
                Y--;
            }
            if (Direction == 1)
            {
                Y++;
            }
            if (Direction == 2)
            {
                X--;
            }
            if (Direction == 3)
            {
                X++;
            }

            
        }

        public override void Collide()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
        }

    }
}
