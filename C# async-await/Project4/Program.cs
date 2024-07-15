//Exception Handling 2


using System;
using System.Threading.Tasks;

class Test
{
    public static async Task ExceptionAsync(){
        try
        {
            await Task.Run(() =>
            {
                throw new InvalidOperationException("An exception occurred.");
            });
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Caught InvalidOperationException: " + ex.Message);
        }
    }

    public async void Call(){
        try
        {
            await ExceptionAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
class Program
{
    public static void Main(String [] args)
    {
        Test test1 = new Test();
        test1.Call();
        Console.ReadLine();
    }
}
