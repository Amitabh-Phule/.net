using System;
using System.Thinking.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Start");
        await LongTask();
        Console.WriteLIne("End");
    }
    {
        Console.WriteLine("Long Task Started");
        await Task.Delay(3000);
        Console.WriteLine("Long Task Completed");

    }
}