// asynchronous programming 
// I/O bound and CPU bound operations


using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program2
{
    static async Task Main(string[] args)
    {
        // Start both I/O-bound and CPU-bound operations
        Task<string> fetchDataTask = FetchDataAsync();
        Task<int> computeTask = ComputeAsync();

        // Await both tasks
        await Task.WhenAll(fetchDataTask, computeTask);

        //store results
        string data = fetchDataTask.Result;
        int computationResult = computeTask.Result;

        // Display results
        Console.WriteLine("Fetched Data: " + data);
        await Task.Delay(1000); // Delay for 1 second
        Console.WriteLine("Computation Result: " + computationResult);
    }

    // I/O-bound operation
    public static async Task<string> FetchDataAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            System.Console.WriteLine("Started fetching data");

            //sends an HTTP GET request and saves response in data
            string data = await client.GetStringAsync("https://google.com");  
            System.Console.WriteLine("Fetching completed.");
            return data;
        }
    }

    // CPU-bound operation
    public static async Task<int> ComputeAsync()
    {
        return await Task.Run(() =>
        {
            System.Console.WriteLine("Started computation");

            int sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                sum += i;
            }

            System.Console.WriteLine("Computation completed.");

            return sum;
        });
    }
}
