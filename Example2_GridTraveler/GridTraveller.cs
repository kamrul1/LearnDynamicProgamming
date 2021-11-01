using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Example2_GridTraveler
{
    public class Coord 
    {
        protected readonly int x;
        protected readonly int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            var otherCoord = obj as Coord;

            if (otherCoord.x == this.x && otherCoord.y == this.y)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }

    public class GridTraveller
    {
        private readonly int x;
        private readonly int y;
        private readonly Dictionary<Coord, long> knownPairs;

        public GridTraveller(int x, int y, Dictionary<Coord, long> knownPairs = null)
        {
            this.x = x;
            this.y = y;
            this.knownPairs = 
                   knownPairs is null? 
                    new Dictionary<Coord, long>(): knownPairs;
        }

        public long GetNumberOfWays()
        {
            if(knownPairs.TryGetValue(new Coord(x,y), out long value))
            {
                return value;
            }

            if (x == 0 || y==0)
            {
                return 0;
            }

            if(x==1 && y == 1)
            {
                return 1;
            }

            var newValue =  
                new GridTraveller(x - 1, y, knownPairs).GetNumberOfWays() 
                + new GridTraveller(x, y - 1, knownPairs).GetNumberOfWays();

            knownPairs.Add(new Coord(x, y), newValue);

            return newValue;


        }
    }
}
