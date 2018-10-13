using Diagram.Algorithm.Types;
using System;
using System.Collections.Generic;

namespace Diagram.Algorithm.Algorithm.Classification
{
    public static class AttributeHelper
    {
        public static ValueProbability CalcValueProbability(int count, params List<AnalysisClassification>[] attrs)
        {
            var entropySum = 0.0;
            var valueProbability = new ValueProbability();
            foreach (var attr in attrs)
            {
                var p = (double)attr.Count / (double)count;
                var s = p != 0 ? -p * Math.Log(p, 2) : 0;
                valueProbability.Entropy += s;
                entropySum += p * s;
            }
            valueProbability.Gain = valueProbability.Entropy - entropySum;
            return valueProbability;
        }

        public static Range[] CalcRanges(double min, double max, int countGroup)
        {
            var step = (max - min) / countGroup;
            var ranges = new List<Range>();
            for (int i = 0; i < countGroup; i++)
            {
                var range = new Range(min + step * i, min + step * (i + 1));
                ranges.Add(range);
            }
            return ranges.ToArray();
        }
    }
}
