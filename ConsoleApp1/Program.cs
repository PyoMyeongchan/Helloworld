using System.Globalization;

// 반복문 연습하기
namespace ConsoleApp1
{
    public class Program
    {
        public virtual void programadd()
        { 
        
        
        
        }



        static void Main(string[] args)
        {

            // 구구단 만들기
            int k;
            int j;


            for (k = 2; k < 10; k++)
            {
                Console.WriteLine("{0}단", k);
                for (j = 1; j < 10; j++)
                {
                    Console.WriteLine("{0} * {1} = {2}", k, j, k * j);
                    

                }
                Console.WriteLine();

            }

            // break, contiune 이해
            int i;
            for (i = 0; i < 10; i++) //0~9  10번반복
            {
                if (i == 8) break;
                if (i == 3) continue; //탈출때는 이후의 구문은 무시
                Console.WriteLine(i);
            }

            // 0~100까지 2의 배수만 뽑기
            int h;
            for (h = 1; h < 50; h++)
            {
                Console.WriteLine(h * 2);
            }

            // 0 ~ 10 으로
            int u;
            for (u = 0; u <= 10; u++)
            { 
                Console.WriteLine(u);
            }

            // 10 ~ 0으로
            int v;
            for (v = 10; v > 0; v--)
            {
                Console.WriteLine(v);            
            }



        }
    }
}
