namespace L20250217
{
    internal class Program
    {
        class Singleton
        { 
            private Singleton() 
            
            {
            
            
            }

            static Singleton instance;
            static public Singleton GetInstance()
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        
        }
        
        static void Main(string[] args)
        {
            
            Engine.Instance.Load();

            Engine.Instance.Run();

            
        }
    }
}