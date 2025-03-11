using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameManager : Component
    {
        public bool isGameOver = false;
        public bool isFinish = false;

        public override void Update()
        {
            if (isGameOver)
            {
                if (GameObject.Find("failObject") == null)
                {
                    Console.WriteLine("Failed");
                    GameObject failObject = new GameObject();
                    failObject.name = "failObject";
                    TextRenderer textRenderer = failObject.AddComponent<TextRenderer>();
                    textRenderer.color.r = 255;
                    textRenderer.color.g = 0;
                    textRenderer.color.b = 0;
                    textRenderer.transform.X = 100;
                    textRenderer.transform.Y = 100;

                    textRenderer.SetText("실패");
                    Engine.Instance.world.Instanciate(failObject);
                }
            }

            if (isFinish)
            {
                if (GameObject.Find("successObject") == null)
                {
                    Console.WriteLine("Success");
                    GameObject successObject = new GameObject();
                    successObject.name = "successObject";
                    TextRenderer textRenderer = successObject.AddComponent<TextRenderer>();
                    textRenderer.color.r = 0;
                    textRenderer.color.g = 0;
                    textRenderer.color.b = 255;
                    textRenderer.transform.X = 100;
                    textRenderer.transform.Y = 100;

                    textRenderer.SetText("성공");
                    Engine.Instance.world.Instanciate(successObject);
                }
            }
        }


    }
}
