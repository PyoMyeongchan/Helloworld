namespace L20250217
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

        protected static TimeSpan deltaTimeSpan;

        protected static DateTime currentTime;
        protected static DateTime lastTime;

        public static void Update()
        {
            currentTime = DateTime.Now;
            deltaTimeSpan = currentTime - lastTime;
            lastTime = currentTime;
        }
    }
}
