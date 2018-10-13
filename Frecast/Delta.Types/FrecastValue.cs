using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.Types
{
    public class FrecastValue
    {
       
        public double ErrorFirst { get; set; }

        public double ErrorSecond { get; set; }

        public List<FrecastSeries> SeriesValues { get; set; }
    }

    public class FrecastSeries
    {
        /// <summary>
        /// Дата
        /// </summary>
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Доход
        /// </summary>
        [DisplayName("Доход")]
        public double Income { get; set; }

        [DisplayName("В том числе: доходы трансферты")]
        public double IncomeTransfers { get; set; }

        /// <summary>
        /// Расход
        /// </summary>
        [DisplayName("Расход")]
        public double Expenses { get; set; }

        [DisplayName("В том числе: расходы трансферты")]
        public double ExpensesTransfers { get; set; }

        /// <summary>
        /// Отношение
        /// </summary>
        [DisplayName("Дефицит (-), Профицит (+)")]
        public double Ratio { get; set; }
    }
}

