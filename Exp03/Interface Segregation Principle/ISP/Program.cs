using System.Security.Cryptography;

namespace ISP
{

    interface IWork
    {
        void Work();
    }

    interface IEat
    {
        void Eat();
    }

    // Human can work and eat
    class Human : IWork, IEat
    {
        public void Work()
        {
            Console.WriteLine("Human working");
        }

        public void Eat()
        {
            Console.WriteLine("Human eating");
        }
    }

    // Robot only works
    class Robot : IWork
    {
        public void Work()
        {
            Console.WriteLine("Robot working");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IWork human = new Human();
            human.Work();

            IWork robot = new Robot();
            robot.Work();
        }
    }
}
