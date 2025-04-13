**Smart Retry Utility**

A small C# library that simplifies retrying operations with configurable options like exponential backoff, retry counts, and custom exception handling.

**Features**

Exponential Backoff: Increase wait time with each retry.

Customizable Retry Logic: Configure how many retries, what exceptions to retry on, and how long to wait.

Supports Sync & Async: Can be used for both synchronous and asynchronous operations.

<pre>
var retryOptions = new RetryOptions()
    .SetMaxRetries(3)
    .SetDelayStrategy(Delay.Exponential())
    .SetShouldRetry(ex => ex is TimeoutException);

Retry.Execute(() =>
{
    SimulateOperation();
}, retryOptions);
</pre>
