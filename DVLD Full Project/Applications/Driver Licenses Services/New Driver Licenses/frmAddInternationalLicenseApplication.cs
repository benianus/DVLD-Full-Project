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
        public frmAddInternationalLicenseApplication(int internationalLicenseID)
        {
            InitializeComponent();
            clsGlobalSettings.InternationalLicenseID = internationalLicenseID;
            if (clsGlobalSettings.InternationalLicenseID == -1)
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
                _ShowDriverInternationalLicenseApplicationIfModeAddNew();

                clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
                clsGlobalSettings.InternationalLicenses = new clsInternationalLicensesBusinessLayer();

                return;
            }

            _ShowDriverInternationalLicenseApplicationIfModeUpdate();
        }
        private void _ShowDriverInternationalLicenseApplicationIfModeUpdate()
        {
            lblILApplicationID.Text = clsGlobalSettings.Applications.ApplicationID.ToString();
            lblApplicationDate.Text = clsGlobalSettings.Applications.ApplicationDate.ToString();
            lblLicenseID.Text = clsGlobalSettings.InternationalLicenses.InternationalLicenseID.ToString();

            lklShowLicensesInfos.Enabled = true;
        }
        private void _ShowDriverInternationalLicenseApplicationIfModeAddNew()
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
        }
        private void _CloseAddInternationalLicenseApplicationForm()
        {
            this.Close();
        }
        private void _IfClickSearchForLicense(int LicenseID)
        {
            //load license Id globally
            clsGlobalSettings.LicenseID = LicenseID;

            if (_isPersonHasInternationalLicense())
            {
                MessageBox.Show("Person already an active international driving license with ID");

                lblLocalLicenseID.Text = LicenseID.ToString();
                lblILApplicationID.Text = "??";
                lblLicenseID.Text = "??";
                btnIssue.Enabled = false;
                lklShowLicensesHistory.Enabled = true;
                lklShowLicensesInfos.Enabled = true;

                clsGlobalSettings.InternationalLicenses = clsInternationalLicensesBusinessLayer.FindDriverInternationalLicense(LicenseID);

                //load international license id to show license infos
                clsGlobalSettings.InternationalLicenseID = clsGlobalSettings.InternationalLicenses.InternationalLicenseID;
            }
            else
            {
                if (clsLicensesBusinessLayer.isPersonHasLocalLicense(clsGlobalSettings.LicenseID))
                {
                    if (!_isPersonHasInternationalLicense())
                    {
                        //turn the mode to Addnew because the license doesn'thave an internaional license
                        //so we need to add one
                        clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
                        lblLocalLicenseID.Text = LicenseID.ToString();
                        lblILApplicationID.Text = "??";
                        lblLicenseID.Text = "??";
                        btnIssue.Enabled = true;
                        lklShowLicensesHistory.Enabled = true;
                        lklShowLicensesInfos.Enabled = false;

                    }
                }
                else
                {
                    lblLocalLicenseID.Text = "??";
                    lblILApplicationID.Text = "??";
                    lblLicenseID.Text = "??";
                    btnIssue.Enabled = false;
                    lklShowLicensesHistory.Enabled = false;
                    lklShowLicensesInfos.Enabled = false;
                }
            }
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
            clsGlobalSettings.PersonID = clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(clsGlobalSettings.LicenseID);
            
            _GetApplicationObjectInfos();

            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.Update)
            {
                if (clsGlobalSettings.Applications.Save())
                {
                    _GetInternationalObjectInfos();

                    if (clsGlobalSettings.InternationalLicenses.Save())
                    {
                        MessageBox.Show("International license saved successfully");
                    }
                    else
                    {
                        MessageBox.Show("International license save Failed");
                    }
                }
            }
            else
            {
                if (clsGlobalSettings.Applications.Save())
                {
                    _GetInternationalObjectInfos();

                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

                    if (clsGlobalSettings.InternationalLicenses.Save())
                    {
                        MessageBox.Show("International license saved successfully");
                    }
                    else
                    {
                        MessageBox.Show("International license save Failed");
                    }
                }
            }

            _LoadAddInternationalLicenseApplication();
        }
        private void _GetInternationalObjectInfos()
        {
            //save international license
            clsGlobalSettings.InternationalLicenses.ApplicationID = clsGlobalSettings.Applications.ApplicationID;
            clsGlobalSettings.InternationalLicenses.DriverID = clsDriversBusinessLayer.GetDriverRelatedToPerson(clsGlobalSettings.PersonID);
            clsGlobalSettings.InternationalLicenses.IssuedUsingLocalLicenseID = clsGlobalSettings.LicenseID;
            clsGlobalSettings.InternationalLicenses.IssueDate = Convert.ToDateTime(lblIssueDate.Text);
            clsGlobalSettings.InternationalLicenses.ExpirationDate = Convert.ToDateTime(lblExpirationDate.Text);
            clsGlobalSettings.InternationalLicenses.IsActive = true;
            clsGlobalSettings.InternationalLicenses.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private void _GetApplicationObjectInfos()
        {
            //save the application related to this internaltional license
            clsGlobalSettings.Applications.ApplicantPersonID = clsGlobalSettings.PersonID;
            clsGlobalSettings.Applications.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Applications.ApplicationTypeID = 6;
            clsGlobalSettings.Applications.ApplicationStatus = 1;
            clsGlobalSettings.Applications.LastStatusDate = DateTime.Now;
            clsGlobalSettings.Applications.PaidFees = Convert.ToDecimal(lblFees.Text);
            clsGlobalSettings.Applications.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private bool _isPersonHasInternationalLicense()
        {
            return clsInternationalLicensesBusinessLayer.isPersonHasInternationalLicense(clsGlobalSettings.LicenseID);
        }
        private int GetDriverRelatedToPerson(int personID)
        {
            return clsDriversBusinessLayer.GetDriverRelatedToPerson(personID);
        }
        private void _ShowInternationalLicenseInfosForm()
        {
            frmShowInternationalLicenseInfo showInternationalLicenseInfos = new frmShowInternationalLicenseInfo(clsGlobalSettings.InternationalLicenseID);
            showInternationalLicenseInfos.ShowDialog();
        }
        public void _DisableButtonsIfLicenseDoesNotHaveInternationalLicnese()
        {
            btnIssue.Enabled = false;
            lklShowLicensesHistory.Enabled = false; 
            lklShowLicensesInfos.Enabled = false;
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
        private void lklShowLicensesInfos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowInternationalLicenseInfosForm();
        }
    }
}
