using Diagram.Algorithm.Types;
using System.Collections.Generic;
using System.Linq;

namespace Diagram.Algorithm.Algorithm.Classification
{
    public class RequestAttribute : BaseAttribute
    {
        #region Field

        public override string Name => "Заявления";

        protected override Range[] Ranges
        {
            get
            {
                var request = DataAnalysis.Select(item => item.Request);
                return AttributeHelper.CalcRanges(request.Min(), request.Max(), 2);
            }
        }

        public override ValueProbability Probability => ValueProbability();

        #endregion

        public RequestAttribute(List<AnalysisClassification> dataAnalysis) : base(dataAnalysis)
        {
        }

        public RequestAttribute()
        {
        }

        public override void SetValues(List<AnalysisClassification> inputData = null)
        {
            if (inputData == null)
                inputData = DataAnalysis;

            foreach (var range in Ranges)
            {
                var valueAnalysisSpecialties = inputData
                    .Where(item => item.Request >= range.Min && item.Request <= range.Max)
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

        public ValueProbability ValueProbability()
        {
            var listParameters = new List<List<AnalysisClassification>>();
            foreach (var range in Ranges)
            {
                listParameters.Add(
                    DataAnalysis
                        .Where(item => item.Request >= range.Min && item.Request <= range.Max)
                        .ToList());
            }
            var request = DataAnalysis.Select(item => item.Request);
            return AttributeHelper.CalcValueProbability(request.Count(), listParameters.ToArray());
        }

        public override BaseAttribute Clone()
        {
            return new RequestAttribute(DataAnalysis);
        }
    }
}
