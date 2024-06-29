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

namespace DVLD_Full_Project.Applications.Driver_Licenses_Services
{
    public partial class frmReplacementForLostOrDamagedLicense : Form
    {
        public frmReplacementForLostOrDamagedLicense()
        {
            InitializeComponent();
        }
        //functions
        private void _LoadReplacementForLostOrDamagedLicenseForm()
        {
            rbDamaged.Checked = true;

            _ChangeFormTitleToReplacementType();

            lblLRApplicationID.Text = "??";
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = _GetApplicationsFees();
            lblReplacedLicenseID.Text = "??";
            lblOldLicenseID.Text = "??";
            lblCreatedBy.Text = clsGlobalSettings.User.UserName;

            btnReplace.Enabled = false;
            lklShowLicensesHistory.Enabled = false;
            lklShowLicensesInfos.Enabled = false;

            //create new object of application and license
            clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
            clsGlobalSettings.Licenses = new clsLicensesBusinessLayer();

        }
        private void _ChangeFormTitleToReplacementType()
        {
            if (rbDamaged.Checked == true)
            {
                lblReplacementTitle.Text = "Replacement For Damaged License";
            }
            else
            {
                lblReplacementTitle.Text = "Replacement For Lost License";
            }
        }
        private string _GetApplicationsFees()
        {
            if (rbDamaged.Checked == true)
            {
                return clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Replacement for a Damaged Driving License").ToString();
            }
            else
            {
                return clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Replacement for a Lost Driving License").ToString();
            }
        }
        private void _ChangeApplicationFees()
        {
            lblApplicationFees.Text = _GetApplicationsFees();
        }
        private void _ShowLicenseHistoryForm()
        {
            int personID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(clsGlobalSettings.LicenseID);
            frmShowLicenseHistory showLicenseHistory = new frmShowLicenseHistory(personID);
            showLicenseHistory.ShowDialog();
        }
        private void _ShowLicenseInfosForm()
        {
            int applicationID = clsLicensesBusinessLayer.GetApplicationIDRelatedToLicense(Convert.ToInt32(lblReplacedLicenseID.Text));
            frmShowLocalLicenseInfo showLocalLicenseInfos = new frmShowLocalLicenseInfo(applicationID);
            showLocalLicenseInfos.ShowDialog();
        }
        private void _CloseReplacementLostOrDamagedForm()
        {
            this.Close();
        }
        private void _onCLickSearch(int LicenseID)
        {
            clsGlobalSettings.LicenseID = LicenseID;

            if (!clsLicensesBusinessLayer.isLicenseExists(LicenseID))
            {
                lklShowLicensesHistory.Enabled = false;
                lklShowLicensesInfos.Enabled = false;
                btnReplace.Enabled = false;
                lblOldLicenseID.Text = "??";
                return;
            }

            if (!clsLicensesBusinessLayer.isLicenseActive(LicenseID))
            {
                lklShowLicensesHistory.Enabled = true;
                btnReplace.Enabled = false;
                lblOldLicenseID.Text = LicenseID.ToString();
            }
            else
            {
                lklShowLicensesHistory.Enabled = true;
                btnReplace.Enabled = true;
                lblOldLicenseID.Text = LicenseID.ToString();
            }
        }
        private void _SaveReplacedLicenseApplication()
        {
            clsGlobalSettings.PersonID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(clsGlobalSettings.LicenseID);

            _GetApplicationObjectInfos();

            if (MessageBox.Show("Are you sure to Replace the license?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

                if (clsGlobalSettings.Applications.Save())
                {

                    _GetLicenseObjectInfos();

                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

                    if (clsGlobalSettings.Licenses.Save())
                    {
                        clsLicensesBusinessLayer.DeactivateOldLicense(clsGlobalSettings.LicenseID);

                        MessageBox.Show("License Save successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("License Save Failed!");
                }
            }
            else
            {
                MessageBox.Show("License Save Cancelled!");

            }

            _UpdateApplicationInfosOnTheForm();
        }
        private void _UpdateApplicationInfosOnTheForm()
        {
            lblLRApplicationID.Text = clsGlobalSettings.Applications.ApplicationID.ToString();
            lblReplacedLicenseID.Text = clsGlobalSettings.Licenses.LicenseID.ToString();

            lklShowLicensesInfos.Enabled = true;
        }
        private void _GetApplicationObjectInfos()
        {
            clsGlobalSettings.Applications.ApplicantPersonID = clsGlobalSettings.PersonID;
            clsGlobalSettings.Applications.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            if (rbDamaged.Checked)
            {
                clsGlobalSettings.Applications.ApplicationTypeID = 4;

            }
            else
            {
                clsGlobalSettings.Applications.ApplicationTypeID = 3;
            }
            clsGlobalSettings.Applications.ApplicationStatus = 3;
            clsGlobalSettings.Applications.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            clsGlobalSettings.Applications.LastStatusDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Applications.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private void _GetLicenseObjectInfos()
        {
            clsGlobalSettings.Licenses.ApplicationID = clsGlobalSettings.Applications.ApplicationID;
            clsGlobalSettings.Licenses.DriverID = clsDriversBusinessLayer.GetDriverRelatedToPerson(clsGlobalSettings.PersonID);
            clsGlobalSettings.Licenses.LicenseClass = clsLicensesBusinessLayer.GetLicenseClassID(clsGlobalSettings.LicenseID);
            clsGlobalSettings.Licenses.IssueDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Licenses.ExpirationDate = Convert.ToDateTime(lblApplicationDate.Text).AddYears(10);
            clsGlobalSettings.Licenses.Notes = string.Empty;
            clsGlobalSettings.Licenses.PaidFees = 0;
            clsGlobalSettings.Licenses.IsActive = true;
            if (rbDamaged.Checked)
            {
                clsGlobalSettings.Licenses.IssueReason = 4;

            }
            else
            {
                clsGlobalSettings.Licenses.IssueReason = 3;
            }
            clsGlobalSettings.Licenses.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private void _DisableFilterBox()
        {
            //disable renew application
            ucReplacementForLostOrDamaged.Enabled = false;
        }


        //buttons
        private void frmReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            _LoadReplacementForLostOrDamagedLicenseForm();
        }
        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeFormTitleToReplacementType();
            _ChangeApplicationFees();
        }
        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeFormTitleToReplacementType();
            _ChangeApplicationFees();
        }
        private void lklShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseHistoryForm();
        }
        private void lklShowLicensesInfos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseInfosForm();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseReplacementLostOrDamagedForm();
        }
        private void ucReplacementForLostOrDamaged1_onClickSearch(int LicenseID)
        {
            _onCLickSearch(LicenseID);
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            _SaveReplacedLicenseApplication();
            _DisableFilterBox();
        }
    }
}
