using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Example3_CanSum
{
    public class CanSumTest
    {
        [Theory]
        [InlineData(6, new int[] { 1, 2, 3 })]
        [InlineData(7, new int[] { 5, 3, 4,7 })]
        [InlineData(7, new int[] { 5, 3, 4})]
        public void ShouldReturnArrayCanSumTrue(
            int targetSum, int[] numbers)
        {

            var canBeSummed = 
                new CanSum(targetSum, numbers).IsSum();

            Assert.True(canBeSummed);

        }

        [Fact]
        public void ShouldReturnArrayCanSumFalse()
        {
            var numbers = new int[] { 7, 14 };
            var targetSum = 300;

            var canBeSummed = new CanSum(targetSum, numbers).IsSum();

            Assert.False(canBeSummed);

        }
    }
}
