using Delta.DataAccess;
using Delta.UI.Forms;
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

namespace Delta.UI
{
    public partial class MainForm : Form
    {
        private Guid _currentFrecastId;
        private IUnitOfWork _unitOfWork;

        public MainForm()
        {
            InitializeComponent();
            _unitOfWork = DependenceContainer.GetDependenceContainer.Resolve<IUnitOfWork>();
            GridFrecastInit();
        }

        private void GridFrecastInit()
        {
            var viewDataAdapter = new ViewDataAdapter();
            gridFrecast.DataSource = viewDataAdapter.GetFrecastView();
            gridFrecast.MainView.PopulateColumns();
        }

        private void barBtnResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentFrecastId != Guid.Empty)
            {
                var form = new ResultForm(_currentFrecastId);
                form.Show();
            }
            
        }

        private void barBtnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new CreateForm(this);
            form.Show();
        }

        private void barBtnUpdateItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentFrecastId != Guid.Empty)
            {
                var form = new UpdateForm(this, _currentFrecastId);
                form.Show();
            }
        }

        private void gridFrecast_MouseDown(object sender, MouseEventArgs e)
        {
            Guid frecastId;
            var rowId = gridView1?.GetFocusedRowCellValue("Id")?.ToString();

            if (rowId == null)
            {
                _currentFrecastId = Guid.Empty;
                return;
            }

            if (Guid.TryParse(rowId, out frecastId))
            {
                _currentFrecastId = frecastId;
                BarBtnEnable(true);
            }
        }

        public void BarBtnEnable(bool flag)
        {
            barBtnDelItem.Enabled = flag;
            barBtnResult.Enabled = flag;
            barBtnUpdateItem.Enabled = flag;
        }

        public void RefreshGridFrecast()
        {
            GridFrecastInit();
        }

        private void barBtnRefreshGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridFrecastInit();
        }

        private void barBtnDelItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frecast = _unitOfWork.FrecastRepository.GetWhere(o => o.Id == _currentFrecastId)?.FirstOrDefault();
            if (frecast != null)
            {
                _unitOfWork.FrecastRepository.Remove(frecast);
                _currentFrecastId = Guid.Empty;
                GridFrecastInit();
                BarBtnEnable(false);
            }
        }
    }
}
