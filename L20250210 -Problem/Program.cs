namespace Problem
{

    public class World
    {


        public Wall[] walls;

        public Floor[] floors;

        public Player players;

        public Monster[] monsters;

        public Goal goals;
        
    }

    public class Wall
    {
        public Wall()
        {
        }
        public void Notpass()
        {


        }
        ~Wall() 
        { 
        }


    }

    public class Floor
    {

    }

    public class Player
    {
        public Player()
        {
        }

        public void PlayerMove()
        {

        }

        ~Player()
        {
        }
    }

    public class Monster
    {
        public Monster()
        {
        }
        public void MonsterMove()
        {

        }

        ~Monster()
        {

        }
    }

    public class Goal
    {
        public Goal()
        {
        }
        public bool IsFinish(Player player)
        {
            return true;
        }

        public void goal()
        {


        }
        ~Goal()
        {

        }




    }
    internal class Program
    {
        static void Main(string[] args)
        {
            World world = new World();
        }
    }
}
