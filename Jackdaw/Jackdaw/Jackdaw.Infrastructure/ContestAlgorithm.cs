using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jackdaw.Infrastructure
{
    public interface IContestAlgorithm
    {
        Dictionary<int, float> Execute(int nominationId, List<ParameterAlgorithm> parameterAlgorithms);
    }

    public class ContestAlgorithm : IContestAlgorithm
    {
        /// <summary>
        /// Вес
        /// </summary>
        private const double _weightLanguage = 1;
        private const double _weightPhonetic = 0.9;
        private const double _weightIntonation = 0.8;

        /// <summary>
        ///  Dictionary<int, double> int - ParticipantId; double - Mark
        /// </summary>
        /// <param name="nominationId"></param>
        /// <param name="parameterAlgorithms"></param>
        /// <returns></returns>
        public Dictionary<int, float> Execute(int nominationId, List<ParameterAlgorithm> parameterAlgorithms)
        {
            var dataGroupC = parameterAlgorithms.Select(o => o.Marks.GroupC);
            var maxC = dataGroupC.Max();
            var minC = dataGroupC.Min();
            var ratioC = maxC - minC;
            var dataResult = new Dictionary<int, float>();
   
            foreach (var item in parameterAlgorithms)
            {
                var markC = (maxC - item.Marks.GroupC) * 10 / ratioC;
                var groupB = item.Marks.GroupB;
                var subgroupLanguage = groupB.SubgroupLanguage.Sum() * _weightLanguage;
                var subgroupIntonation = groupB.SubgroupIntonation.Sum() * _weightIntonation;
                var subgroupPhonetic = groupB.SubgroupPhonetic.Sum() * _weightPhonetic;
                var markB = subgroupLanguage + subgroupIntonation + subgroupPhonetic;

                var mark = markC + item.Marks.GroupA + markB;
                dataResult.Add(item.ParticipantId, (float)Math.Round(mark, 2));
            }

            return dataResult;
        }
    }

    public class ParameterAlgorithm
    {
        public int ParticipantId { get; set; }
        public Criterion Marks { get; set; }
    }

    /// <summary>
    /// Критерии
    /// </summary>
    public class Criterion
    {
        public int GroupA { get; set; }
        public int GroupC { get; set; }
        public SubgroupB GroupB { get; set; }
    }

    public class SubgroupB
    {
        public List<int> SubgroupLanguage { get; set; }
        public List<int> SubgroupPhonetic { get; set; }
        public List<int> SubgroupIntonation { get; set; }
    }
}
