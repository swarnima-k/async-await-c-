//Exception Handling 1

using System;
using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            await DoAsync();
        }

        catch(Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    static async Task DoAsync()
    {
        throw new InvalidOperationException();
    }
}
