namespace Diagram.Algorithm.Types
{
    public class ValueProbability
    {
        /// <summary>
        /// Энтропия
        /// </summary>
        public double Entropy { get; set; }

        /// <summary>
        /// Прирост информации
        /// </summary>
        public double Gain { get; set; }
    }
}
