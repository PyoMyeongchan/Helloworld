## 2025.02.18

* C#을 할 수 있다는 것
	* 기본예약어
	* 객체 프로그래밍 
	* Collection 사용 가능(Array(배열),DynamicArray(동적배열),Queue,LinkList) 만들어봤는가?
	* Collection을 하는 이유 : 최적화

```cs
namespace L20250218
{
    class DynamicArray
    {
        public DynamicArray()
        {

        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(Object inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
        }

        protected void ExtendSpace()
        {
            //배열 늘이기
            //이전 정보 옮기기
            Object[] newObject = new Object[objects.Length * 2];
            //이전값 이동
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        //[][][][][]
        public bool Remove(Object removObject)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (removObject == objects[i])
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        //[][][][][][]
        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; ++i)
                {
                    objects[i] = objects[i + 1];
                }

                count--;
                return true;
            }

            return false;
        }

        //[1][2][3]
        //Insert(2, 5);
        //[1][2][3][4]
        public void Insert(int insertIndex, Object value)
        {
            //3 == 3  + 1 -> [1][2][3] - >[1][2][3][][][]
            //1. object.length == count
            //확장
            //추가 
            //3 == 2 + 1     [1][2][3][][][]
            //2. object.length < count
            //확장 X
            //추가
            if (objects.Length == count)
            {
                ExtendSpace();
            }


            for (int i = count; i > insertIndex; --i)
            {
                objects[i] = objects[i - 1];
            }
            objects[insertIndex + 1] = value;
            count++;
        }

        protected Object[] objects = new Object[10];

        protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Object this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }

    //Generic
    //형태가 동일 해져서 버그 발생이 적어짐




    class Program
    {   //overloading
        //Generic Programming -> meta Programming
        static public void Print<T>(T[] data)
        {
            for (int i = 0; i < data.Length; ++i)
            { 
                Console.WriteLine(data[i]);
            
            }
        
        }

        /*  static public void Print(char[] data)
          {
              for (int i = 0; i < data.Length; ++i)
              {
                  Console.WriteLine(data[i]);

              }
          }

          static public void Print(string[] data)
          {
              for (int i = 0; i < data.Length; ++i)
              {
                  Console.WriteLine(data[i]);

              }

          }*/

        //static public int Add<T>(T x, T y)
        //{
        //    return x + y;
        //}
        // 이러면 오류나온다. 여러 종류 중 gameObject에서 더하기란 없기때문!
        
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4 };
            char[] numberToChar = { 'A', 'B', 'C', 'D' };
            string[] numberString = { "1111", "2222", "3333", "4444" };
            GameObject[] gameObjects = new GameObject[3];






            char A = 'A';
            char B = 'B';
            string line = A + B + "*";
            //[] ->                  variable
            //[][][][][]             array -> Array
            //[][][][][][][][][][]   DynamicArray
            //DataStructure          자료구조
            //
            DynamicArray a = new DynamicArray();
            for (int i = 0; i < 10; ++i)
            {
                a.Add(i);
            }

            //DOWN CASTING
            //boxing - unboxing

            a[1] = 11;
            a[9] = 29;



            a.RemoveAt(9);
            a.RemoveAt(1);
            a.RemoveAt(3);
            a.Insert(2, 11);
            a.Insert(4, "배고파");
            a.Add(new GameObject());

            for (int i = 0; i < a.Count; ++i)
            {
                Console.Write(a[i] + ", ");
            }
            //equal - 두개의 화살표가 같은 것을 가리키는지 가르킨다면 True;
            


        }
    }
}
```

#### TDynamicArray

```cs
namespace L20250218
{
    //Generic class
    class TDynamicArray<T>  // : where T : new() 이런식으로 제약 가능 or where T : struct or where T : class
    {
        public TDynamicArray()
        {

        }

        ~TDynamicArray()
        {

        }
       
        public void Add(T inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
        }

        protected void ExtendSpace()
        {

            T[] newObject = new T[objects.Length * 2];
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        public bool Remove(T removObject)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (removObject.Equals(objects[i]))
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; ++i)
                {
                    objects[i] = objects[i + 1];
                }

                count--;
                return true;
            }

            return false;
        }


        public void Insert(int insertIndex, T value)
        {

            if (objects.Length == count)
            {
                ExtendSpace();
            }


            for (int i = count; i > insertIndex; --i)
            {
                objects[i] = objects[i - 1];
            }
            objects[insertIndex + 1] = value;
            count++;
        }

        protected T[] objects = new T[10];

        protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public T this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }


    }
}


```


