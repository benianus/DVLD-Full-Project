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
using System.Xml;

namespace DVLD_Full_Project.Tests.Issue_Driver_Licnese
{
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        public delegate void eventRefreshLicenseDrivingLicenseApplicationsData();
        public delegate void eventRefreshRowsCounter();

        public event eventRefreshRowsCounter RefreshRowsCounter;
        public event eventRefreshLicenseDrivingLicenseApplicationsData RefreshLicenseDrivingLicenseApplicationsData;
        public frmIssueDriverLicenseForTheFirstTime()
        {
            InitializeComponent();
        }
        public frmIssueDriverLicenseForTheFirstTime(int LDLApplicationID)
        {
            InitializeComponent();
            clsGlobalSettings.LocalDrivingLicenseApplicationID = LDLApplicationID;
        }
        //Functions

        private void _CloseIssueDriverLicenseForTheFirstTimeForm()
        {
            RefreshLicenseDrivingLicenseApplicationsData();
            RefreshRowsCounter();
            this.Close();
        }
        private void _SaveIssueDriverLicenseForTheFirstTime()
        {
            clsGlobalSettings.Applications = clsApplicationsBusinessLayer.FindApplication(Convert.ToInt32(ucTestAppointments.ApplicationInfo.ApplicationID));

            _SavePersonAsDriver();

            _SaveLicense();
        }

        private void _SaveLicense()
        {

            //save (issue) the license
            clsGlobalSettings.Licenses.ApplicationID = Convert.ToInt32(ucTestAppointments.ApplicationInfo.ApplicationID);
            clsGlobalSettings.Licenses.DriverID = clsGlobalSettings.Drivers.DriverID;
            clsGlobalSettings.Licenses.LicenseClass = clsLicenseClassesBusinessLayer.GetLicenseClassID(ucTestAppointments.ApplicationInfo.ClassName);
            clsGlobalSettings.Licenses.IssueDate = DateTime.Now;
            clsGlobalSettings.Licenses.ExpirationDate = DateTime.Now.AddYears(clsLicenseClassesBusinessLayer.GetDefaultValidityLength(clsGlobalSettings.Licenses.LicenseClass));
            if (txtNotes.Text == string.Empty)
            {
                clsGlobalSettings.Licenses.Notes = string.Empty;
            }
            else
            {
                clsGlobalSettings.Licenses.Notes = txtNotes.Text;
            }
            clsGlobalSettings.Licenses.PaidFees = Convert.ToDecimal(ucTestAppointments.ApplicationInfo.PaidFees);
            clsGlobalSettings.Licenses.IsActive = true;
            clsGlobalSettings.Licenses.IssueReason = 1;
            clsGlobalSettings.Licenses.CreatedByUserID = clsGlobalSettings.User.UserID;

            //change the status of the application to completed
            clsGlobalSettings.Applications.ApplicationStatus = (int)clsGlobalSettings.enApplicationStatus.Completed;
            clsGlobalSettings.Applications.LastStatusDate = DateTime.Now;

            //issue the license

            if (clsGlobalSettings.Licenses.Save())
            {
                //update the status of the application to completed
                if (clsGlobalSettings.Applications.Save())
                {
                    MessageBox.Show("Driver License Issued successfully!");
                }
            }
            else
            {
                MessageBox.Show("Driver License Not issued successfully!");
            }
        }

        private void _SavePersonAsDriver()
        {

            if (isDriverAlreadyExists())
            {
                //if exists load it direclty to link it with the license
                clsGlobalSettings.Drivers = clsDriversBusinessLayer.FindDriverByPersonID(clsGlobalSettings.Applications.ApplicantPersonID);
                return;
            }
            else
            {
                clsGlobalSettings.Drivers = new clsDriversBusinessLayer();

                clsGlobalSettings.Drivers.PersonID = clsGlobalSettings.Applications.ApplicantPersonID;
                clsGlobalSettings.Drivers.CreatedByUserID = clsGlobalSettings.User.UserID;
                clsGlobalSettings.Drivers.CreatedDate = DateTime.Now;

                clsGlobalSettings.Drivers.Save();
            }

            //load the driver to link it with the license
            clsGlobalSettings.Drivers = clsDriversBusinessLayer.FindDriverByPersonID(clsGlobalSettings.Applications.ApplicantPersonID);

        }
        private bool isDriverAlreadyExists()
        {
            return clsDriversBusinessLayer.isDriverAlreadyExists(clsGlobalSettings.Applications.ApplicantPersonID);
        }
        private void _LoadIssueDriverLicenseForTheFirstTimeForm()
        {
            clsGlobalSettings.Licenses = new clsLicensesBusinessLayer();
        }
        //buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseIssueDriverLicenseForTheFirstTimeForm();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _SaveIssueDriverLicenseForTheFirstTime();
        }

        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadIssueDriverLicenseForTheFirstTimeForm();
            }
        }
    }
}
