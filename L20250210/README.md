## 2025.02.10 수업

* 프로그래민의 첫 마음가짐
  * 어떻게 만들지, 어떻게 연출할지에 대한 생각 계속하기
  * 왜 되는지 생각하기
  * 프로그래밍이란 그냥 만들기이자 구현하기이다!
 
<hr/>

* 값형(value type) : int / float / bool / char / struct ← stack에 생성됨
* 참조형 :  class / int[] / string ← Heap에 생성됨

* 객체 지향 프로그램 - 왜 이렇게 썼는지 의미 파악
* ref 전달 / out 출력 / in 입력

* 재귀함수
  * 자신의 함수 호출 / 계속 부를시 stack overflow
  * 위의 형태가 안나오도록 함수를 정립해야한다.

* Start() - 제일 처음 실행하고 화면에 그릴때 실행됨.

-보통 유니티 오류시 할당을 안했는지 혹은 계속 돌아가는 프로그램을 만든건지 이 2개의 오류가 대다수
<hr/>

## class
* 절차 지향 프로그래밍 → 객체 지향 프로그래밍(class를 설계한다!)
* 관점을 바꾼다는 것! - 사물로 본다.
* 입력한다 / 처리한다 / 출력한다

* class와 sturct의 차이
  * class - heap / sturct - stack
    * heap - 돌려쓰다가 내릴지
    * stack - 바로바로 내리고올릴지

```cs

 class Apple
    {
        public enum EColor
        {
            Red,
            Green,
            Yellow

        }

        public EColor color;
        public bool taste;
        public int shape;
        public int hp = 100;


        public void CanEat()
        {
            hp -= 10;

            Console.WriteLine($"현재 HP {hp}");
        }

        public void Drop(Position target)
        {
            Console.WriteLine("");
        }

        //static void 코드영역에 생성된 전역 함수
        //static은 변수건 함수건 new한다고 만들어지는 것이 아니라 code에 자체 생성되어있고 이를 가져오는 것이다.
        public static void Kill()
        {
            Console.WriteLine("죽었다");
        
        }

        public static int count = 0;
        
    }

    struct Position
    { 
        public int x; public int y; 
    
    }


    internal class Program
    {

        

        static void Main(string[] args) //형태는 고정 class에서 Main은 단 하나! 외울것!
        {
            Position[] positions = new Position[10];
            positions[0].x = 12;
            positions[1].y = 12;


            Apple[] apple = new Apple[3]; //stack 참조변수 heap 가르킴

            /*apple[0] = new Apple(); //heap 사과 모양 자료를 잡음
            apple[0].color = Apple.EColor.Red;

            apple[1] = new Apple();
            apple[1].color = Apple.EColor.Green;

            apple[2] = new Apple();
            apple[2].color = Apple.EColor.Yellow;*/
                         
            for (int i = 0; i < apple.Length; i++)
            {

                apple[i] = new Apple(); //heap apple 형태 메모리 공간 확보
            }

            apple[0].CanEat();
            apple[0].Drop(positions[0]);
            Apple.Kill();

            Console.WriteLine(Apple.count);
        }
    }
```

* class => custom data type (새로운 커스텀 데이터를 만드는 것!)
* 프로그램을 한다는 것은 먼저 class를 만들어야하는 것!
* 자신이 만들 사물의 정보 빼내기
* 객체 지향 프로그래밍 → 주어 동사 목적어 (사람이 보기 편하기위해)

<hr/>

## 데이터 모델링
* 어떻게 설계를 하는가?
* 비즈니스 구현
* 데이터 만드는 연습 - 데이터 구조 / 자료 구조 만들기
  * 테이블로 표현
  * 모든 데이터 구조는 테이블로 가능하다는 것!
  * 명사 동사를 확인해서 만든다 - 명사 = class / 동사 = 함수
 
* 테이블을 코딩해보자 / 사진을 보고 객체를 끄집어내라!

## 클래스를 만들면 생성자와 소멸자 무조건 만들어라! (유니티는 별개)
#### 클래스와 생성자의 이름은 같아야한다.


  
