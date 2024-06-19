using clsBusinessLayer;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
using DVLD_Full_Project.Licenses;
using DVLD_Full_Project.Tests.Issue_Driver_Licnese;
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
        private void _LoadLocalDrivingLicenseApplicationsForm()
        {
            _RefreshLocalDrivingLicenseAppsData();
            _RowsCounter();
            _LoadFiltersToComboBox();
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
        private void _DeleteLocalDrivingLicenseApplication()
        {
            int LDLApplicationID = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            int ApplicationID = _GetApplicationID(LDLApplicationID);

            if (MessageBox.Show("Are you sure to delete Application!", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsLocalDriverLicenseApplicationBusinessLayer.DeleteLocalDrivingLicenseApplicationID(LDLApplicationID))
                {
                    if (clsApplicationsBusinessLayer.DeleteApplication(ApplicationID))
                    {
                        MessageBox.Show("Application Deleted Successfully");
                        _RefreshLocalDrivingLicenseAppsData();
                        _RowsCounter();
                    }
                }
                else
                {
                    MessageBox.Show("Delete Application Failed");
                }
            }
        }
        private int _GetApplicationID(int LDLApplicationID)
        {
            return clsApplicationsBusinessLayer.GetApplicationID(LDLApplicationID);
        }
        private void _ShowTestAppointmentsForm(clsGlobalSettings.enTestTypes TestType)
        {
            int LDLApplications = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);

            //fill the test appointment ID related to this person
            clsGlobalSettings.TestAppointementID = clsTestAppointementsBusinessLayer.GetTestAppointmentID(LDLApplications);

            frmTestAppointments testAppointments = new frmTestAppointments(LDLApplications, TestType);

            //refresh the data an rows counter after closing the form 
            testAppointments.RefreshLicenseDrivingLicenseApplicationsData += _RefreshLocalDrivingLicenseAppsData;
            testAppointments.RefreshRowsCounter += _RowsCounter;

            testAppointments.ShowDialog();
        }

        private void _LoadLDLApplicationsMenuStrip()
        {
            if (isDriverLicenseIssuedForThisApplication())
            {
                tsmEditApplication.Enabled = false;
                tsmDeleteApplication.Enabled = false;
                tsmCancelApplication.Enabled = false;
                tsmSechduleTests.Enabled = false;
                tsmIssueDrivingLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = true;
            }
            else if (isApplicationCancelled())
            {
                tsmEditApplication.Enabled = true;
                tsmDeleteApplication.Enabled = true;
                tsmCancelApplication.Enabled = true;
                tsmSechduleTests.Enabled = false;
                tsmIssueDrivingLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = false;

            }
            else
            {
                tsmEditApplication.Enabled = true;
                tsmDeleteApplication.Enabled = true ;
                tsmCancelApplication.Enabled = true;
                tsmSechduleTests.Enabled = true;
                tsmIssueDrivingLicenseFirstTime.Enabled = true;

                int PassedTestCount = _HowMuchTestsPassed();
                switch (PassedTestCount)
                {
                    case 0:
                        tsmSechduleVisionTest.Enabled = true;
                        tsmSechduleWrittenTest.Enabled = false;
                        tsmSechduleStreetTest.Enabled = false;
                        tsmIssueDrivingLicenseFirstTime.Enabled = false;
                        tsmShowLicense.Enabled = false;
                        break;
                    case 1:
                        tsmSechduleVisionTest.Enabled = false;
                        tsmSechduleWrittenTest.Enabled = true;
                        tsmSechduleStreetTest.Enabled = false;
                        tsmIssueDrivingLicenseFirstTime.Enabled = false;
                        tsmShowLicense.Enabled = false;
                        break;
                    case 2:
                        tsmSechduleVisionTest.Enabled = false;
                        tsmSechduleWrittenTest.Enabled = false;
                        tsmSechduleStreetTest.Enabled = true;
                        tsmIssueDrivingLicenseFirstTime.Enabled = false;
                        tsmShowLicense.Enabled = false;
                        break;
                    default:
                        tsmSechduleTests.Enabled = false;
                        tsmIssueDrivingLicenseFirstTime.Enabled = true;
                        tsmShowLicense.Enabled = false;
                        break;
                }
            }
            
        }
        private bool isApplicationCancelled()
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            return clsLocalDriverLicenseApplicationBusinessLayer.isApplicationCancelled(LocalDrivingLicenseApplicationID);
        }
        private bool isDriverLicenseIssuedForThisApplication()
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            return clsApplicationsBusinessLayer.isDriverLicenseIssuedForThisApplication(LocalDrivingLicenseApplicationID);
        }
        private int _HowMuchTestsPassed()
        {
            clsGlobalSettings.LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            int PassedTestCount = clsLocalDriverLicenseApplicationBusinessLayer.GetHowMuchTestsPassed(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            return PassedTestCount;
        }
        private void _ShowIssueDriverLicenseForTheFirstTime()
        {
            int LDLApplicationID = Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
            frmIssueDriverLicenseForTheFirstTime IssueDriverLicenseForTheFirstTime = new frmIssueDriverLicenseForTheFirstTime();

            IssueDriverLicenseForTheFirstTime.RefreshLicenseDrivingLicenseApplicationsData += _RefreshLocalDrivingLicenseAppsData;
            IssueDriverLicenseForTheFirstTime.RefreshRowsCounter += _RowsCounter;

            IssueDriverLicenseForTheFirstTime.ShowDialog();
        }
        private void _ShowLicenseInfoForm()
        {
            frmShowLicenseInfo ShowLicenseInfo = new frmShowLicenseInfo(_GetLocalDrivingLicenseApplictionIDFromDataGridView());
            ShowLicenseInfo.ShowDialog();
        }
        private int _GetLocalDrivingLicenseApplictionIDFromDataGridView()
        {
            return Convert.ToInt32(dgvLocalLicenseApplcations.CurrentRow.Cells[0].Value);
        }
        private void _ShowPersonLicenseHistoryForm()
        {
            //get the national number related to the actual person to get person id
            string NationalNo = dgvLocalLicenseApplcations.CurrentRow.Cells["NationalNo"].Value.ToString();
            int personID = _GetPersonIdRealtedToPersonNationalNo(NationalNo);

            frmShowLicenseHistory ShowLicensesHistory = new frmShowLicenseHistory(personID);
            ShowLicensesHistory.ShowDialog();
        }
        private int _GetPersonIdRealtedToPersonNationalNo(string NationalNo)
        {
            return clsPeopleBusinessLayer.GetPersonIdRealtedToPersonNationalNo(NationalNo);
        }
        private void _ShowApplicationDetailsForm()
        {
            frmAddNewLocalDrivingLicenseApplication addNewLDLApplication = new frmAddNewLocalDrivingLicenseApplication();
            addNewLDLApplication.ShowDialog();
        }

        //buttons
        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadLocalDrivingLicenseApplicationsForm();
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
            _FilterLocalLicenseApplicationsBy("None", string.Empty);
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
            _ShowTestAppointmentsForm(clsGlobalSettings.enTestTypes.VisionTest);
        }

        private void cmsLDLApplications_Opening(object sender, CancelEventArgs e)
        {
            _LoadLDLApplicationsMenuStrip();
        }

        private void tsmSechduleWrittenTest_Click(object sender, EventArgs e)
        {
            
            _ShowTestAppointmentsForm(clsGlobalSettings.enTestTypes.WrittenTheoryTest);
        }

        private void tsmSechduleStreetTest_Click(object sender, EventArgs e)
        {
            _ShowTestAppointmentsForm(clsGlobalSettings.enTestTypes.PracticalStreetTest);
        }

        private void tsmIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            _ShowIssueDriverLicenseForTheFirstTime();
        }

        private void tsmShowLicense_Click(object sender, EventArgs e)
        {
            _ShowLicenseInfoForm();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistoryForm();
        }

        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {
            _DeleteLocalDrivingLicenseApplication();
        }

        private void tsmShowApplicationDetails_Click(object sender, EventArgs e)
        {
            _ShowApplicationDetailsForm();
        }
    }
}
