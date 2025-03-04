using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Floor : GameObject
    {
        public Floor(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 1;

            color.r = 0;
            color.g = 0;
            color.b = 0;
        }

        //public override void Render()
        //{
        //}
    }
}
