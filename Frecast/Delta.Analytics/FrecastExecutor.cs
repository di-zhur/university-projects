using Delta.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.Analytics
{
    public class FrecastExecutor : IFrecastExecutor
    {
        private int _step;
        private List<FrecastSeries> _frecastData;
        private List<FrecastSeries> _result;

        public FrecastExecutor(int step, List<FrecastSeries> frecastData)
        {
            _step = step;
            _frecastData = frecastData;
        }

        public void Do()
        {
            var expenses = _frecastData.Select(o => o.Expenses).ToList();
            var expensesTransfers = _frecastData.Select(o => o.ExpensesTransfers).ToList();
            var incomes = _frecastData.Select(o => o.Income).ToList();
            var incomeTransfers = _frecastData.Select(o => o.IncomeTransfers).ToList();
            var ratios = _frecastData.Select(o => o.Ratio).ToList();

            var calcExpenses = MovingAverage(expenses);
            var calcExpensesTransfers = MovingAverage(expensesTransfers);
            var calcIncomes = MovingAverage(incomes);
            var calcIncomeTransfers = MovingAverage(incomeTransfers);
            var calcRatios = MovingAverage(ratios);

            var index = _frecastData.Count();
            var length = _frecastData.Count + _step;
            var date = _frecastData.Select(o => o.Date).Max();
            var numberMounth = 1;
            _result = new List<FrecastSeries>();

            for (var i = index; i < length; i++)
            {
                _result.Add(new FrecastSeries()
                {
                    Date = date.AddMonths(numberMounth),
                    Income = calcIncomes.ElementAt(i),
                    IncomeTransfers = calcIncomeTransfers.ElementAt(i),
                    Expenses = calcExpenses.ElementAt(i),
                    ExpensesTransfers = calcExpensesTransfers.ElementAt(i),
                    Ratio = calcRatios.ElementAt(i)
                });
                numberMounth++;
            }
        }

        /// <summary>
        /// Алгоритм метода скользящей средней
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<double> MovingAverage(List<double> values) 
        {
            var mList = new List<double>();
            //Подготовка
            var len = values.Count - 2;
            for (var i = 0; i < len; i++)
            {
                var m = values.Skip(i).Take(_step).Sum() / _step;
                mList.Add(m);
            }
            //Расчет с шагом
            for (var i = 0; i < _step; i++)
            {
                var count = values.Count();
                var curData = values.ElementAt(count - 1);
                var prevData = values.ElementAt(count - 2);

                var prevM = mList.Last();
                var value = prevM + ((curData - prevData) / _step);
                values.Add(Math.Round(value, 1));

                var m = values.Skip(values.Count() - _step).Sum() / _step;
                mList.Add(m);
            }

            return values;
        }

        public List<FrecastSeries> GetResult()
        {
            return _result;
        }
    }
}
