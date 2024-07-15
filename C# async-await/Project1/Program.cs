//basic c# async program


using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Task longTask = LongProcess();

        Task shortTask = ShortProcess();

        //wait until both tasks are completed
        await Task.WhenAll(longTask, shortTask);

        System.Console.WriteLine("All tasks completed");
    }

    public static async Task LongProcess()
    {
        System.Console.WriteLine("Long started");    //sync

        await Task.Run(async ()=>        //starts new async task on a seperate thread
        {
            for(int i=0;i<5;i++)
            {
                System.Console.WriteLine("Long process running");
                await Task.Delay(100);
            }
        });

        System.Console.WriteLine("Long completed");
    }

    static async Task ShortProcess()
    {
        System.Console.WriteLine("Short started");

        await Task.Run(async ()=>
        {
            for(int i=0;i<5;i++)
            {
                System.Console.WriteLine("Short process running");
                await Task.Delay(100);
            }
        });

        System.Console.WriteLine("Short completed");
    }
}