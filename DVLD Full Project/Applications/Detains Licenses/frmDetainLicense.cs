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
    public partial class frmDetainLicense : Form
    {
        public delegate void evenRefreshDetainedLicenseData(string filter = "", string condition = "");
        public delegate void eventRefreshRowsCounter();
        public delegate void eventRefreshFilterAndSearchBox();

        public event evenRefreshDetainedLicenseData _RefreshDetainedLicenseData;
        public event eventRefreshRowsCounter _RefreshRowsCounter;
        public event eventRefreshFilterAndSearchBox _RefreshFilterAndSearchBox;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        //functions
        private void _LoadDetainLicenseForm()
        {
            lblDetainID.Text = "??";
            lblDetainDate.Text = DateTime.Now.ToString();
            lblLicenseID.Text = "??";
            lblCreatedBy.Text = clsGlobalSettings.User.UserName;

            btnDetain.Enabled = false;
            lklShowLicensesHistory.Enabled = false;
            lklShowLicensesInfos.Enabled = false;

            //create objects
            clsGlobalSettings.DetainedLicenses = new clsDetainedLicensesBusinessLayer();
        }
        private void _OnClickSearch(int LicenseID)
        {
            clsGlobalSettings.LicenseID = LicenseID;

            if (!clsLicensesBusinessLayer.isLicenseExists(LicenseID))
            {
                btnDetain.Enabled = false;
                lblLicenseID.Text = "??";
                lklShowLicensesHistory.Enabled = false;
                lklShowLicensesInfos.Enabled = false;
                return;
            }

            if (!clsLicensesBusinessLayer.isLicenseActive(LicenseID))
            {
                btnDetain.Enabled = false;
                lblLicenseID.Text = "??";
                lklShowLicensesHistory.Enabled = true;
                lklShowLicensesInfos.Enabled = true;
                return;
            }

            if (clsDetainedLicensesBusinessLayer.isLicenseDetained(LicenseID.ToString()))
            {
                btnDetain.Enabled = false;
                lklShowLicensesHistory.Enabled = true;
                lklShowLicensesInfos.Enabled = true;

                lblLicenseID.Text = "??";   
            }
            else
            {
                btnDetain.Enabled = true;
                lklShowLicensesHistory.Enabled = true;
                lklShowLicensesInfos.Enabled = true;

                lblLicenseID.Text = LicenseID.ToString();
            }
        }
        private void _CloseDetainLicenseForm()
        {
            _RefreshDetainedLicenseData();
            _RefreshRowsCounter();
            _RefreshFilterAndSearchBox();
            this.Close();
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
        private void _DetainLicense()
        {
            _GetDetainedLicenseObjectInfos();

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

            if (clsGlobalSettings.DetainedLicenses.Save())
            {
                MessageBox.Show("License Detained Successfully!");

                clsLicensesBusinessLayer.DeactivateOldLicense(clsGlobalSettings.LicenseID);
            }

            _UpdateDetainApplicationInfos();
        }
        private void _GetDetainedLicenseObjectInfos()
        {
            clsGlobalSettings.DetainedLicenses.LicenseID = Convert.ToInt32(lblLicenseID.Text);
            clsGlobalSettings.DetainedLicenses.DetainDate = Convert.ToDateTime(lblDetainDate.Text);
            if (txtFineFees.Text == string.Empty)
            {
                clsGlobalSettings.DetainedLicenses.FineFees = 0;

            }
            else
            {
                clsGlobalSettings.DetainedLicenses.FineFees = Convert.ToDecimal(txtFineFees.Text);
            }
            clsGlobalSettings.DetainedLicenses.CreatedByUserID = clsGlobalSettings.User.UserID;
            clsGlobalSettings.DetainedLicenses.IsReleased = false;
            clsGlobalSettings.DetainedLicenses.ReleaseDate = default;
            clsGlobalSettings.DetainedLicenses.ReleasedByUserID = default;
            clsGlobalSettings.DetainedLicenses.ReleaseApplicationID = default;
        }
        private void _UpdateDetainApplicationInfos()
        {
            lblDetainID.Text = clsGlobalSettings.DetainedLicenses.DetainID.ToString();
            btnDetain.Enabled = false;

            ucDetainLicense.Enabled = false;
        }
        //buttons
        private void frmDetainLicnese_Load(object sender, EventArgs e)
        {
            _LoadDetainLicenseForm();
        }

        private void ucDetainLicense1_onClickSearch(int LicenseID)
        {
            _OnClickSearch(LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseDetainLicenseForm();
        }

        private void lklShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseHistoryForm();
        }

        private void lklShowLicensesInfos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseInfosForm();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _DetainLicense();
        }
    }
}
