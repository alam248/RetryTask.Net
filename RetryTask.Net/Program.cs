using RetryTask.Net;
using System;
using System.Threading.Tasks;

namespace RetryTask.Net
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Smart Retry Utility - Starting operation...");

            var retryOptions = new RetryOptions()
                .SetMaxRetries(5)
                .SetDelayStrategy(Delay.Exponential())
                .SetShouldRetry(ex => ex is TimeoutException);

            // Synchronous example
            try
            {
                Retry.Execute(() =>
                {
                    SimulateOperation();
                }, retryOptions);
                Console.WriteLine("✅ Operation completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Operation failed: {ex.Message}");
            }

            // Asynchronous example
            try
            {
                await Retry.ExecuteAsync(async () =>
                {
                    await SimulateAsyncOperation();
                }, retryOptions);
                Console.WriteLine("✅ Async operation completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Async operation failed: {ex.Message}");
            }
        }

        static void SimulateOperation()
        {
            Console.WriteLine("Simulating operation...");
            var rand = new Random();
            if (rand.Next(0, 2) == 0) // Random failure
            {
                throw new TimeoutException("The operation timed out.");
            }
        }

        static async Task SimulateAsyncOperation()
        {
            Console.WriteLine("Simulating async operation...");
            var rand = new Random();
            if (rand.Next(0, 2) == 0) // Random failure
            {
                throw new TimeoutException("The operation timed out.");
            }
            await Task.Delay(1000); // Simulate async delay
        }
    }
}
