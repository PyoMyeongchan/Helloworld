using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224_Practice
{
    public class World
    {
        //DynamicArray
        //public GameObject[] gameObjects = new GameObject[100];
        List<GameObject> gameObjects = new List<GameObject>();
        //int useGameObjectCount = 0;
        public List<GameObject> GetAllGameObject
        {
            get
            { 
                return gameObjects;
            }
        
        }

        public void Instanciate(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
           // gameObjects[useGameObjectCount] = gameObject;
           //useGameObjectCount++;
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }

        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Render();
            }
        }

        public void Collide()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Collide();

            }
        }

        public void Sort()
        {
            // gameObjects.Sort();

            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = 0; j < gameObjects.Count; j++)
                {
                    if (gameObjects[i].orderLayer - gameObjects[j].orderLayer < 0)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;

                    }
                }
            }

        }
    }

}
