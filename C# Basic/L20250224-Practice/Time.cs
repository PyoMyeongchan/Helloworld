using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class Time
    {
        public static float deltaTime
        {
            get
            {
                return (float)deltaTimeSpan.TotalMilliseconds;
            }
        
        
        }

        public static TimeSpan deltaTimeSpan;
        public static DateTime currnetTime;
        public static DateTime lastTime;

        public static void Update()
        {
            currnetTime = DateTime.Now;
            deltaTimeSpan = currnetTime - lastTime;
            lastTime = currnetTime;

        }

    }
}
