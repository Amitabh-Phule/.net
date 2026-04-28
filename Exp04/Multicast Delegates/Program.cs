using System;

namespace Multicast_Delegates
{
    internal class Program
    {
        // Delegate
        public delegate void ResultDelegate(int m1, int m2, int m3);

        public static void CalculateTotal(int m1, int m2, int m3)
        {
            int total = m1 + m2 + m3;
            Console.WriteLine("Total Marks: " + total);
        }

        public static void CalculatePercentage(int m1, int m2, int m3)
        {
            double percentage = (m1 + m2 + m3) / 3.0;
            Console.WriteLine("Percentage: " + percentage + "%");
        }

        public static void DisplayGrade(int m1, int m2, int m3)
        {
            double percentage = (m1 + m2 + m3) / 3.0;

            if (percentage >= 75)
                Console.WriteLine("Grade: A");
            else if (percentage >= 60)
                Console.WriteLine("Grade: B");
            else if (percentage >= 40)
                Console.WriteLine("Grade: C");
            else
                Console.WriteLine("Grade: Fail");
        }

        static void Main(string[] args)
        {
            ResultDelegate result = null;

            // Multicasting
            result += CalculateTotal;
            result += CalculatePercentage;
            result += DisplayGrade;

            // Calling all methods
            result(80, 70, 90);

            Console.ReadLine();
        }
    }
}