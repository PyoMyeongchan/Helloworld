namespace L20250217_Class_
{
    //공통기능은 부모에게, 특화기능은 자식에게

    class Monster
    {
        public virtual void Move()
        {
            Console.WriteLine("이동한다");
        }

    }

    class Slime : Monster
    {

        public override void Move()
        {
            Console.WriteLine("미끄러진다");

        }

        public void Sticky()
        {

            Console.WriteLine("끈적인다");
        }
    }

    class Goblin : Monster
    {

        public override void Move()
        {
            Console.WriteLine("뛰어다닌다");

        }

        public void Throw()
        {
            Console.WriteLine("던진다");

        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Monster[] monster = new Monster[3];
            monster[0] = new Slime();
            monster[1] = new Goblin();
            monster[2] = new Slime();

            //Down casting, 동적변환
            for (int i = 0; i < monster.Length; i++)
            {
                Slime s = monster[i] as Slime;
                if (s != null)
                {

                    s.Sticky();

                }

                Goblin g = monster[i] as Goblin;
                if (g!= null)
                {

                    g.Throw();

                }
            }
        }





    }
}
