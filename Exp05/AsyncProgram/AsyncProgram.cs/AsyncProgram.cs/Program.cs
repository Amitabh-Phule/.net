//Covert to Async way
using System;
using System.Threading.Tasks;

namespace Exp05_B_Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();   // Call async method
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Program Started");

            await Method1();
            await Method2();
            await Method3();

            Console.WriteLine("Program Finished");
            Console.ReadLine();
        }

        static async Task Method1()
        {
            Console.WriteLine("Method 1 Execution Started");
            await Task.Delay(2000);   // Non-blocking delay
            Console.WriteLine("Method 1 Execution Completed");
        }

        static async Task Method2()
        {
            Console.WriteLine("Method 2 Execution Started");
            await Task.Delay(2000);
            Console.WriteLine("Method 2 Execution Completed");
        }

        static async Task Method3()
        {
            Console.WriteLine("Method 3 Execution Started");
            await Task.Delay(2000);
            Console.WriteLine("Method 3 Execution Completed");
        }
    }
}