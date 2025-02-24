using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class GameObject
    {
        public int x;
        public int y;
        public char Shape;
        public int orderLayer;
        public bool isTrigger = false;
        public bool isCollide = false;


        public virtual void Update()
        { 
        
        }

        public virtual void Render()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Shape);
        }

        public virtual void Collide()
        { 
        
        }


        public bool Checkcollision(int newx, int newy)
        {
            for (int i = 0; i < Engine.Instance.world.GetAllGameObject.Count; ++i)
            {

                if (Engine.Instance.world.GetAllGameObject[i].isCollide == true &&
                    Engine.Instance.world.GetAllGameObject[i].x == newx &&
                    Engine.Instance.world.GetAllGameObject[i].y == newy)
                {
                    return true;

                }

            }
            return false;

        }

    }
}
