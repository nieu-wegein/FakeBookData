using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBookData.Application.Tools
{
    public static class FunctionLooper
    {
        public static Func<T, T> LoopWithFloat<T>(Func<T, T> fn, float power, int seed)
        {
            var random = new Random(seed);

            return (T value) =>
            {
                var integer = Math.Floor(power);
                var fractional = Math.Round(power % 1, 1);

                for (int i = 0; i < integer; i++)
                    value = fn(value);

                value = random.NextSingle() >= fractional ? value : fn(value);
                return value;
            };
        }
    }
}
