using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class SpriteRenderer : Component
    {
        public char Shape; //Mesh, Spirte
        public int orderLayer;
        public SDL.SDL_Color color;
        public int spriteSize = 30; // 맵 크기 변경
        protected bool isAnimation = false;
        protected IntPtr myTexture;
        protected IntPtr mySurface;

        protected int spriteIndexX = 0;
        protected int spriteIndexY = 0;

        public SDL.SDL_Color colorKey;

        protected string filename;

        private float elapsedTime = 0;

        private SDL.SDL_Rect sourceRect; // 원본 이미지
        private SDL.SDL_Rect destinationRect; // 사이즈

        public float processTime = 100.0f;
        public int maxCellCountX = 5;
        public int maxCellCountY = 5;

        public SpriteRenderer()
        {
        }
        


        public override void Update()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;

            //SDL.SDL_SetRenderDrawColor(Engine.Instance.myRenderer, color.r, color.g, color.b, color.a);
            //SDL.SDL_RenderDrawPoint(Engine.Instance.myRenderer, X, Y);
            destinationRect.x = X * spriteSize;
            destinationRect.y = Y * spriteSize;
            destinationRect.w = spriteSize;
            destinationRect.h = spriteSize;

            unsafe
            {
                // 이미지 정보 가져와서 할일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);


                if (isAnimation)
                {
                    if (elapsedTime >= processTime)
                    {
                        spriteIndexX++;
                        spriteIndexX = spriteIndexX % maxCellCountX;
                        elapsedTime = 0;
                    }
                    else
                    {
                        elapsedTime += Time.deltaTime;
                    }
                    int cellSizeX = surface->w / maxCellCountX;
                    int cellSizeY = surface->h / maxCellCountY;
                    sourceRect.x = cellSizeX * spriteIndexX;
                    sourceRect.y = cellSizeY * spriteIndexY;
                    sourceRect.w = cellSizeX;
                    sourceRect.h = cellSizeY;

                }
                else
                {
                    sourceRect.x = 0;
                    sourceRect.y = 0;
                    sourceRect.w = surface->w;
                    sourceRect.h = surface->h;

                }

            }
            // srcrect : 출발지 / dstrect : 도착지
        }

        public virtual void Render()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;
            // 모든 컴포넌트 중에 그리는 애만 호출해줘.
            // X,Y 위치에 Shape 출력
            // Console.SetCursorPosition(X, Y);
            // Console.Write(Shape);
            Engine.backBuffer[Y, X] = Shape;

            //SDL.SDL_RenderFillRect(Engine.Instance.myRenderer, ref myRect);

            unsafe
            {
                                // srcrect : 출발지 / dstrect : 도착지
                SDL.SDL_RenderCopy(Engine.Instance.myRenderer, myTexture, ref sourceRect, ref destinationRect);

            }
        }


        public void LoadMap(string inFilename, bool inIsAnimation = false)
        {
            // 파일 찾아서 사진 넣기
            string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            isAnimation = inIsAnimation;
            filename = inFilename;

            // SDL C, 접근 할 수 있는게 없어서
            // 파일을 로딩 / 포인터로 파일을 찾음
            mySurface = SDL.SDL_LoadBMP(projectFolder + "/data/" + filename);
            unsafe
            {
                // 이미지 정보 가져와서 칼라키 삽입
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                // 1 = true / 0 = false
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format, colorKey.r, colorKey.g, colorKey.b));

            }
            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);
            // 사진파일 -> RAM -> VRAM -> GPU
            // 애니메이션 - GPU
        }

    }
}
