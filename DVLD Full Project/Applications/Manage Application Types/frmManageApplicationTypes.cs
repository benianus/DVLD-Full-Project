using clsBusinessLayer;
using DVLD_Full_Project.Applications.ManageApplicationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Applications
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        //Functions
        private void _RefreshApplicationTypesData()
        {
            dgvMangeApplicationTypes.DataSource = clsApplicationsTypesBusinessLayer.GetAllApplicationTypes();
        }
        private void _RowsCounter()
        {
            lblRecordsNumber.Text = dgvMangeApplicationTypes.RowCount.ToString();
        }
        private void _CloseManageApplicationTypesFomr()
        {
            this.Close();
        }
        private void _showUpdateApplicationTypeForm()
        {
            int ApplicationTypeID = Convert.ToInt32(dgvMangeApplicationTypes.CurrentRow.Cells[0].Value);
            frmUpdateApplicationType updateApplicationType = new frmUpdateApplicationType(ApplicationTypeID);

            //refresh data after update and save application type infos;
            updateApplicationType.RefreshManageApplicationTypeData += _RefreshApplicationTypesData;

            updateApplicationType.ShowDialog();
        }

        //Buttons
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesData();
            _RowsCounter();
        }

        
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showUpdateApplicationTypeForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseManageApplicationTypesFomr();
        }
    }
}
