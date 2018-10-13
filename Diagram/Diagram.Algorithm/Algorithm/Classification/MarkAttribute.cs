using Diagram.Algorithm.Types;
using System.Collections.Generic;
using System.Linq;

namespace Diagram.Algorithm.Algorithm.Classification
{
    public class MarkAttribute : BaseAttribute
    {
        #region Field
       
        public override string Name => "Баллы";

        protected override Range[] Ranges
        {
            get
            {
                var makrs = DataAnalysis.Select(item => item.Mark);
                return AttributeHelper.CalcRanges(makrs.Min(), makrs.Max(), 2);
            }
        }

        public override ValueProbability Probability => ValueProbability();


        #endregion

        public MarkAttribute(List<AnalysisClassification> dataAnalysis) : base(dataAnalysis)
        {
        }

        public MarkAttribute()
        {
        }

        private ValueProbability ValueProbability()
        {
            var listParameters = new List<List<AnalysisClassification>>();
            foreach (var range in Ranges)
            {
                listParameters.Add(
                    DataAnalysis
                        .Where(item => item.Mark >= range.Min && item.Mark <= range.Max)
                        .ToList());
            }
            var countMark = DataAnalysis.Select(item => item.Mark).Count();
            return AttributeHelper.CalcValueProbability(countMark, listParameters.ToArray());
        }

        public override void SetValues(List<AnalysisClassification> inputData = null)
        {
            if (inputData == null)
                inputData = DataAnalysis;

            foreach (var range in Ranges)
            {
                var valueAnalysisSpecialties = inputData
                    .Where(item => item.Mark >= range.Min && item.Mark <= range.Max)
                    .ToList();

                if (!valueAnalysisSpecialties.Any()) continue;

                var value = new ValueAttribute()
                {
                    Range = range,
                    AnalysisSpecialties = valueAnalysisSpecialties
                };

                Values.Add(value);
            }
        }

        public override BaseAttribute Clone()
        {
            return new MarkAttribute(DataAnalysis);
        }

    }
}
