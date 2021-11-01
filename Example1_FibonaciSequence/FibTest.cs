using System;
using Xunit;

namespace Example1_FibonaciSequence
{
    public class FibTest
    {
        [Theory]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(50, 12586269025)]
        public void ShouldReturnNthNumberFab(long input, long expected)
        {
            var result = new Fib(input).Value();

            Assert.Equal(expected, result);

        }
    }
}
