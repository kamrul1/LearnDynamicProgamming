using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Example2_GridTraveler
{
    public class GridTravellerTest
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 3)]
        [InlineData(3, 2, 3)]
        [InlineData(3, 3, 6)]
        [InlineData(18, 18, 2333606220)]
        public void ShouldReturnTwoWayFOrTwoByTwo(int x, int y, long expectedWays)
        {
            var gt = new GridTraveller(x, y);

            var result = gt.GetNumberOfWays();

            Assert.Equal(expectedWays, result);
        }
    }
}
