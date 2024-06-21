using clsBusinessLayer;
using DVLD_Full_Project.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses
{
    public partial class frmAddInternationalLicenseApplication : Form
    {
        public frmAddInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        public frmAddInternationalLicenseApplication(int LDLApplication)
        {
            InitializeComponent();
            clsGlobalSettings.LocalDrivingLicenseApplicationID = LDLApplication;
            if (clsGlobalSettings.LocalDrivingLicenseApplicationID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }
        //functions
        private void _LoadAddInternationalLicenseApplication()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                //Application infos
                lblILApplicationID.Text = "??";
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblIssueDate.Text = DateTime.Now.ToString();
                lblFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("New International License").ToString();
                lblLicenseID.Text = "??";
                lblLocalLicenseID.Text = "??";
                lblExpirationDate.Text = DateTime.Now.AddDays(1).ToString();
                lblCreatedBy.Text = clsGlobalSettings.User.UserName;

                //options
                btnIssue.Enabled = false;
                lklShowLicensesHistory.Enabled = false;
                lklShowLicensesInfos.Enabled = false;
                return;
            }
        }
        private void _CloseAddInternationalLicenseApplicationForm()
        {
            this.Close();
        }
        private void _IfClickSearchForLicense(int obj)
        {
            lblLocalLicenseID.Text = obj.ToString();

            btnIssue.Enabled = true;
            lklShowLicensesHistory.Enabled = true;
        }
        private void _ShowLicensesHistoryForm()
        {
            clsGlobalSettings.PersonID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(clsGlobalSettings.LicenseID);
            frmShowLicenseHistory showLicensesHistory = new frmShowLicenseHistory(clsGlobalSettings.PersonID);
            showLicensesHistory.ShowDialog();
        }
        private void _IssueInternationalLicense()
        {
            if (_isPersonHasInternationalLicense())
            {
                MessageBox.Show("Person Already has International license");
            }
            else
            {
                _SaveInternationalLicense();
            }
        }
        private void _SaveInternationalLicense()
        {

        }
        private bool _isPersonHasInternationalLicense()
        {
            return clsInternationalLicensesBusinessLayer.isPersonHasInternationalLicense(clsGlobalSettings.LicenseID);
        }
        //buttons
        private void frmAddInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadAddInternationalLicenseApplication();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseAddInternationalLicenseApplicationForm();
        }

        private void ucSearchInternationalLicenseApplication1_onClickSearchForDriverLicense(int obj)
        {
            _IfClickSearchForLicense(obj);
        }

        private void lklShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicensesHistoryForm();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _IssueInternationalLicense();
        }
    }
}
