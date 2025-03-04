using SDL2;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using static SDL2.SDL;

// 숫자 순서로 작성하였음
namespace SDL_20250304
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 엔진 초기화
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Fail Init.");
            
            }

            // 2. 창 만들기
            IntPtr mywindow = SDL.SDL_CreateWindow
            (
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
            );

            // 6. 그리기위해 필요한 붓
            IntPtr myRenderer = SDL.SDL_CreateRenderer(mywindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | 
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC | 
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

            // 3. 메세지 처리(사용자 처리가 추가 구조를 바꿈)
            SDL.SDL_Event myEvent;
            bool isRunning = true;

            // 4. Event Loop, Game Loop
            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvent);
                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false; 
                        break;
                
                }
                // 7. CPU가 GPU에게 명령 내리기위해 설정하는 중
                SDL.SDL_SetRenderDrawColor(myRenderer, 0, 255, 0, 0); // 화면색 검은색으로
                SDL.SDL_RenderClear(myRenderer);

                /*
                Random  random = new Random();                                
                for (int i = 0; i < 100; i++)
                {
                    
                    // 랜덤으로 100개 사각형 그리기
                    byte r = (byte)(random.Next() % 256);
                    byte g = (byte)(random.Next() % 256);
                    byte b = (byte)(random.Next() % 256);


                    SDL_Rect rect;
                    rect.x = random.Next() % 640 - 200;
                    rect.y = random.Next() % 480 - 200;
                    rect.w = random.Next() % 480;
                    rect.h = random.Next() % 480;

                    SDL.SDL_SetRenderDrawColor(myRenderer, r, g, b, 0);

                    int type = random.Next() % 2;

                    switch (type)
                    {
                        case 0:
                            SDL.SDL_RenderDrawRect(myRenderer, ref rect);
                            break;
                        case 1:
                            SDL.SDL_RenderFillRect(myRenderer, ref rect);
                            break;
                        

                    }

                }
                */

                //원그리기

                double radius = 30.0f;
                int x0 = 320;
                int y0 = 240;

                int prevx = (int)(radius * Math.Cos(0 * (Math.PI / 180.0f)));
                int prevy = (int)(radius * Math.Sin(0 * (Math.PI / 180.0f)));

                SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);

                for (int i = 1; i <= 370; i+= 20)
                {
                    int x = (int)(radius * Math.Cos(i * (Math.PI/ 180.0f)));
                    int y = (int)(radius * Math.Sin(i * (Math.PI / 180.0f)));

                    SDL.SDL_RenderDrawLine(myRenderer, x0 + prevx, y0 + prevy, x0 + x, y0 + y);
                    prevx = x; 
                    prevy = y;

                }




                SDL.SDL_RenderPresent(myRenderer);
            }

            // 5. 종료
            SDL.SDL_DestroyWindow(mywindow);

            SDL.SDL_Quit();
        }

        void draw()
        {
            for (int i = 0; i < 100; i++)
            {


            }
        
        }


    }
}
