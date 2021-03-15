using System;

namespace Polaris.Application.Entities.Quantifiers
{
    public class BangForBuck
    {
        public BangForBuck(double value)
        {
            var rounded = Math.Round(value, 0);
            if (rounded > LowerBound && rounded <= UpperBound)
            {
                Value = (int) rounded;
            }
        }

        private static int LowerBound { get; } = 0;
        private static int UpperBound { get; } = 10;
        
        public int Value { get; }
    }
}