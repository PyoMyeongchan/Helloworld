using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public abstract class Component
    {
        public virtual void Awake()
        { 
        
        }

        public abstract void Update();

        public GameObject gameObject;



    }
}
