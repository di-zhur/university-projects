using Diagram.Algorithm.Types;
using System.Collections.Generic;
using System.Linq;

namespace Diagram.Algorithm.Algorithm.Classification
{
    public class PlacesAttribute : BaseAttribute
    {
        #region Field

        public override string Name => "Места";

        protected override Range[] Ranges
        {
            get
            {
                var places = DataAnalysis.Select(item => item.Places);
                return AttributeHelper.CalcRanges(places.Min(), places.Max(), 2);
            }
        }

        public override ValueProbability Probability => ValueProbability();

        #endregion

        public PlacesAttribute(List<AnalysisClassification> dataAnalysis) : base(dataAnalysis)
        {
        }

        public PlacesAttribute()
        {
        }
        
        public ValueProbability ValueProbability()
        {
            var listParameters = new List<List<AnalysisClassification>>();
            foreach (var range in Ranges)
            {
                listParameters.Add(
                    DataAnalysis
                        .Where(item => item.Places >= range.Min && item.Places <= range.Max)
                        .ToList());
            }
            var places = DataAnalysis.Select(item => item.Places);
            return AttributeHelper.CalcValueProbability(places.Count(), listParameters.ToArray());
        }

        public override void SetValues(List<AnalysisClassification> inputData = null)
        {
            if (inputData == null)
                inputData = DataAnalysis;

            foreach (var range in Ranges)
            {
                var valueAnalysisSpecialties = inputData
                    .Where(item => item.Places >= range.Min && item.Places <= range.Max)
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
            return new PlacesAttribute(DataAnalysis);
        }
    }
}
