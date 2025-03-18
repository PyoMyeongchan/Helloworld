using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace L20250217
{

    /* delegate
    public class Sample
    {
        public delegate int Command(int a, int b); // 변수인데 함수를 저장할 수 있어서 변수를 넣을 수 있다.

        public Command command;

        public void Sort()
        {
            if (command(1, 2) > 0)
            {
                Console.WriteLine("맞다");
            }
            else
            {
                Console.WriteLine("땡");
            }
        }
    
    }
    */

    /*
    public class EventClass
    {
        public delegate void DelegateSample();
        public event DelegateSample EventSample;

        public void Do()
        {
            // ? 는 null 이면 하지않는다라는 문법.
            EventSample?.Invoke();
        }
    }
    */

    public class Program
    {
        /* delegate / Action / Func
        public delegate void DelegateTest();

        static public void Test()
        {
            Console.WriteLine("Test");
        }

        static public void Test2(int a)
        {
            Console.WriteLine("Test2");
        }

        static public int Test3(int a)
        {
            Console.WriteLine("Test3");
            return a;

        }

        static public void A()
        {
            Console.WriteLine("A");
        }

        static public void B()
        {
            Console.WriteLine("B");
        }
        */

        public static int Compare(GameObject first, GameObject second)
        {
            SpriteRenderer spriteRenderer = first.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderers = second.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null || spriteRenderers == null)
            {
                return 0;
            }

            return spriteRenderer.orderLayer - spriteRenderers.orderLayer;
        }



        /*
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
        */

        /*
        // 리플랙션
        class Data
        {
            public void Count()
            {
                Console.WriteLine("Count");
            }

            private void FuncA()
            {
                Console.WriteLine("private FuncA");
            }

            protected void Sum()
            {
                Console.WriteLine("protected Sum");
            }

            public static void StaticFunction()
            {
                Console.WriteLine("StaticFunction");
            }

            public static void Add(int A, int B)
            {
                Console.WriteLine($"{A} + {B} = {A + B}");
            }

            public int Gold = 1;
            protected int Money = -1000;
            private float hp = -10.5f;

            public int Mp
            {
                get;       
                set;
            }
        
        }
        */

        public static void Main(string[] args)
        {
            /*
            // public delegate void DelegateSample();
            // DelegateSample d = Test;
            // 이 두개를 하나로 퉁친게 Action
            // 클래스 결합도를 낮춘다!
            Action<int> helloaction = Test2;
            helloaction += Test2;
            helloaction(1);
            Func<int, int> f = Test3;
            f += Test3;
            f -= Test3; // 앞에걸 없앤다.
            f(2);

            f += (int number) => { return 10;} - 람다식이면 함수 필요없음
            */


            /*
            EventClass eventClass = new EventClass();
            eventClass.EventSample += Test; // 구독
            //eventClass.EventSample -= Test; // 구독 해지
            eventClass.Do();


            // ex) network 접속하면 이거 실행, callback 함수
            // ex )마우스 입력이 있으면 이 함수 호출해주세요.
            // 등록한 순서대로 진행
            DelegateTest t = new DelegateTest(A);
            t += A;
            t += B;
            t -= A;
            t();
            */

            /*
            Sample.Command command = new Sample.Command((int A, int B) => { return A * B; });
            Console.WriteLine(command(1,2));

            Sample sample = new Sample();
            sample.command = Sub;
            sample.Sort();
            */

            /*
            // 컴포넌트에서매소드, 필드(변수)를 가져와 쓰는 법
            Data d = new Data();            
            Type classType = d.GetType();
            Console.WriteLine(classType.Name);

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo info in methods)
            {
                //Console.WriteLine($"{info.Name}");
                if(info.Name.CompareTo("Add") == 0)
                {
                    ParameterInfo[] paraminfos = info.GetParameters();
                    foreach (ParameterInfo paraminfo in paraminfos)
                    {
                        Console.WriteLine(paraminfo.Name,paraminfos.GetType());
                    }
                    Object[] param = { 3, 5 };
                    info.Invoke(d, param);
                }
            }

            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
                field.SetValue(d, 10);
                Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
            }


            PropertyInfo[] propertyfields = classType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach(PropertyInfo property in propertyfields)
            {
                Console.WriteLine($"{property.PropertyType} {property.Name} {property.GetValue(d)}");
            }
            */

            
            
            Engine.Instance.Init();
            Engine.Instance.SetSortCompare(Compare);

            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();
            
        }
    }
}
