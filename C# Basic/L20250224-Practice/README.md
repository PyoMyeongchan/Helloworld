#### C# 수업 정리 
1. 파일 입출력 코드
 1)
   ``cs
   
            //string tempScene = "";
            //byte[] buffer = new byte[1024];
            // 맵파일가져와서 등록
            //FileStream fs = new FileStream("level01.map", FileMode.Open);

            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;

            //fs.Seek(0, SeekOrigin.Begin);
            //int readCount = fs.Read(buffer, 0, (int)fileSize);
            //tempScene = Encoding.UTF8.GetString(buffer);
            //tempScene = tempScene.Replace("\0", "");
            //string[] scene = tempScene.Split("\r\n");
   ``

  2)
    ``cs

          engine - script
            List<string> scene = new List<string>();

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                scene.Add(sr.ReadLine());
            }
            sr.Close();

        program - script
                static void Main(string[] args)
        {
            Engine.Instance.Load("Level01.map");
            Engine.Instance.Run();
        }
    
    ``


2. 예외 처리

   ``cs

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

        static void Main(string[] args)
       {
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
       }
   ``


   
