using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        { 
            x = inX;
            y = inY;
            Shape = inShape;
            orderLayer = 4;
            isTrigger = true;
        }



        public override void Update()
        {
            if (Input.GetKeyDown(ConsoleKey.UpArrow))
            {
                // 미리가봄 - 모든 게임오브젝트랑 다음에 갈 내위치랑 비교를 한다.
                if (!Checkcollision(x,y - 1))
                {
                    y--;
                }
                
            }
            else if (Input.GetKeyDown(ConsoleKey.DownArrow))
            {
                if (!Checkcollision(x, y + 1))
                {
                    y++;
                }
               
            }
            else if (Input.GetKeyDown(ConsoleKey.LeftArrow))
            {
                if (!Checkcollision(x - 1, y))
                {
                    x--;
                }

            } 
            else if(Input.GetKeyDown(ConsoleKey.RightArrow))
            {
                if (!Checkcollision(x + 1, y))
                {
                    x++;
                }

            }

            


        }




    }
}
