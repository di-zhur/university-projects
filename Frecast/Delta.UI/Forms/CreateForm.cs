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
using Delta.Types;
using Delta.DataAccess;
using Delta.UI.Helpers;
using Newtonsoft.Json;
using Delta.Analytics;

namespace Delta.UI.Forms
{
    public partial class CreateForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private FrecastValue _frecastValue = new FrecastValue();
        private Guid _frecastId = Guid.NewGuid();
        private MainForm _mainForm;
        private AreaExcel _areaExcelValue = new AreaExcel() { StartColumn = 0, StartRow = 3, EndColumn = 6, EndRow = 15 };

        public CreateForm(MainForm mainForm)
        {
            _unitOfWork = DependenceContainer.GetDependenceContainer.Resolve<IUnitOfWork>();
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void btnDataLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var pathFile = openFileDialog1.FileName;
                _frecastValue.SeriesValues = ConverterHelper.ExcelToList<FrecastSeries> (_areaExcelValue, pathFile);
                cbDataLoad.Checked = true;
            }
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (_frecastValue.SeriesValues.Any())
            {
                //Добавляем прогноз
                var frecastRepository = _unitOfWork.FrecastRepository;
                var Data = JsonConvert.SerializeObject(_frecastValue);
                var frecast = frecastRepository.Insert(new Frecast()
                {
                    Id = _frecastId,
                    Name = teName.Text,
                    Owner = teOwner.Text,
                    Description = teDescription.Text,
                    Date = DateTime.Now,
                    FrecastStateId = FrecastStateType.Running,
                    FrecastData = new List<FrecastData>()
                    {
                       new FrecastData()
                       {
                           Id = Guid.NewGuid(),
                           FrecastId = _frecastId,
                           Data = JsonConvert.SerializeObject(_frecastValue)
                       }
                    }
                });

                //Запускаем расчет в отдельной Task
                var stepFrecast = int.Parse(teStep.Text);
                await ExecuteCalculationFrecast(stepFrecast, frecast);

                _mainForm.RefreshGridFrecast();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Валидация формы
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (teDescription.Text != string.Empty && teName.Text != string.Empty
                && teOwner.Text != string.Empty && teStep.Text != string.Empty
                && cbDataLoad.Checked)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Заполните поля формы и загрузите данные!");
                return false;
            }
        }
        
        private Task ExecuteCalculationFrecast(int stepFrecast, Frecast frecast)
        {
            return Task.Run(() =>
            {
                var frecastExecutor = new FrecastExecutor(stepFrecast, _frecastValue.SeriesValues);
                frecastExecutor.Do();
                var result = frecastExecutor.GetResult();
                var frecastResultRepository = _unitOfWork.FrecastResultRepository;
                frecastResultRepository.Insert(new FrecastResult
                {
                    Id = Guid.NewGuid(),
                    Result = JsonConvert.SerializeObject(new FrecastValue()
                    {
                        SeriesValues = result
                    }),
                    FrecastId = _frecastId
                });

                frecast.FrecastStateId = FrecastStateType.Complete;
                var frecastRepository = _unitOfWork.FrecastRepository;
                frecastRepository.Update(frecast);
            });
        }

    }
}
