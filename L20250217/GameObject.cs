using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameObject
    {
        public int X;
        public int Y;
        public char Shape;

        public virtual void Update()
        {
            
        }

        public virtual void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Shape);
        }

        public virtual void Collide()
        { 
        
        }

    }
}
