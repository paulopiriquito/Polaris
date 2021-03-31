namespace Polaris.Domain.Entities.Quantifiers
{
    public class Priority
    {
        public Priority(int value)
        {
            if (value >= 0 && value <= MaximumPriority)
            {
                Value = value;
            }
        }

        private const int MaximumPriority = 4;
        
        public int Value { get; set; }
    }
}