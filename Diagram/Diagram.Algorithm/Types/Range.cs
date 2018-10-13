namespace Diagram.Algorithm.Types
{
    public class Range
    {
        public dynamic Min { get; set; }
        public dynamic Max { get; set; }

        public Range(double min, double max)
        {
            Min = min;
            Max = max;
        }
    }
}
