using System;
using Xunit;

using System.Linq;
using System.Collections.Generic;

namespace Example3_CanSum
{
    public class CanSum
    {
        private readonly int targetSum;
        private readonly int[] numbers;
        private readonly Dictionary<int, bool> valuePairs;

        public CanSum(int targetSum,  int[] numbers, Dictionary<int, bool> valuePairs = null)
        {
            this.targetSum = targetSum;
            this.numbers = numbers;
            this.valuePairs = 
                valuePairs is null?
                    new Dictionary<int, bool>():valuePairs;
        }

        internal bool IsSum()
        {
            if (valuePairs.TryGetValue(targetSum, out bool previousBool))
            {
                return previousBool;
            }

            if (targetSum == 0)
            {
                return true;
            }

            if (targetSum < 0)
            {
                return false;
            }

            foreach (var number in numbers)
            {
                var remainder  = targetSum - number;
                var nodeIsSum = new CanSum(remainder, numbers, valuePairs).IsSum();
                if (nodeIsSum)
                {
                    valuePairs[targetSum] = true;
                    return true;
                }
            }


            valuePairs[targetSum] = false;
            return false;
        }
    }
}
