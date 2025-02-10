namespace image
{
    public class Image
    {
        //생성자 - class를 만들어달라고하면 자동으로 호출됨, class와 이름 동일해야함.
        public Image()
        { 
            X= 0;
            Y = 0;
            R = 255;
            G = 255;
            B = 255;
                    
        }
        //소멸자 
        ~Image() 
        { 
        
        }

        public int X;
        public int Y;
        public int R;
        public int G;
        public int B;
               

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Image[] images = new Image[14];
            images[0] = new Image();
            /*images[0].X = 0;
            images[0].Y = 0;
            images[0].R = 0;
            images[0].G = 0;
            images[0].B = 0;*/
        }



    }
}
