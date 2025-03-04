using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Goal : GameObject
    {
        public Goal(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 3;
            isTrigger = true;

            color.r = 0;
            color.g = 255;
            color.b = 255;
        }
    }
}
