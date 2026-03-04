using System;

namespace ArithmeticOp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Addition: " + (a + b));
            Console.WriteLine("Subtraction: " + (a - b));
            Console.WriteLine("Multiplication: " + (a * b));

            if (b != 0)
            {
                Console.WriteLine("Division: " + (a / b));
                Console.WriteLine("Modulus: " + (a % b));
            }
            else
            {
                Console.WriteLine("Division and Modulus not possible (division by zero).");
            }
        }
    }
}