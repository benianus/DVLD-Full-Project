using clsBusinessLayer;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.Renew_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class ucRenewLicenseApplication : UserControl
    {
        public event Action<int> onClickSearch;
        protected virtual void ClickSearch(int LicenseID)
        {
            Action<int> Handler = onClickSearch;
            if (Handler != null)
            {
                Handler(LicenseID);
            }
        }

        private int _Mode;
        public ucRenewLicenseApplication()
        {
            InitializeComponent();
        }
        public ucRenewLicenseApplication(int renewMode)
        {
            InitializeComponent();
        }
        //functions
        private void _LoadRenewLicenseApplicationUserControl()
        {
            lblClass.Text = "??";
            lblName.Text = "??";
            lblNationalNo.Text = "??";
            lblGendor.Text = "??";
            lblLicenseID.Text = "??";
            lblIssueDate.Text = "??";
            lblIssueReason.Text = "??";
            lblNotes.Text = "??";
            lblIsActive.Text = "??";
            lblDateOfBirth.Text = "??";
            lblDriverID.Text = "??";
            lblExpirationDate.Text = "??";
            pbPerson.ImageLocation = null;
            lblIsDetained.Text = "??";
        }
        private void _LoadDriverLicenseInfos()
        {
            if (txtLiceneseID.Text == string.Empty)
            {
                return;
            }

            clsGlobalSettings.LicenseID = Convert.ToInt32(txtLiceneseID.Text);

            //check if the license exists, active or expired
            if (!clsLicensesBusinessLayer.isLicenseExists(clsGlobalSettings.LicenseID))
            {
                MessageBox.Show("Driver License not Exists");

                _LoadRenewLicenseApplicationUserControl();

                if (onClickSearch != null)
                {
                    ClickSearch(clsGlobalSettings.LicenseID);
                }
                return;
            }
            else if (!clsLicensesBusinessLayer.isLicenseExpired(clsGlobalSettings.LicenseID))
            {
                MessageBox.Show("Driver License not Expired yet");

                _LoadLicenseInfosToFormIfLicenseNotExpired();

                if (onClickSearch != null)
                {
                    ClickSearch(clsGlobalSettings.LicenseID);
                }
                return;
            }
            else if (!clsLicensesBusinessLayer.isLicenseActive(clsGlobalSettings.LicenseID))
            {
                MessageBox.Show("Driver License not Active");

                _LoadLicenseInfosToFormIfLicenseExpired();

                if (onClickSearch != null)
                {
                    ClickSearch(clsGlobalSettings.LicenseID);
                }
                return;
            }

            _LoadLicenseInfosToFormIfLicenseExpired();

            //event where search button clicked
            if (onClickSearch != null)
            {
                ClickSearch(clsGlobalSettings.LicenseID);
            }
        }
        private void _LoadLicenseInfosToFormIfLicenseExpired()
        {
            DataTable DriverLicenseInfosTable = clsLicensesBusinessLayer.GetExpiredDriverLicense(clsGlobalSettings.LicenseID);

            lblClass.Text = DriverLicenseInfosTable.Rows[0]["ClassName"].ToString();
            lblName.Text = DriverLicenseInfosTable.Rows[0]["Name"].ToString();
            lblLicenseID.Text = DriverLicenseInfosTable.Rows[0]["LicenseID"].ToString();
            lblNationalNo.Text = DriverLicenseInfosTable.Rows[0]["NationalNo"].ToString();
            lblGendor.Text = DriverLicenseInfosTable.Rows[0]["Gendor"].ToString();
            lblIssueDate.Text = DriverLicenseInfosTable.Rows[0]["IssueDate"].ToString();
            lblIssueReason.Text = DriverLicenseInfosTable.Rows[0]["IssueReason"].ToString();
            lblDateOfBirth.Text = DriverLicenseInfosTable.Rows[0]["DateOfBirth"].ToString();
            lblDriverID.Text = DriverLicenseInfosTable.Rows[0]["DriverID"].ToString();
            lblExpirationDate.Text = DriverLicenseInfosTable.Rows[0]["ExpirationDate"].ToString();
            pbPerson.ImageLocation = DriverLicenseInfosTable.Rows[0]["ImagePath"].ToString();

            if (_IsLicenseDetained(lblLicenseID.Text))
            {
                lblIsDetained.Text = "Yes";
            }
            else
            {
                lblIsDetained.Text = "No";
            }

            lblIsActive.Text = DriverLicenseInfosTable.Rows[0]["IsActive"].ToString();

            if (DriverLicenseInfosTable.Rows[0]["Notes"].ToString() == string.Empty)
            {
                lblNotes.Text = "No Notes";
            }
            else
            {
                lblNotes.Text = DriverLicenseInfosTable.Rows[0]["Notes"].ToString();
            }
        }
        private void _LoadLicenseInfosToFormIfLicenseNotExpired()
        {
            DataTable DriverLicenseInfosTable = clsLicensesBusinessLayer.GetNotExpiredDriverLicense(clsGlobalSettings.LicenseID);

            lblClass.Text = DriverLicenseInfosTable.Rows[0]["ClassName"].ToString();
            lblName.Text = DriverLicenseInfosTable.Rows[0]["Name"].ToString();
            lblLicenseID.Text = DriverLicenseInfosTable.Rows[0]["LicenseID"].ToString();
            lblNationalNo.Text = DriverLicenseInfosTable.Rows[0]["NationalNo"].ToString();
            lblGendor.Text = DriverLicenseInfosTable.Rows[0]["Gendor"].ToString();
            lblIssueDate.Text = DriverLicenseInfosTable.Rows[0]["IssueDate"].ToString();
            lblIssueReason.Text = DriverLicenseInfosTable.Rows[0]["IssueReason"].ToString();
            lblDateOfBirth.Text = DriverLicenseInfosTable.Rows[0]["DateOfBirth"].ToString();
            lblDriverID.Text = DriverLicenseInfosTable.Rows[0]["DriverID"].ToString();
            lblExpirationDate.Text = DriverLicenseInfosTable.Rows[0]["ExpirationDate"].ToString();
            pbPerson.ImageLocation = DriverLicenseInfosTable.Rows[0]["ImagePath"].ToString();

            if (_IsLicenseDetained(lblLicenseID.Text))
            {
                lblIsDetained.Text = "Yes";
            }
            else
            {
                lblIsDetained.Text = "No";
            }

            lblIsActive.Text = DriverLicenseInfosTable.Rows[0]["IsActive"].ToString();

            if (DriverLicenseInfosTable.Rows[0]["Notes"].ToString() == string.Empty)
            {
                lblNotes.Text = "No Notes";
            }
            else
            {
                lblNotes.Text = DriverLicenseInfosTable.Rows[0]["Notes"].ToString();
            }
        }
        private bool _IsLicenseDetained(string LicenseID)
        {
            return clsDetainedLicensesBusinessLayer.isLicenseDetained(LicenseID);
        }
        public void disableFilterAfterRenewLicense()
        {
            gbLicenseFilter.Enabled = false;
            lblLicenseIDFilter.Enabled = false;
            txtLiceneseID.Enabled = false;
            btnLicenseSearch.Enabled = false;
        }

        //buttons
        private void ucRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadRenewLicenseApplicationUserControl();
        }
        private void btnLicenseSearch_Click(object sender, EventArgs e)
        {
            _LoadDriverLicenseInfos();
        }
    }
}
