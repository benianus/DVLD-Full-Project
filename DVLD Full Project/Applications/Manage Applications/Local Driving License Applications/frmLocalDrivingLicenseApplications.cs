using clsBusinessLayer;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
using DVLD_Full_Project.Tests.Test_Appointements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Applications.Manage_Applications.Local_Driving_License_Applications
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        //functions
        private void _LoadLocalDrivingLicenseApplication()
        {

        }
        private void _RefreshLocalDrivingLicenseAppsData()
        {
            dgvLocalLicenseApplcations.DataSource = clsLocalDriverLicenseApplicationBusinessLayer.GetAllLocalDrivingLicenseApplications();
        }
        private void _RefreshLocalDrivingLicenseAppsData(DataTable ApplicationsTable)
        {
            dgvLocalLicenseApplcations.DataSource = ApplicationsTable;
        }
        private void _RowsCounter()
        {
            lblRecordsNumber.Text = dgvLocalLicenseApplcations.RowCount.ToString();
        }
        private void _RowsCounter(DataTable ApplicationTable)
        {
            lblRecordsNumber.Text = ApplicationTable.Rows.Count.ToString();
        }
        private void _CLoseLocalDrivingLicenseApplication()
        {

            this.Close();
        }
        private void _AddNewLocalDrivingLicenseApplication()
        {
            frmAddNewLocalDrivingLicenseApplication AddNewLocalDrivingLicenseApplication = new frmAddNewLocalDrivingLicenseApplication(-1);
            AddNewLocalDrivingLicenseApplication.RefreshLocalDrivingLicenseApplication += _RefreshLocalDrivingLicenseAppsData;
            AddNewLocalDrivingLicenseApplication.ShowDialog();
        }
        private void _LoadFiltersToComboBox()
        {
            //add Filter to combobox
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("LocalDrivingLicenseApplicationID");
            cbFilters.Items.Add("NationalNo");
            cbFilters.Items.Add("FullName");
            cbFilters.Items.Add("Status");

            //set the default filter to 'None'
            cbFilters.SelectedItem = "None";

        }
        private void _DisabelFilterSearchBoxIfFilterIs()
        {
            string Filter = cbFilters.SelectedItem.ToString();
            switch(Filter)
            {
                case "None":
                    txtFilterBy.Visible = false;
                    cbStatusFilter.Visible = false;
                    break;
                case "Status":
                    txtFilterBy.Visible = false;
                    _LoadStatusFilter();
                    break;
                default:
                    txtFilterBy.Visible = true;
                    cbStatusFilter.Visible = false;
                    break;
            }
        }

        private void _LoadStatusFilter()
        {
            cbStatusFilter.Visible = true;
            cbStatusFilter.SelectedIndex = 0;
        }

        private void _FilterLocalLicenseApplicationsBy(string Filter, string Condition)
        {
            DataTable dt = clsLocalDriverLicenseApplicationBusinessLayer.FilterLocalDrivingLicenseApplicationBy(Filter, Condition);
            _RowsCounter(dt);
            _RefreshLocalDrivingLicenseAppsData(dt);
        }
        private void _CancelLocalDrivingLicenseApplication(byte selectedApplication)
        {
            //confirm cancellation
            if (MessageBox.Show("Are you sure to cancell the Application", "Are you sure", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsApplicationsBusinessLayer.CancelApplication(selectedApplication))
                {
                    MessageBox.Show("Application Cancelled succssefully");
                }
                _RefreshLocalDrivingLicenseAppsData();
            }
        }

        private void _ShowTestAppointmentsForm()
        {
            int LDLApplications = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            frmTestAppointments testAppointments = new frmTestAppointments(LDLApplications);
            testAppointments.ShowDialog();
        }

        private void _LoadLDLApplicationsMenuStrip()
        {
            int PassedTestCount = _HowMuchTestsPassed();
            if (PassedTestCount == 0)
            {
                tsmSechduleVisionTest.Enabled = true;
                tsmSechduleWrittenTest.Enabled = false;
                tsmSechduleStreetTest.Enabled = false;
                tsmIssueDrivingLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = false;
            }
            else if (PassedTestCount == 1)
            {
                tsmSechduleVisionTest.Enabled = true;
                tsmSechduleWrittenTest.Enabled = true;
                tsmSechduleStreetTest.Enabled = false;
                tsmIssueDrivingLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = false;
            }
            else if (PassedTestCount == 2)
            {
                tsmSechduleVisionTest.Enabled = true;
                tsmSechduleWrittenTest.Enabled = true;
                tsmSechduleStreetTest.Enabled = true;
                tsmIssueDrivingLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = false;
            }
            else
            {
                tsmSechduleVisionTest.Enabled = true;
                tsmSechduleWrittenTest.Enabled = true;
                tsmSechduleStreetTest.Enabled = true;
                tsmIssueDrivingLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = false;
            }

        }
        private int _HowMuchTestsPassed()
        {
            clsGlobalSettings.LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            int PasseTestCount = clsLocalDriverLicenseApplicationBusinessLayer.GetHowMuchTestsPassed(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            return PasseTestCount;
        }

        //buttons
        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _RefreshLocalDrivingLicenseAppsData();
                _RowsCounter();
                _LoadFiltersToComboBox();
                _LoadLocalDrivingLicenseApplication();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CLoseLocalDrivingLicenseApplication();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            _CLoseLocalDrivingLicenseApplication();
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddNewLocalDrivingLicenseApplication();
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DisabelFilterSearchBoxIfFilterIs();
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string Filter = cbFilters.SelectedItem.ToString();
            string Condition = txtFilterBy.Text;
            _FilterLocalLicenseApplicationsBy(Filter, Condition);
        }
        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Filter = "Status";
            string Condition = cbStatusFilter.SelectedItem.ToString();
            _FilterLocalLicenseApplicationsBy(Filter, Condition);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            byte selectedApplication = Convert.ToByte(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            _CancelLocalDrivingLicenseApplication(selectedApplication);
            
        }
        private void sechdulteVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowTestAppointmentsForm();
        }

        private void cmsLDLApplications_Opening(object sender, CancelEventArgs e)
        {
            _LoadLDLApplicationsMenuStrip();
        }
    }
}
