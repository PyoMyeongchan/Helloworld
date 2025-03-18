using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class Monster : GameObject
    {

        private float elapsedTime= 0;

        private Random random = new Random();
        public Monster(int inX, int inY, char inShape)
        {
            x = inX;
            y = inY;
            Shape = inShape;
            orderLayer = 5;
            isTrigger = true;

        }

        public override void Update()
        {
            if (elapsedTime >= 500.0f)
            {
                

                int Direction = random.Next(0, 4);
                if (Direction == 0)
                {
                    if (!Checkcollision(x, y - 1))
                    {
                        y--;
                    }
                }
                if (Direction == 1)
                {
                    if (!Checkcollision(x, y + 1))
                    {
                        y++;
                    }
                }
                if (Direction == 2)
                {
                    if (!Checkcollision(x - 1, y))
                    {
                        x--;
                    }
                }
                if (Direction == 3)
                {
                    if (!Checkcollision(x + 1, y))
                    {
                        x++;
                    }
                }
                elapsedTime = 0;


            }
            else
            { 
                elapsedTime += Time.deltaTime;
            }   

        }


 


    }
}
