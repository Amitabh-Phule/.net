//Create the Method returning task
using System;
using System.Threading.Tasks;

namespace Exp05_D_MethodReturningTask
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

            await MyMethod();   // Calling method that returns Task

            Console.WriteLine("Program Finished");
            Console.ReadLine();
        }

        static async Task MyMethod()
        {
            Console.WriteLine("MyMethod Started");
            await Task.Delay(2000);   // Simulate some work
            Console.WriteLine("MyMethod Completed");
        }
    }
}