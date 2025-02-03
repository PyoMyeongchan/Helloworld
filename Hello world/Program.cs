namespace Hellow_Wolrd
{
    internal class Program
    {   //전역함수
        static char wall = '*';
        static char floor = ' ';
        static int playerX = 1;
        static int playerY = 1;

        static int[,] map =
            {
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 4, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 8, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
        static ConsoleKeyInfo keyInfo;

        static bool IsRunning = true;
        static void Main(string[] args)
        {
            while (IsRunning)
            {
                Input();
                Update();
                Render();
            }

            Console.Clear();
            Console.WriteLine("Game over");
        }
        private static void Input()
        {
            keyInfo = Console.ReadKey();
        }

        private static void Update()
        {
            if (keyInfo.Key == ConsoleKey.W ||
                keyInfo.Key == ConsoleKey.UpArrow)
            {
                playerY--;
            }
            else if (keyInfo.Key == ConsoleKey.S ||
                keyInfo.Key == ConsoleKey.DownArrow)
            {
                playerY++;
            }
            else if (keyInfo.Key == ConsoleKey.A ||
                keyInfo.Key == ConsoleKey.LeftArrow)
            {
                playerX--;
            }
            else if (keyInfo.Key == ConsoleKey.D ||
                keyInfo.Key == ConsoleKey.RightArrow)
            {
                playerX++;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                IsRunning = false;
            }
        }

        private static void Render()
        {
            Console.Clear();

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write('P');
                    }
                    else if (map[y, x] == 1)
                    {
                        Console.Write(wall);
                    }
                    else if (map[y, x] == 0)
                    {
                        Console.Write(floor);
                    }
                    else if (map[y, x] == 4)
                    {
                        Console.Write('M');
                    }
                    else if (map[y, x] == 8)
                    {
                        Console.Write('H');
                    }
                }
                Console.Write('\n');
            }
        }

        
        }

     }