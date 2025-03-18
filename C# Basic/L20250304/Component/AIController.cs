using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class AIController : Component
    {
        private Random rand = new Random();


        private float elapsedTime = 0;

        public CharacterController2D characterController2D;
        public override void Awake()
        {
;
            characterController2D = GetComponent<CharacterController2D>();
        }


        public override void Update()
        {
            
            if (elapsedTime >= 500.0f)
            {
                int Direction = rand.Next(0, 4);

                if (Direction == 0)
                {
                    characterController2D.Move(0, -1);

                }
                if (Direction == 1)
                {
                    characterController2D.Move(0, 1);

                }
                if (Direction == 2)
                {
                    characterController2D.Move(-1, 0);

                }
                if (Direction == 3)
                {
                    characterController2D.Move(1, 0);

                }
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }

            Console.SetCursorPosition(30, 10);
            Console.Write(Time.deltaTime);
        
            

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name.CompareTo("Player") == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;

            }
        }
    }
}
