using Delta.DataAccess;
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

namespace Delta.UI.Forms
{
    public partial class UpdateForm : Form
    {
        private Frecast _frecast;
        private IUnitOfWork _unitOfWork;
        private MainForm _mainForm;

        public UpdateForm(MainForm mainForm, Guid frecastId)
        {
            _mainForm = mainForm;
            _unitOfWork = DependenceContainer.GetDependenceContainer.Resolve<IUnitOfWork>();
            _frecast = _unitOfWork.FrecastRepository.GetWhere(o => o.Id == frecastId)?.FirstOrDefault();
            InitializeComponent();
            InitDataForm();
        }

        private void InitDataForm()
        {
            teName.Text = _frecast.Name;
            teOwner.Text = _frecast.Owner;
            teDescription.Text = _frecast.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_frecast != null)
            {
                _frecast.Name = teName.Text;
                _frecast.Owner = teOwner.Text;
                _frecast.Description = teDescription.Text;
                _unitOfWork.FrecastRepository.Update(_frecast);
                _mainForm.RefreshGridFrecast();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
