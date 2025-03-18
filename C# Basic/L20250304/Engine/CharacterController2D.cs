using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class CharacterController2D : Collider2D
    {
        public void Move(int addX, int addY)
        {
            int futureX = transform.X + addX;
            int futureY = transform.Y + addY;
            foreach (var choiceObject in Engine.Instance.world.GetAllGameObjects)
            {
                if (choiceObject.GetComponent<Collider2D>() != null)
                {
                    if(choiceObject.transform.X == futureX && choiceObject.transform.Y == futureY)
                    {
                        if (choiceObject.GetComponent<Collider2D>().isTrigger == true)
                        {
                            Object[] parameters = { choiceObject.GetComponent<Collider2D>()};
                            gameObject.ExcuteMethod("OnTriggerEnter2D", parameters);
                            Object[] parameters2 = { gameObject.GetComponent<Collider2D>() };
                            choiceObject.ExcuteMethod("OnTriggerEnter2D", parameters);
                            break;
                        }
                        else
                        {
                            return;                       
                        }


                    }
                }
            }
            transform.Translate(addX, addY);
  

        }
    }
}
