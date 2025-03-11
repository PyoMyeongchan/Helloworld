using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameObject
    {
        public List<Component> components = new List<Component>();

        public bool isTrigger = false;
        public bool isCollide = false;

        public string name;

        protected static int gameObjectCount = 0;

        public Transform transform;


        public GameObject()
        {
            Init();
            gameObjectCount++;
            name = $"GameObject{gameObjectCount}";
        }
        ~GameObject()
        {
            gameObjectCount--;

        }

        public void Init()
        {
            transform = new Transform();
            transform = AddComponent<Transform>();
        }

        // 제약

        public T AddComponent<T>() where T :Component, new()
        {
            T incomponent = new T();
            components.Add(incomponent);
            // 컴포넌트의 게임오브젝트가 자기자신이라는 것을 지정해주는 코드
            incomponent.gameObject = this;
            incomponent.transform = transform;
            return incomponent;
        }



        public virtual void Update()
        {
            // 모든 컴포넌트의 update 함수 실행해줘.
        }

        public bool PredictCollision(int newX, int newY)
        {
            /*
            for (int i = 0; i < Engine.Instance.world.GetAllGameObjects.Count; ++i)
            {
                if (Engine.Instance.world.GetAllGameObjects[i].isCollide == true && Engine.Instance.world.GetAllGameObjects[i].X == newX && Engine.Instance.world.GetAllGameObjects[i].Y == newY)
                {
                    return true;
                }
            }
            */
            return false;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component is T)
                {
                    return component as T;

                }
            }

            return null;

        }


        public void ExcuteMethod(string methodName, Object[] parameters)
        {
            foreach (var component in components)
            {
                Type type = component.GetType();
                MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    if (methodInfo.Name.CompareTo(methodName) == 0)
                    {                       
                        methodInfo.Invoke(component, parameters);

                    }
                }
            }

        }

        public static GameObject Find(string gameObjectName)
        {
            foreach (var choiceObject in Engine.Instance.world.GetAllGameObjects)
            {
                if (choiceObject.name.CompareTo(gameObjectName) == 0)
                {
                    return choiceObject;
                }

            }

            return null;
        }
    }
}

