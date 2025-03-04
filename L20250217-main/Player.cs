using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace L20250217
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 4;
            isTrigger = true;

            color.r = 0;
            color.g = 0;
            color.b = 255;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL_Keycode.SDLK_UP))
            {
                if (!PredictCollision(X, Y - 1))
                {
                    Y--;
                }
            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL_Keycode.SDLK_DOWN))
            {
                if (!PredictCollision(X, Y + 1))
                {
                    Y++;
                }

            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL_Keycode.SDLK_LEFT))
            {
                if (!PredictCollision(X - 1, Y))
                {
                    X--;
                }
            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL_Keycode.SDLK_RIGHT))
            {
                if (!PredictCollision(X + 1, Y))
                {
                    X++;
                }
            }
        }
    }
}
