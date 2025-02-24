using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    
    class CustomException : Exception
    {
        public CustomException() : base("이거 내가 만든 예외")
        {
                        
        
        }


    }
    //Network에 접속했지만 비밀번호가 틀리다.
    class WronpasswordException : Exception
    {
        public WronpasswordException() : base("비밀번호 틀림")
        {


        }


    }



    internal class Program
    {
        class Singleton
        {
            private Singleton()
            { 
            
            }

            static Singleton instance;
            static public Singleton GetInstance()
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            
            }
              
        
        
        }
        static void Main(string[] args)
        {
            Engine.Instance.Load("Level02.map");
            Engine.Instance.Run();


            /*while (fs.CanRead)
            { 
                int readCount = fs.Read(buffer, offset, 80);
                offset += 80;
                scene = scene + Encoding.UTF8.GetString(buffer);
            }
            // 썼으면 꼭 지워야한다!
            //fs.Close();
             ----------------------------------------------------*/

            /*---------------------------------------------------
            //예외처리

            StreamReader sr;

            try
            {
                
                List<string> scene = new List<string>();

                sr = new StreamReader("Level02.map");
                while (!sr.EndOfStream)
                {
                    scene.Add(sr.ReadLine());
                }
                

                //throw new WronpasswordException();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.FileName);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.Message);
            }
            catch (WronpasswordException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) //제일 부모이기에 제일 마지막에있어야한다!
            {
                Console.WriteLine("이거 파일 처리 예외 말고 다른거");

            }
            finally // 무조건 실행가능하게 하는것
            {
                //network,file 입출력에서 대체로 사용!
                sr.Close();
            }
            ------------------------------------------------------*/

        }
    }
}
