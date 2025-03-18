using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Monster : Charcter
    {
        protected int hp;

        /* public int HP
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }*/

        //

        public int HP
        {
            get; // get에는 X
            set; // 앞에 private를 쓰기도 한다.
        
        }

        protected int gold;

      

        public void ApplyDamage(int damage)
        { 
        
        
        }

        //virtual function table
        //재정의할거만 할 것! - 모든 함수에 다 붙이면 성능이 떨어진다.
        //다형성 : virtual override
        //virtual - 자식들의 함수가 동일하게 있다면 부모 class에 있는 함수에 입력 public virtual void - 배열로 만듬
        //override - 자식들의 함수가 동일하게 부모class에 포함되어있다면 자식 class에 있는 함수에 입력 public override void
        public virtual void Move()
        {


        }


        public void DropGold()
        { 
            
        
        }

        
        public Monster()
        {
            Console.WriteLine("몬스터 생성자");
        }

        ~Monster() { Console.WriteLine("몬스터 소멸자"); }
    }
}
