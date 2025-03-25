using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class Program
    {
        // List<Thread> threads; 이같은 경우 C# 자제에서 lock이 걸려있긴하다! 안되어있을 경우 lock을 걸자
        // OS가 끊는걸 여기서는 못하게 하도록하는 것 : 동기화 객체
        static Object _lock = new object();

        static Object _lock2 = new object();

        // 위의 lock과 형식만 다르지 코드는 같다.
        /*
        static SpinLock spinLock = new SpinLock(); // 코드 같다.
        static bool lockTaken = false;
        */

        // atomic 공유영역 작업은 원자성 즉, 중간 끊지 말 것 / volatile : 순서를 바꾸지말라는 것, c#에서는 안쓰는 것을 추천하심!
        //volatile static int money = 0;

        static int money = 0;
        static void Add()
        {   
            // 반복문을 안으로 넣는 경우 lock을 한번만해도 되니까 더 빠르다! 하지만 밖으로 빼서 lock을 확인해줘야하는 경우도 있기때문에 프로그램별 선택하는 것이다!
            lock (_lock) // os한테 물어보지 않는다 UserMode // Kernel Mode -> mutex 사용시 os한테 직접 물어보는 것 // CAS Lock Free


            {
                for (int i = 0; i < 100000; ++i)
                {
                    // Interlocked.Increment(ref money); // switching 안되게 설정
                    // Interlocked.CompareExchange(ref money, i, 0);

                    // OS가 끊는걸 적용하지 못하도록 설정, 공통으로 쓰는 영역에만 사용
                    // unity는 업데이트 함수에서 이미 thread를 적용하여 lock, 원자성 보호! 그래서 thread를 쓰면 뻗는다.


                    money++;
                    // ASM형식 기계어형식상으로는 3줄이나 된다!
                    // int temp = money;
                    // temp = temp + 1;
                    // money = temp;

                    /*
                    // SpinLock 형식
                    spinLock.Enter(ref lockTaken);
                    money++;
                    spinLock.Exit();
                    */

                }
            }
        }

        static void Minus()
        {
            for (int i = 0; i < 100000; ++i)
            {
                //Interlocked.Decrement(ref money); // switching 안되게 설정
                
                // OS가 끊는걸 적용하지 못하도록 설정
                lock (_lock)
                {                
                    money--;
                    // ASM형식
                    // int temp = money;
                    // temp = temp - 1;
                    // money = temp;
                }

                /*
                // SpinLock 형식
                spinLock.Enter(ref lockTaken);
                money--;
                spinLock.Exit();
                */

            }
        }

        // 유니티의 경우 UI thread
        // foreground. main thread 종료되면 나머지 thread 다 종료

        // 실행흐름대로 진행
        // 만약 위의 함수가 무한루프면 밑의 함수가 실행안되어야하지만! thread를 써서 따로 돌아가게 해줄 수 있다는 것!
        static void Main(string[] args)
        {


            Thread thread1 = new Thread(new ThreadStart(Add));
            Thread thread2 = new Thread(new ThreadStart(Minus));

            // Background로 돌거야!
            thread1.IsBackground = true;
            // B함수 따로 실행 시켜줘 (Thread) -> OS 부탁
            // OS 등록 // 바로 시작되는 것이 아니다! 언제 시작할지는 모른다.
            thread1.Start();
            
            thread2.IsBackground = true;
            thread2.Start();

            // thread2.Abort(); // 데드락이 될경우 해당 thread 종료한다. 해결방법이 끄는것밖에 없다. 하지만 저장된 자료도 사라진다는 점
            
            // foreground가 끝나기전까지 기다린다.
            thread1.Join();
            thread2.Join();

            // Thread.Yield(); 스레드 양보 다른 스레드 실행
            // Thread.Sleep(); 잠시 쉬도록 하지만 상황에 따라 바로 될 수도 있음

            Console.WriteLine(money);
           

        }
    }
}

// 이런 경우 랜덤으로 값이 나온다.
/* RAM안의 Process에서 code는 ASM이기 때문에 C#코드와 같지 않다.
즉 money++의 코드처럼 단 한줄이 아니라는 것
ex) money++
1. money 가지고 옴(메모리 있는걸 레지스터로 복사)
2. 레지스터 더하기 (inc)
3. money로 이동 레지스터의 메모리값 복사

ASM 형식
int temp = money;
temp = temp + 1;
money = temp;

OS가 와서 중간에 끊고 다른일하라고 할경우
int temp = money;
-------------------
temp = temp - 1;
money = temp;

그래서 위와같이 volatile와 lock을 사용
*/
