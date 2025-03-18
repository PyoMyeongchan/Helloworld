using Newtonsoft.Json;
using SDL2;
using System;
using System.IO;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Threading;

namespace L20250217
{
    public class Engine
    {
        private Engine()
        {

        }

        static protected Engine instance;

        //더블 버퍼링
        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];

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

        public IntPtr myWindow;
        public IntPtr myRenderer;
        public SDL.SDL_Event myEvent;
        public IntPtr Font;

        public World world;

        public bool Init()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Fail Init.");
                return false;
            }

            myWindow = SDL.SDL_CreateWindow(
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

            // 폰트 설정
            string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            SDL_ttf.TTF_Init();
            // SDL_ttf.TTF_OpenFont(projectFolder + "/data/", 30);

            Font = SDL_ttf.TTF_OpenFont("c:/Windows/Fonts/gulim.ttc", 30);



            world = new World();

            return true;
        }

        public bool Quit()
        {
            isRunning = false;
            SDL_ttf.TTF_Quit();

            SDL.SDL_DestroyRenderer(myRenderer);
            SDL.SDL_DestroyWindow(myWindow);

            SDL.SDL_Quit();
                                    
            return true;
        }


        public void Load(string filename)
        {
            //string tempScene = "";
            //byte[] buffer = new byte[1024];
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
                    GameObject floor = new GameObject();
                    floor.name = "Floor";
                    floor.transform.X = x;
                    floor.transform.Y = y;

                    SpriteRenderer spriteRenderers = floor.AddComponent<SpriteRenderer>();
                    spriteRenderers.colorKey.r = 255;
                    spriteRenderers.colorKey.g = 255;
                    spriteRenderers.colorKey.b = 255;
                    spriteRenderers.colorKey.a = 255;
                    spriteRenderers.LoadMap("floor.bmp");
                    spriteRenderers.orderLayer = 1;

                    world.Instanciate(floor);

                    if ( scene[y][x] == '*' )
                    {
                        GameObject wall = new GameObject();
                        wall.name = "Wall";
                        wall.transform.X = x;
                        wall.transform.Y = y;

                        SpriteRenderer spriteRenderer = wall.AddComponent<SpriteRenderer>();
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadMap("wall.bmp");
                        spriteRenderer.orderLayer = 2;

                        wall.AddComponent<BoxCollider2D>();

                        spriteRenderer.Shape = '*';

                        world.Instanciate(wall);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        //Player player = new Player(x, y, scene[y][x]);
                        //world.Instanciate(player);
                        GameObject player = new GameObject();
                        player.name = "Player";
                        player.transform.X = x;
                        player.transform.Y = y;
                        player.AddComponent<PlayerController>();
                        SpriteRenderer spriteRenderer = player.AddComponent<SpriteRenderer>();
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 0;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadMap("player.bmp",true);
                        spriteRenderer.orderLayer = 3;

                        spriteRenderer.Shape = 'P';

                        CharacterController2D characterController2D = player.AddComponent<CharacterController2D>();
                        characterController2D.isTrigger = true;


                        world.Instanciate(player);

                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new GameObject();
                        monster.name = "Monster";
                        monster.transform.X = x;
                        monster.transform.Y = y;

                        SpriteRenderer spriteRenderer = monster.AddComponent<SpriteRenderer>();
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadMap("monster.bmp");
                        spriteRenderer.orderLayer = 4;
                        

                        spriteRenderer.Shape = 'M';

                        monster.AddComponent<AIController>();
                        CharacterController2D characterController2D = monster.AddComponent<CharacterController2D>();
                        characterController2D.isTrigger = true;

                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        GameObject goal = new GameObject();
                        goal.name = "Goal";
                        goal.transform.X = x;
                        goal.transform.Y = y;

                        SpriteRenderer spriteRenderer = goal.AddComponent<SpriteRenderer>();
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadMap("goal.bmp");
                        spriteRenderer.orderLayer = 2;

                        spriteRenderer.Shape = 'G';
                        CharacterController2D characterController2D = goal.AddComponent<CharacterController2D>();
                        characterController2D.isTrigger = true;

                        world.Instanciate(goal);

                        Console.WriteLine("Failed");
                    }

                    // 심판 생성
                    GameObject gameManager = new GameObject();
                    gameManager.name = "GameManager";
                    gameManager.AddComponent<GameManager>();
                    world.Instanciate(gameManager);


                }
            }

            //loading complete
            //sort
            world.Sort();
            Awake();
            
            /* JSON으로 변환하여 파일 저장
            string SceneFile = JsonConvert.SerializeObject(world.GetAllGameObjects, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore    // Gameobject 루프방지

            });
            Console.WriteLine(SceneFile);

            StreamWriter sw = new StreamWriter("sample.uasset");

            sw.WriteLine(SceneFile);
            sw.Close();
            */

            /* 로드하기 - 현재는 c#만 쓰지않아서(Inptr) 오류가나온다 
            StreamReader sr2 = new StreamReader("sample.uasset");

            string SceneFile = sr2.ReadToEnd(); 
            sr2.Close();

            List<GameObject> gos = JsonConvert.DeserializeObject<List<GameObject>>(SceneFile, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore    // Gameobject 루프방지

            });
            */
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
            SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(myRenderer);

            world.Render();

            for (int Y = 0; Y < 20; ++Y)
            {
                for(int X = 0; X < 40; ++X)
                {
                    if (Engine.frontBuffer[Y, X] != Engine.backBuffer[Y, X])
                    {
                        Engine.frontBuffer[Y, X] = Engine.backBuffer[Y, X];
                        Console.SetCursorPosition(X, Y);
                        Console.Write(frontBuffer[Y, X]);
                    }
                }
            }

            SDL.SDL_RenderPresent(myRenderer);

        }

        public void Run()
        {
            Console.CursorVisible = false;
                       

            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvent);

                Time.Update();

                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;


                }

                Update();
                Render();
            }
        }

        public void Awake()
        {
            world.Awake();
        }

        public void SetSortCompare(World.SortCompare insortCompare)
        { 
            world.sortCompare = insortCompare;
        
        }


    }
}
