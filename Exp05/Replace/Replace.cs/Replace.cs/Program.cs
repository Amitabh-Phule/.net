//Replace thread.sleep with task.delay and observe behavior

using System;
using System.Threading.Tasks;

namespace Exp05_C_Replace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Program Started");

            await Method1();
            await Method2();

            Console.WriteLine("Program Finished");
            Console.ReadLine();
        }

        static async Task Method1()
        {
            Console.WriteLine("Method1 Started");
            await Task.Delay(3000);   // Replaces Thread.Sleep(3000)
            Console.WriteLine("Method1 Completed");
        }

        static async Task Method2()
        {
            Console.WriteLine("Method2 Started");
            await Task.Delay(2000);   // Replaces Thread.Sleep(2000)
            Console.WriteLine("Method2 Completed");
        }
    }
}