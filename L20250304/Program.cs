using System;
using System.Reflection;
using System.Text;

namespace L20250217
{
    public class Program
    {
        /*
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

        static void Main(string[] args)
        {
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

            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();
            
        }
    }
}
