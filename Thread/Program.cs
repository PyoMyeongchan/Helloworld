using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class Program
    {
        static int money = 0;

        static void Add()
        {
            for (int i = 0; i < 1000; ++i)
            {
 
                money++;    

            }
        }

        static void Minus()
        {
            for (int i = 0; i < 1000; ++i)
            {
                money--;
                
            }
        }

        // 유니티의 경우 UI thread
        // foreground. main thread 종료되면 나머지 thread 다 종료

        // 무한루프로 밑에 함수가 실행안되어야하지만! thread를 써서 따로 돌아가게 해줄 수 있다는 것!
        static void Main(string[] args)
        {


            Thread thread1 = new Thread(new ThreadStart(Add));
            Thread thread2 = new Thread(new ThreadStart(Minus));

            // Background로 돌거야!
            thread1.IsBackground = true;
            // B함수 따로 실행 시켜줘 (Thread) -> OS 부탁
            thread1.Start();
            
            thread2.IsBackground = true;
            thread2.Start();


            
            // foreground가 끝나기전까지 기다린다.
            thread1.Join();
            thread2.Join();

            Console.WriteLine(money);
           

        }
    }
}
