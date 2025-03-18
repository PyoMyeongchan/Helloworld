using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Player : Charcter
    {
        public int hp;
        public int gold;



       
        public Player()
        {
            hp = 100;
            gold = 0;
            Console.WriteLine("플레이어 생성자");  //초기화, 무한히 생성 가능
        }

        //생성자  overloading 
        public Player(int inhp, int ingold)
        { 
            hp = inhp;
            gold = ingold;   
        
        }

        ~Player() 
        {
            //Network, DB 종료
           Console.WriteLine("플레이어 소멸자"); //삭제
        }

        public void Attck()
        {

        }

        public void Move()
        {
            Console.WriteLine("플레이어가 이동한다");
        }
               

        public void GetGold()
        { 
        
        }


    }

}
