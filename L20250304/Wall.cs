using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Wall : GameObject
    {
        public Wall(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 2;
            isCollide = true;

            color.r = 255;
            color.g = 0;
            color.b = 0;
        }
    }
}
