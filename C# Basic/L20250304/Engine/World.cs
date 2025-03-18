using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class World
    {
        public delegate int SortCompare(GameObject first, GameObject second);

        public SortCompare sortCompare;

        List<GameObject> gameObjects = new List<GameObject>();
        //List<GameObject> visibleList = new List<GameObject>();

        public List<GameObject> GetAllGameObjects
        {
            get
            {
                return gameObjects;
            }
        }

        //[1][0][2][3][5][6][7][8][9]
        //
        //[][][][][][][][][]
        //
        public void Instanciate(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                foreach (Component component in gameObjects[i].components)
                { 
                    component.Update();
                }
            }
        }

        public void Render()
        {
            
            for (int i = 0; i < gameObjects.Count; i++)
            {
                Renderer spriteRenderer = gameObjects[i].GetComponent<Renderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.Render();
                }
            }
            
        }

        public void Sort()
        {
            //gameObjects.Sort();
            //gameObjects[i] > gameObjects[j]

            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    
                    if (sortCompare(gameObjects[i], gameObjects[j]) > 0)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }
            
        }

        public void Awake()
        {
            foreach (var choiceObject in gameObjects)
            {
                foreach (Component component in choiceObject.components)
                {
                    component.Awake();                
                }
            }
        
        }

    }
}
