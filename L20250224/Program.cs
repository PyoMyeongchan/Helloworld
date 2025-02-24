namespace L20250224
{

    class BitArray32
    {

        public uint Data;

        public void Set(int position)
        {
            if (position > 0 && position <= 32)
            {
                Data = Data | (uint)(1 << position - 1);
            }
        }

        public void Unset(int position)
        {
            if (position > 0 && position <= 32)
            {
                Data = Data & ~(uint)(1 << position - 1);
            }
        }

        public bool Check(uint other)
        { 
            return (int)(Data & other) > 0 ? true : false;
        
        }
    
    }


    //if문 대체 가능
    internal class Program
    {
        

        static void Main(string[] args)
        {
            BitArray32 bitArray32 = new BitArray32();
            
            //0101
            bitArray32.Set(3);
            bitArray32.Set(1);
            bitArray32.Unset(3);
            Console.WriteLine(Convert.ToString(bitArray32.Data, 2));
            


            byte a = 0; // 0000 0010
            a = 1 << 1;

            int b = 256; // 00000000 00000000 00000001 00000000
            b = b >> 1;

            //<<    shift 연산자
            //>>

            //0101
            //0110 & (논리곱), and
            //0100

            //0001
            //0001 | (논리합) 둘중 하나라도 1이면 1이다
            //0001

            //0001 ~ 부정
            //1110

            //0101
            //0011 ^ XOR
            //0100

            //0000 0000 -> 16진수
            //F    F    -> Color
            //0xFF
            //255
            //111 = 7 /1111 = 15

            int R = 255;
            R = 0xFF;
            R = 0b11111111;

            //network -> ByteOrder
            //계산기 - 프로그래머 많이 만져보기
            //비트연산 - 유니티에서는 주로 레이어

            int player = 1; //=> 0b0000 0001
            int camera = 2; //=> 0b0000 0010
            byte UI = 4;    //=> 0b0000 0100
            byte Water = 8; //=> 0b0000 1000
            
            //player
            byte playerlayer = 0b00000000;
                         //=> 0b0000001 |
                         //=> 0b0000011
            playerlayer = (byte)(playerlayer | player);

            //bit masking - 스텐실과 원리 같다!
            if ((playerlayer & (camera |player)) > (uint)0)
            { 
            
            
            }
            //uint = -는하지않은 32자리
            
            //유니티 카메라 culling mask - 레이어 설정하여 보여지고싶은거만 보이게 가능
            //유니티는 기본 단위 1m
            //업그레이드 = 상속!


            Console.WriteLine(a);
            Console.WriteLine(Convert.ToString(b,2));
        }
    }
}
