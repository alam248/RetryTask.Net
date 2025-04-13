using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryTask.Net
{
    public static class Delay
    {
        public static Func<int, TimeSpan> Fixed(TimeSpan delay)
        {
            return attempt => delay;
        }

        public static Func<int, TimeSpan> Exponential()
        {
            return attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)); // 2^attempt seconds delay
        }
    }
}
