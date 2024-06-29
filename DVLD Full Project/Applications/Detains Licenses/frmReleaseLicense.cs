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

namespace DVLD_Full_Project.Applications.Detains_Licenses
{
    public partial class frmReleaseLicense : Form
    {
        public delegate void eventRefreshDetainedLicenseData(string filter = "", string condition = "");
        public delegate void eventRefreshRowsCounter();
        public delegate void eventRefreshFilterSearchBox();

        public event eventRefreshDetainedLicenseData _RefreshDetainedLicenseDate;
        public event eventRefreshRowsCounter _RefreshRowsCounter;
        public event eventRefreshFilterSearchBox _RefreshFilterSearchBox;   
        public frmReleaseLicense()
        {
            InitializeComponent();
        }
        public frmReleaseLicense(int licenseID)
        {
            InitializeComponent();
            clsGlobalSettings.LicenseID = licenseID;
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
        private void _CloseReleaseDetainedLicense()
        {
            _RefreshDetainedLicenseDate?.Invoke();
            _RefreshRowsCounter?.Invoke();
            _RefreshFilterSearchBox?.Invoke();
            this.Close();
        }
        private void _LoadReleaseDetainedLicenseForm()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                lblDetainID.Text = "??";
                lblDetainDate.Text = "??";
                lblApplicationFees.Text = "??";
                lblLicenseID.Text = "??";
                lblCreatedBy.Text = clsGlobalSettings.User.UserName;
                lblFineFees.Text = "??";
                lblApplicationID.Text = "??";
                lblTotalFees.Text = "??";

                btnRelease.Enabled = false;
                lklShowLicensesHistory.Enabled = false;
                lklShowLicensesInfos.Enabled = false;

                // Create new application ...
                clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
                return;
            }

            //ucReleaseLicense.Enabled = false;
            _LoadDetainedLicenseInfos(clsGlobalSettings.LicenseID);

            //create new application
            clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
        }
        
        private void _OnClickSearch(int LicenseID)
        {
            clsGlobalSettings.LicenseID = LicenseID;

            if (!clsLicensesBusinessLayer.isLicenseExists(LicenseID))
            {
                btnRelease.Enabled = false;
                lblLicenseID.Text = "??";
                lklShowLicensesHistory.Enabled = false;
                lklShowLicensesInfos.Enabled = false;
                return;
            }

            if (!clsDetainedLicensesBusinessLayer.isLicenseDetained(LicenseID.ToString()))
            {
                btnRelease.Enabled = false;
                lblLicenseID.Text = "??";
                lklShowLicensesHistory.Enabled = true;
                lklShowLicensesInfos.Enabled = true;
                return;
            }
            else
            {
                btnRelease.Enabled = true;
                lklShowLicensesHistory.Enabled = true;
                lklShowLicensesInfos.Enabled = true;

                // Load Detained license Infos
                _LoadDetainedLicenseInfos(LicenseID);
            }
        }
        private void _LoadDetainedLicenseInfos(int LicenseID)
        {
            clsGlobalSettings.DetainedLicenses = clsDetainedLicensesBusinessLayer.FindDetainedLicense(clsGlobalSettings.LicenseID);

            lblLicenseID.Text = LicenseID.ToString();
            lblDetainID.Text = clsGlobalSettings.DetainedLicenses.DetainID.ToString();
            lblDetainDate.Text = clsGlobalSettings.DetainedLicenses.DetainDate.ToString();
            lblApplicationFees.Text = Convert.ToInt32(clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Release Detained Driving Licsense")).ToString();
            lblCreatedBy.Text = clsUserBusinessLayer.GetUesrName(clsGlobalSettings.DetainedLicenses.CreatedByUserID);
            lblFineFees.Text = Convert.ToInt32(clsGlobalSettings.DetainedLicenses.FineFees).ToString();
            lblApplicationID.Text = "??";
            lblTotalFees.Text = Convert.ToInt32((Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblFineFees.Text))).ToString();
        }
        private void _ShowLicenseHistoryForm()
        {
            int personID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(clsGlobalSettings.LicenseID);
            frmShowLicenseHistory showLicenseHistory = new frmShowLicenseHistory(personID);
            showLicenseHistory.ShowDialog();
        }
        private void _ShowLicenseInfosForm()
        {
            int applicationID = clsLicensesBusinessLayer.GetApplicationIDRelatedToLicense(clsGlobalSettings.LicenseID);
            frmShowLocalLicenseInfo showLocalLicenseInfos = new frmShowLocalLicenseInfo(applicationID);
            showLocalLicenseInfos.ShowDialog();
        }
        private void _ReleaseLicense()
        {
            clsGlobalSettings.PersonID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID((clsGlobalSettings.LicenseID));

            _GetApplicationObjectInfos();

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

            if (MessageBox.Show("Confirmation", "Are you sure to release?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsGlobalSettings.Applications.Save())
                {
                    _GetDetainLicenseObjectInfos();

                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;

                    if (clsGlobalSettings.DetainedLicenses.Save())
                    {
                        clsLicensesBusinessLayer.ActivateOldLicense(Convert.ToInt32(lblLicenseID.Text));

                        MessageBox.Show("License Released successfully!"); 
                    }
                }
                else
                {
                    MessageBox.Show("License Released Failed!"); ;
                }
            }

            _UpdateDetainLicenseInformation();
        }
        private void _GetApplicationObjectInfos()
        {
            clsGlobalSettings.Applications.ApplicantPersonID = clsGlobalSettings.PersonID;
            clsGlobalSettings.Applications.ApplicationDate = DateTime.Now;
            clsGlobalSettings.Applications.ApplicationTypeID = 5;
            clsGlobalSettings.Applications.ApplicationStatus = 3;
            clsGlobalSettings.Applications.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            clsGlobalSettings.Applications.LastStatusDate = DateTime.Now;
            clsGlobalSettings.Applications.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private void _GetDetainLicenseObjectInfos()
        {
            clsGlobalSettings.DetainedLicenses.LicenseID = Convert.ToInt32(lblLicenseID.Text);
            clsGlobalSettings.DetainedLicenses.DetainDate = Convert.ToDateTime(lblDetainDate.Text);
            clsGlobalSettings.DetainedLicenses.FineFees = Convert.ToDecimal(lblFineFees.Text);
            clsGlobalSettings.DetainedLicenses.CreatedByUserID = clsUserBusinessLayer.GetUserID(lblCreatedBy.Text);
            clsGlobalSettings.DetainedLicenses.IsReleased = true;
            clsGlobalSettings.DetainedLicenses.ReleaseDate = DateTime.Now;
            clsGlobalSettings.DetainedLicenses.ReleasedByUserID = clsGlobalSettings.User.UserID;
            clsGlobalSettings.DetainedLicenses.ReleaseApplicationID = clsGlobalSettings.Applications.ApplicationID;
        }
        private void _UpdateDetainLicenseInformation()
        {
            lblApplicationID.Text = clsGlobalSettings.Applications.ApplicationID.ToString();

            ucReleaseLicense.Enabled = false;
            btnRelease.Enabled = false;
        }

        //buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseReleaseDetainedLicense();
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            _LoadReleaseDetainedLicenseForm();
        }
        private void ucReleaseLicense1_onClickSearch(int LicenseID)
        {
            _OnClickSearch(LicenseID);
        }
        private void lklShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseHistoryForm();
        }
        private void lklShowLicensesInfos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseInfosForm();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            _ReleaseLicense();
        }
    }
}
