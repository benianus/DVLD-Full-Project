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

namespace DVLD_Full_Project.Applications.Driver_Licenses_Services.Renew_Driving_License
{
    public partial class frmRenewDrivingLicense : Form
    {
        private ucRenewLicenseApplication renewLicenseApplication;

        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }
        public frmRenewDrivingLicense(int LicenseID)
        {
            InitializeComponent();
            clsGlobalSettings.LicenseID = LicenseID;
            if (clsGlobalSettings.LicenseID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }

        //functions
        private void _LoadRenewLicenseApplicationForm()
        {
            //New License Application infos
            lblRenewedLicenseID.Text = "??";
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Renew Driving License Service").ToString();
            lblLicenseFees.Text = "??";
            lblNotes.Text = string.Empty;
            lblRenewedLicenseID.Text = "??";
            lblOldLicenseID.Text = "??";
            lblExpirationDate.Text = "??";
            lblCreatedBy.Text = clsGlobalSettings.User.UserName;
            lblTotalFees.Text = "??";

            //buttons
            btnRenew.Enabled = false;
            lklShowLicensesHistory.Enabled = false;
            lklShowLicensesInfos.Enabled = false;

            //create new objects for application and license
            clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
            clsGlobalSettings.Licenses = new clsLicensesBusinessLayer();

        }
        private void _CloseRenewLicenseApplicationForm()
        {
            this.Close();
        }
        private void _IfClickSearchForLicense(int LicenseID)
        {
            clsGlobalSettings.LicenseID = LicenseID;

            //check if the license if its not expired
            DataTable DriverLicenseInfosTable = clsLicensesBusinessLayer.GetExpiredDriverLicense(clsGlobalSettings.LicenseID);

            if (DriverLicenseInfosTable == null)
            {
                lblOldLicenseID.Text = "??";
                lblLicenseFees.Text = "??";
                lblExpirationDate.Text = "??";
                lblTotalFees.Text = "??";

                btnRenew.Enabled = false;
                lklShowLicensesHistory.Enabled = false;
                lklShowLicensesInfos.Enabled = false;
            }
            else
            {
                lblOldLicenseID.Text = LicenseID.ToString();
                lblLicenseFees.Text = clsLicensesBusinessLayer.GetLicenseFees(LicenseID).ToString();
                lblExpirationDate.Text = (Convert.ToDateTime(lblIssueDate.Text).AddYears(10)).ToString();
                lblTotalFees.Text = (Convert.ToInt32(lblApplicationFees.Text) + Convert.ToInt32(lblLicenseFees.Text)).ToString();

                btnRenew.Enabled = true;
                lklShowLicensesHistory.Enabled = true;
            }

            _CheckIfLicenseActiveOrExpiredOrExists(LicenseID);
        }
        private void _CheckIfLicenseActiveOrExpiredOrExists(int LicenseID)
        {
            if (!clsLicensesBusinessLayer.isLicenseActive(LicenseID))
            {
                lblOldLicenseID.Text = "??";
                lblLicenseFees.Text = "??";
                lblExpirationDate.Text = "??";
                lblTotalFees.Text = "??";

                btnRenew.Enabled = false;
                lklShowLicensesHistory.Enabled = true;
            }

            if (!clsLicensesBusinessLayer.isLicenseExpired(clsGlobalSettings.LicenseID))
            {
                btnRenew.Enabled = false;
                lklShowLicensesHistory.Enabled = true;
            }

            if (!clsLicensesBusinessLayer.isLicenseExists(clsGlobalSettings.LicenseID))
            {
                lblOldLicenseID.Text = "??";
                lblLicenseFees.Text = "??";
                lblExpirationDate.Text = "??";
                lblTotalFees.Text = "??";

                btnRenew.Enabled = false;
                lklShowLicensesHistory.Enabled = false;
                lklShowLicensesInfos.Enabled = false;
            }
        }
        private void _SaveRenewLicenseApplication()
        {
            //get person ID linked to application and license
            clsGlobalSettings.PersonID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(Convert.ToInt32(lblOldLicenseID.Text));

            _GetApplicationObjectData();

            //Change the mode to addnew in case it's in update mode
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

            if (clsGlobalSettings.Applications.Save())
            {
                _GetLicenseObjectData();

                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

                if (clsGlobalSettings.Licenses.Save())
                {
                    clsLicensesBusinessLayer.DeactivateOldLicense(Convert.ToInt32(lblOldLicenseID.Text));

                    MessageBox.Show("License Renewed Successfully!");

                }
            }

            _ShowNewLicenseApplicationInfosAfterSavingRenewedLicense();
        }
        private void _GetApplicationObjectData()
        {
            clsGlobalSettings.Applications.ApplicantPersonID = clsGlobalSettings.PersonID;
            clsGlobalSettings.Applications.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Applications.ApplicationTypeID = 2;
            clsGlobalSettings.Applications.ApplicationStatus = 1;
            clsGlobalSettings.Applications.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            clsGlobalSettings.Applications.LastStatusDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Applications.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private void _GetLicenseObjectData()
        {
            clsGlobalSettings.Licenses.ApplicationID = clsGlobalSettings.Applications.ApplicationID;
            clsGlobalSettings.Licenses.DriverID = clsDriversBusinessLayer.GetDriverRelatedToPerson(clsGlobalSettings.PersonID);
            clsGlobalSettings.Licenses.LicenseClass = clsLicensesBusinessLayer.GetLicenseClassID(clsGlobalSettings.LicenseID);
            clsGlobalSettings.Licenses.IssueDate = Convert.ToDateTime(lblIssueDate.Text);
            clsGlobalSettings.Licenses.ExpirationDate = Convert.ToDateTime(lblExpirationDate.Text);
            if (lblNotes.Text == string.Empty)
            {
                clsGlobalSettings.Licenses.Notes = string.Empty;
            }
            else
            {
                clsGlobalSettings.Licenses.Notes = lblNotes.Text;
            }
            clsGlobalSettings.Licenses.PaidFees = Convert.ToDecimal(lblLicenseFees.Text);
            clsGlobalSettings.Licenses.IsActive = true;
            clsGlobalSettings.Licenses.IssueReason = 2;
            clsGlobalSettings.Licenses.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private void _ShowNewLicenseApplicationInfosAfterSavingRenewedLicense()
        {
            lblRLApplicationID.Text = clsGlobalSettings.Applications.ApplicationID.ToString();
            lblRenewedLicenseID.Text = clsGlobalSettings.Licenses.LicenseID.ToString();

            lklShowLicensesInfos.Enabled = true;
            btnRenew.Enabled = false;
        }
        private void _ShowLicenseHistoryForm()
        {
            int personID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(clsGlobalSettings.LicenseID);
            frmShowLicenseHistory showLicenseHistory = new frmShowLicenseHistory(personID);
            showLicenseHistory.ShowDialog();
        }
        private void _ShowLicenseInfosForm()
        {
            int applicationID = clsLicensesBusinessLayer.GetApplicationIDRelatedToLicense(Convert.ToInt32(lblRenewedLicenseID.Text));
            frmShowLocalLicenseInfo showLocalLicenseInfos = new frmShowLocalLicenseInfo(applicationID);
            showLocalLicenseInfos.ShowDialog();
        }
        private void _DisableFilterBox()
        {
            //disable renew application
            ucRenewLicenseApplication.Enabled = false;
        }
        //buttons
        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadRenewLicenseApplicationForm();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseRenewLicenseApplicationForm();
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            _SaveRenewLicenseApplication();
            _DisableFilterBox();
        }

        private void ucRenewLicenseApplication1_onClickSearch(int LicenseID)
        {
            _IfClickSearchForLicense(LicenseID);
        }
        private void lklShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseHistoryForm();
        }
        private void lklShowLicensesInfos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseInfosForm();
        }
    }
}
