using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RetryTask.Net
{
    public static class Retry
    {
        // Execute a synchronous operation with retry logic
        public static void Execute(Action operation, RetryOptions options)
        {
            int attempt = 0;
            while (attempt < options.MaxRetries)
            {
                try
                {
                    operation();
                    return; // Success, exit the method
                }
                catch (Exception ex) when (options.ShouldRetry(ex))
                {
                    attempt++;
                    if (attempt >= options.MaxRetries) throw;
                    Console.WriteLine($"Retry {attempt}/{options.MaxRetries} failed. Retrying in {options.DelayStrategy(attempt)}...");
                    Thread.Sleep(options.DelayStrategy(attempt));
                }
            }
        }

        // Execute an asynchronous operation with retry logic
        public static async Task ExecuteAsync(Func<Task> operation, RetryOptions options)
        {
            int attempt = 0;
            while (attempt < options.MaxRetries)
            {
                try
                {
                    await operation();
                    return; // Success, exit the method
                }
                catch (Exception ex) when (options.ShouldRetry(ex))
                {
                    attempt++;
                    if (attempt >= options.MaxRetries) throw;
                    Console.WriteLine($"Retry {attempt}/{options.MaxRetries} failed. Retrying in {options.DelayStrategy(attempt)}...");
                    await Task.Delay(options.DelayStrategy(attempt));
                }
            }
        }
    }
}
