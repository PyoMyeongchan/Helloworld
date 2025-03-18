namespace L20250224___Problem
{
    class Program
    {
        //0,1이 문제에 나오면 bit
        //조건 확인
        static void Main(string[] args)
        {
            uint N = 3;
            uint.TryParse(Console.ReadLine(), out N);
            ulong[] X = new ulong[N];

            for (int i = 0; i < N; ++i)
            { 
                ulong.TryParse(Console.ReadLine(), out X[i]);
            }
                         
            
            X[0] = 3;
            X[1] = 5;
            X[2] = 7;

            ulong result = 0;
            for (int i = 0; i < N; ++i)
            {
                ulong value = 1;
                for (int n = 0; n < 64; ++n)
                {
                    value = value  << 1;
                    //MathF.Pow(X[i], 2);
                   
                    if (X[i] < value)
                    {
                        result = result ^ value;
                        break;

                    }
                }
            }
            Console.WriteLine(result);

        }

    }
}
