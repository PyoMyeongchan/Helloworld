using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace L20250217
{
    public class PlayerController : Component
    {
        public SpriteRenderer spriteRenderer;
        public CharacterController2D characterController;
        public override void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            characterController = GetComponent<CharacterController2D>();
        }

        public override void Update()
        {
            if (Input.GetKeyDown(SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL_Keycode.SDLK_UP))
            {
                characterController.Move(0, -1);
                spriteRenderer.spriteIndexY = 2;
            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL_Keycode.SDLK_DOWN))
            {
                characterController.Move(0, 1);        
                spriteRenderer.spriteIndexY = 3;

            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL_Keycode.SDLK_LEFT))
            {
                characterController.Move(-1, 0);
                spriteRenderer.spriteIndexY = 0;
            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL_Keycode.SDLK_RIGHT))
            {
                characterController.Move(1, 0);
                spriteRenderer.spriteIndexY = 1;
            }
            
        }

        public void OnTriggerEnter2D(Collider2D other)
        {            

            if (other.gameObject.name.CompareTo("Monster") == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;

            }

            if (other.gameObject.name.CompareTo("Goal") == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isFinish = true;                

            }
            Console.WriteLine($"겹침 감지 : {other.gameObject.name}");
        }
    }

}
