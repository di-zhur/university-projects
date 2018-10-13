using Diagram.Algorithm.Algorithm;
using System.Collections.Generic;

namespace Diagram.Algorithm
{
    public class AlgorithmCreator
    {
        private BaseAlgorithm _baseAlgorithm;

        public AlgorithmCreator(BaseAlgorithm baseAlgorithm)
        {
            _baseAlgorithm = baseAlgorithm;
        }

        public void Make(IDictionary<string, string> parameters = null)
        {
            _baseAlgorithm.Execute(parameters);
        }
    }
}
