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
           

            if (Input.GetKeyDown(ConsoleKey.UpArrow))
            {
              
                
                    Y--;
               

            }
            else if (Input.GetKeyDown(ConsoleKey.DownArrow))
            {
      
         
                    X--;
    

            }
            else if (Input.GetKeyDown(ConsoleKey.LeftArrow))
            {
   
            
                    Y++;
              

            }
            else if (Input.GetKeyDown(ConsoleKey.RightArrow))
            {
        
         
                    X++;
     

            }


        }

        public override void Collide()
        {
           
           
        }
    }
}
