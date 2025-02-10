namespace L20250210
{
    

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
}



