namespace LSP
{

    using System;
    //base class
    class Bird
    {
        public virtual void Move()
        {
            Console.WriteLine("Bird moves");
        }
    }
    //derived class
    class Sparrow : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Sparrow flies");
        }
    }

    class Ostrich : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Ostrich walks");
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Bird b1 = new Sparrow();
                Bird b2 = new Ostrich();

                b1.Move();
                b2.Move();
            }
        }
    }
}
