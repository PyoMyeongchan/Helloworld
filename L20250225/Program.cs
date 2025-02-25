using System;
using System.Collections.Generic;
using System.Collections;
// 동적 배열 클래스
// Add로 배열에 자료 추가
// RemoveAt으로 배열 자료 삭제
// 자료 갯수는 Count
// 자료의 접근과 입력은 [] 연산자로.
// list<a> d = new list<a>();
// d[1] = 1;

namespace L20250225
{

    class DynamicArray<T>
    {
        protected T[] data;
        protected int count;

        public DynamicArray()
        {
            data = new T[10];
            count = 0;
        }

        ~DynamicArray() { }


        public void Add(T newdata)
        {
            if (count >= data.Length)
            {
                T[] newArray = new T[data.Length * 2];
                Array.Copy(data, newArray, data.Length);
                data = newArray;

            }
            data[count] = newdata;
            count++;


        }
        public void RemoveAt(int index)
        {

            for (int i = index; i < count; ++i)
            {
                data[i] = data[i + 1];

            }
            count--;

        }



        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {

                data[index] = value;
            }

        }

        public int Count
        {

            get

            {
                return count;

            }

        }


    }

    public abstract class Animal  // 추상적인 개념 - 상속하기위해 만든 것! / 구현안한다!
    {
        public abstract void Eat();



    }

    public interface IFourleganimal // 다중 상속을 못하니 interface를 사용
    {
        void Run();
    }

    public interface IBird
    {
        void Fly();

    }

    class Lion : Animal, IFourleganimal // 재정의 안하면 ERROR
    {
        public override void Eat()
        {

        }

        public void Run()
        {

        }
    }

    class Tiger : Animal
    {
        public override void Eat()
        {

        }

    }

    class Chicken : Animal, IBird
    {
        public override void Eat()
        {

        }
        public void Fly()
        {

        }

    }

    // 다중 상속, C++에서만 가능
    class Liger : Lion //, Tiger
    {


    }


    // 혼자 만들때는 안쓰지만 / 다 같이 만들때 사용
    // 인터페이스 이름앞에는 I추가
    public interface IItem
    {
        void Use();

    }

    public class Potion : IItem
    {
        public void Use()
        {


        }


    }



    class Program
    {
        static void Main2(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.RemoveAt(11);

            //for (int i = 0; i < list.Count; ++i)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //range for
            foreach (int value in list)
            {
                Console.WriteLine(value);
            }

            DynamicArray<int> dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);

            dynamicArray.RemoveAt(11);
            /*foreach (int value in dynamicArray)
            {
                Console.WriteLine(value);
            }*/
        }


        static void Main(string[] args)
        {



            // 함수 강제 구현, 다중 상속 가능 (인터페이스로!)

            Potion potion = new Potion();
            Type type = potion.GetType();
            if (typeof(Potion) == type.GetInterface("IItem"))
            {
                (potion as Potion).Use();
            }

            List<IItem> items = new List<IItem>();
            items.Add(new Potion());
            foreach (IItem item in items)
            {
                item.Use();
            }

        }

    }

}
