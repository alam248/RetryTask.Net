using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryTask.Net
{
    public class RetryOptions
    {
        public int MaxRetries { get; set; } = 3;
        public Func<Exception, bool> ShouldRetry { get; set; } = ex => ex is TimeoutException;
        public Func<int, TimeSpan> DelayStrategy { get; set; } = _ => TimeSpan.FromSeconds(2);

        // Fluent API style to set retry options
        public RetryOptions SetMaxRetries(int retries)
        {
            MaxRetries = retries;
            return this;
        }

        public RetryOptions SetDelayStrategy(Func<int, TimeSpan> delayStrategy)
        {
            DelayStrategy = delayStrategy;
            return this;
        }

        public RetryOptions SetShouldRetry(Func<Exception, bool> shouldRetry)
        {
            ShouldRetry = shouldRetry;
            return this;
        }
    }
}
