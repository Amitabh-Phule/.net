using System;

namespace ArithmaticOperation
{
    class Calculator
    {
        delegate double ArithmaticDelegate(double x, double y);

        static void Menu()
        {
            Console.WriteLine("Select an arithmatic operation");
            Console.WriteLine("1) Addition");
            Console.WriteLine("2) Subtraction");
            Console.WriteLine("3) Multiplication");
            Console.WriteLine("4) Division");
            Console.WriteLine("5) Remainder");
            Console.WriteLine("6) Quit");
        }

        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b) => a / b;
        static double Modulus(double a, double b) => a % b;

        static void Main(string[] args)
        {
            int operation;
            ArithmaticDelegate arithmatic = null;
            double x, y;

            do
            {
                Menu();
                operation = int.Parse(Console.ReadLine());

                if (operation == 6)
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                Console.WriteLine("Enter first number:");
                x = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter second number:");
                y = double.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        arithmatic = Add;
                        break;
                    case 2:
                        arithmatic = Subtract;
                        break;
                    case 3:
                        arithmatic = Multiply;
                        break;
                    case 4:
                        if (y == 0)
                        {
                            Console.WriteLine("Cannot divide by zero!");
                            continue;
                        }
                        arithmatic = Divide;
                        break;
                    case 5:
                        arithmatic = Modulus;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        continue;
                }

                Console.WriteLine("Result: " + arithmatic(x, y));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            } while (true);
        }
    }
}