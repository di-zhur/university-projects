using Diagram.Algorithm.Types;
using System.Collections.Generic;

namespace Diagram.Algorithm.Algorithm.Classification
{
    /// <summary>
    /// "Скелет для атрибутов аналитики при построении дерева решений"
    /// </summary>
    public abstract class BaseAttribute
    {
        /// <summary>
        /// Имя атрибута
        /// </summary>
        public abstract string Name { get; }
        
        /// <summary>
        /// Элементы каждого узла дерева
        /// </summary>
        public List<BaseAttribute> Elements = new List<BaseAttribute>();

        /// <summary>
        /// Данные узла
        /// </summary>
        public List<ValueAttribute> Values = new List<ValueAttribute>();

        /// <summary>
        /// Данные аналитики
        /// </summary>
        protected List<AnalysisClassification> DataAnalysis { get; }

        /// <summary>
        /// Диапазоны условий
        /// </summary>
        protected abstract Range[] Ranges { get; }

        /// <summary>
        /// Прирост информации и энтропия
        /// </summary>
        /// <returns></returns>
        public abstract ValueProbability Probability { get; }


        protected BaseAttribute(List<AnalysisClassification> dataAnalysis)
        {
            DataAnalysis = dataAnalysis;
        }

        protected BaseAttribute() { }
        
        /// <summary>
        /// Установить данные для узла
        /// </summary>
        /// <param name="inputData"></param>
        public abstract void SetValues(List<AnalysisClassification> inputData = null);

        /// <summary>
        /// Добавить атрибут
        /// </summary>
        /// <param name="attribute"></param>
        public virtual void Add(BaseAttribute attribute)
        {
            Elements.Add(attribute);
        }

        /// <summary>
        /// Прототип
        /// </summary>
        /// <returns></returns>
        public abstract BaseAttribute Clone();

    }
}
