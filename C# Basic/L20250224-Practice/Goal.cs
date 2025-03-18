using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class Goal : GameObject
    {
        public Goal(int inX, int inY, char inShape)
        {
            x = inX;
            y = inY;
            Shape = inShape;
            orderLayer = 3;
            isTrigger = true;
        }
        ~Goal() 
        { 
        
        }

        public override void Update()
        {
            
        }


    }
}
