using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Applications.Manage_Test_Types
{
    public partial class frmManageTestTypes : Form
    {

        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        //Functions
        private void _refreshTestTypesData()
        {
            dgvMangeTestTypes.DataSource = clsTestTypesBusinessLayer.GetAllTestTypes();
        }
        private void _rowsCounter()
        {
            lblRecordsNumber.Text = dgvMangeTestTypes.RowCount.ToString();
        }
        private void _LoadManageTestTypesForm()
        {
            _refreshTestTypesData();
            _rowsCounter();
        }
        private void _closeManageTestTypesForm()
        {
            this.Close();
        }
        private void _showEditTestTypesForm()
        {
            int TestTypeID = Convert.ToInt32(dgvMangeTestTypes.CurrentRow.Cells[0].Value);
            frmUpdateTestTypes UpdateTestTypes = new frmUpdateTestTypes(TestTypeID);
            UpdateTestTypes.refreshManageTestTypeData += _refreshTestTypesData;
            UpdateTestTypes.ShowDialog();
        }
        //Buttons
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadManageTestTypesForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _closeManageTestTypesForm();
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showEditTestTypesForm();
        }
    }
}
