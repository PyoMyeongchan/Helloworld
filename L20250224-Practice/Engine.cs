using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class Engine
    {
        private Engine()
        { 

        }
        static protected Engine instance;
        
        static public Engine Instance
        {
            get
            {
                if (instance == null)
                { 
                instance = new Engine();
                
                }
            
                return instance;
            }
        
        
        }

        protected bool isRunning = true;
        
        public string[] scene;

        public void Load(string filename)
        { 
            world = new World();

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

            List<string> scene = new List<string>();

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                scene.Add(sr.ReadLine());
            }
            sr.Close();




            for (int y = 0; y < scene.Count; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {

                    if (scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        world.Instanciate(wall);

                    }                                      
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instanciate(player);

                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instanciate(monster);

                    }
                    else if (scene[y][x] == 'G')
                    { 
                        Goal goal = new Goal(x, y, scene[y][x]);
                        world.Instanciate(goal);
                    
                    }

                    Floor floor = new Floor(x, y,' ');
                    world.Instanciate(floor);

                }

            }

            // Loading Complete
            // sort
            world.Sort();
        
        }

        public void ProcessInput()
        {
            Input.Process(); 
        
        }

        protected void Update()
        {
            world.Update();            
        }

        protected void Render()
        { 
            Console.Clear();
            world.Render();
        }

        public void Run()
        {
            while (isRunning)
            {
                ProcessInput();
                Update();
                Render();

            }
            
        }

        public World world;
    }
}
