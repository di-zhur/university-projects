using Delta.DataAccess;
using Delta.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using System.Collections;
using DevExpress.XtraCharts;
using System.Threading;

namespace Delta.UI.Forms
{
    public partial class ResultForm : Form
    {
        private const string SeriesName1 = "Расходы";
        private const string SeriesName2 = "В том числе: расходы трансферты";
        private const string SeriesName3 = "Доходы";
        private const string SeriesName4 = "В том числе: доходы трансферты";
        private const string SeriesName5 = "Дефицит (-), Профицит (+)";
        private Guid _frecastId;

        public ResultForm(Guid frecastId)
        {
            _frecastId = frecastId;
            InitializeComponent();
            DataInit();
        }

        private void DataInit()
        {
            var viewDataAdapter = new ViewDataAdapter();
            var result = viewDataAdapter.GetFrecastResultView(_frecastId);
            var data = viewDataAdapter.GetFrecastDataView(_frecastId);
            gridData.DataSource = data.SeriesValues.OrderBy(o => o.Date);
            gridResult.DataSource = result.SeriesValues.OrderBy(o => o.Date);
            gridData.MainView.PopulateColumns();
            gridResult.MainView.PopulateColumns();
            label1.Text = $"Относительная ошибка прогноза: {result.ErrorFirst}";
            label2.Text = $"Средняя относительная ошибка прогноза: {result.ErrorSecond}%";
            var points = data.SeriesValues;
            points.AddRange(result.SeriesValues);
            BuildGraphics(points);
        }


        private void BuildGraphics(List<FrecastSeries> points)
        {
            var expensesSeries = points.CreateSeriesLine((e) => new SeriesPoint(e.Date, e.Expenses), SeriesName1); 
            var expensesTransfersSeries = points.CreateSeriesLine((e) => new SeriesPoint(e.Date, e.ExpensesTransfers), SeriesName2);
            var incomeSeries = points.CreateSeriesLine((e) => new SeriesPoint(e.Date, e.Income), SeriesName3);
            var incomeTransfersSeries = points.CreateSeriesLine((e) => new SeriesPoint(e.Date, e.IncomeTransfers), SeriesName4);
            var ratioSeries = points.CreateSeriesLine((e) => new SeriesPoint(e.Date, e.Ratio), SeriesName5);

            chartResult.Series.AddRange(new Series[] { expensesSeries, incomeSeries, expensesTransfersSeries,  incomeTransfersSeries, ratioSeries });
        }
    }

    #region Helper
    
    public static class HelperSeries
    {
        public static Series CreateSeriesLine(this List<FrecastSeries> points, Func<FrecastSeries, SeriesPoint> selector, string seriesName)
        {
            var seriesPoints = points.Select(selector).ToArray();
            var series = new Series(seriesName, ViewType.Line);
            series.Points.AddRange(seriesPoints);
            return series;
        }
    }

    #endregion
}
