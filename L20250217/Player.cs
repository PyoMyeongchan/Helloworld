using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }

        public override void Update()
        {      
            int temp = 0;

            if (Input.GetKeyDown(ConsoleKey.UpArrow))
            {
                temp = Y - 1;
                if (Engine.Instance.scene[X][temp] != '*')
                {
                    Y--;
                }

            }
            else if (Input.GetKeyDown(ConsoleKey.DownArrow))
            {
                temp = X - 1;
                if (Engine.Instance.scene[temp][Y] != '*')
                {
                    X--;
                }

            }
            else if (Input.GetKeyDown(ConsoleKey.LeftArrow))
            {
                temp = Y + 1; 
                if (Engine.Instance.scene[X][temp] != '*')
                {
                    Y++;
                }

            }
            else if (Input.GetKeyDown(ConsoleKey.RightArrow))
            {
                temp = X + 1;
                if (Engine.Instance.scene[temp][Y] != '*')
                {
                    X++;
                }

            }


        }

        public override void Collide()
        {
           
           
        }
    }
}
