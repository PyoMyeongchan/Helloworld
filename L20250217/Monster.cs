using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Monster : GameObject
    {
        private Random rand = new Random();

        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }


        //몬스터의 AI와 같다. 게임AI와 머신러닝AI(ChatGPT)는 완전 다르다.
        public override void Update()
        {
            //33ms 사운드 입력처리 효과 UI AI(미리 만들어 놓은 로직, 패턴)
            //시야(RayCasting)
            //사운드
            //기획 / 패턴이 들어간다.
            int Direction = rand.Next(0,4);

            if (Direction == 0)
            {
                Y--;
            }
            if (Direction == 1)
            {
                Y++;
            }
            if (Direction == 2)
            {
                X--;
            }
            if (Direction == 3)
            {
                X++;
            }
        }


    }
}
