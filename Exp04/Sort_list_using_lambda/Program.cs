using System;
using System.Collections.Generic;

namespace Sort_list_using_lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 5, 1, 9, 3, 7 };

            Console.WriteLine("Original List:");
            Console.WriteLine(string.Join(", ", numbers));

            // Ascending order
            numbers.Sort((a, b) => a.CompareTo(b));

            Console.WriteLine("\nSorted List (Ascending):");
            Console.WriteLine(string.Join(", ", numbers));

            // Descending order
            numbers.Sort((a, b) => b.CompareTo(a));

            Console.WriteLine("\nSorted List (Descending):");
            Console.WriteLine(string.Join(", ", numbers));

            Console.ReadLine();
        }
    }
}