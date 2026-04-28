using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start");

        Console.WriteLine("Task Started...");
        Thread.Sleep(3000); // Blocking
        Console.WriteLine("Task Completed");

        Console.WriteLine("End");
    }
}