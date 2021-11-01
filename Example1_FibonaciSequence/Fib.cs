using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1_FibonaciSequence
{
    public class Fib
    {
        private readonly long nthNo;
        private readonly Dictionary<long, long> knownFib;

        public Fib(long nthNo, Dictionary<long, long> knowFibValue = null)
        {
            this.nthNo = nthNo;

            if (knowFibValue is null)
            {
                knowFibValue = new();
            }

            this.knownFib = knowFibValue;

        }

        internal long Value()
        {
            if (knownFib.TryGetValue(nthNo, out long value))
            {
                return value;
            }

            if (nthNo <= 2)
            {
                return 1;
            }



            var newValue =  new Fib(nthNo - 1, knownFib).Value() + new Fib(nthNo - 2, knownFib).Value();

            knownFib.Add(nthNo, newValue);

            return newValue;
        }

    }
}
