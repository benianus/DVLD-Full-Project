using clsBusinessLayer;
using DVLD_Full_Project.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class ucTestAppointments : UserControl
    {
        public ucTestAppointments()
        {
            InitializeComponent();
        }
        public struct stApplicationInfo
        {
            public string LocalDrivingLicenseApplicationID;
            public string ApplicationID;
            public string ApplicationStatus;
            public string PaidFees;
            public string ApplicationTypeTitle;
            public string ClassName;
            public string FullName;
            public string ApplicationDate;
            public string LastDateStatus;
            public string PassedTestCount;
            public string Username;
            public string ApplicantPersonID;
        }

        public static stApplicationInfo ApplicationInfo;
        //functions
        private void _LoadUcTestAppointementsUserControl()
        {
            //get the application information
            ApplicationInfo = _GetAppInfos();

            //driving License Application Info
            _DrivingLicenseApplicationInfo();

            //show the link label if the actual application is linked to a driver licnese already issued
            _EnableShowLicenseInfoLinkLabel();

            //Application Basic info
            _ApplicationBasicInfo();
        }

        private void _ApplicationBasicInfo()
        {
            lblApplicationID.Text = ApplicationInfo.ApplicationID;
            lblStatus.Text = ApplicationInfo.ApplicationStatus;
            lblFees.Text = ApplicationInfo.PaidFees;
            lblApplicationType.Text = ApplicationInfo.ApplicationTypeTitle;
            lblApplicantName.Text = ApplicationInfo.FullName;
            lblDate.Text = ApplicationInfo.ApplicationDate;
            lblStatusDate.Text = ApplicationInfo.LastDateStatus;
            lblCreatedBy.Text = ApplicationInfo.Username;
        }

        private void _DrivingLicenseApplicationInfo()
        {
            lblDLAppID.Text = ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblAppliedForLicense.Text = ApplicationInfo.ClassName;
            lblPassedTests.Text = ApplicationInfo.PassedTestCount + "/3";
        }

        private void _EnableShowLicenseInfoLinkLabel()
        {
            if (isApplicationHasDriverLicense())
            {
                lblShowLicenseInfo.Enabled = true;
            }
            else
            {
                lblShowLicenseInfo.Enabled = false;
            }
        }

        private bool isApplicationHasDriverLicense()
        {
            return clsLicensesBusinessLayer.isApplicationHasDriverLicense(Convert.ToInt32(ApplicationInfo.ApplicationID));
        }
        private stApplicationInfo _GetAppInfos()
        {
            ApplicationInfo = new stApplicationInfo();
            DataTable LocalDriverLicenseApplicationsTable = clsLocalDriverLicenseApplicationBusinessLayer.GetDrivingLicenseApplicationInfo(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            DataRow LDLApplicationRow = LocalDriverLicenseApplicationsTable.Rows[0];

            ApplicationInfo.LocalDrivingLicenseApplicationID = LDLApplicationRow[0].ToString();
            ApplicationInfo.ApplicationID = LDLApplicationRow[1].ToString();
            ApplicationInfo.ApplicationStatus = LDLApplicationRow[2].ToString();
            ApplicationInfo.PaidFees = (Convert.ToInt32(LDLApplicationRow[3])).ToString();
            ApplicationInfo.ApplicationTypeTitle = LDLApplicationRow[4].ToString();
            ApplicationInfo.ClassName = LDLApplicationRow[5].ToString();
            ApplicationInfo.FullName = LDLApplicationRow[6].ToString();
            ApplicationInfo.ApplicationDate = LDLApplicationRow[7].ToString();
            ApplicationInfo.LastDateStatus = LDLApplicationRow[8].ToString();
            ApplicationInfo.PassedTestCount = LDLApplicationRow[9].ToString();
            ApplicationInfo.Username = LDLApplicationRow[10].ToString();
            ApplicationInfo.ApplicantPersonID = LDLApplicationRow[11].ToString();

            return ApplicationInfo;
        }
        private void _ShowPersonDetailsForm()
        {
            //get the personId 
            int Person = Convert.ToInt32(ApplicationInfo.ApplicantPersonID);
            frmPersonDetails PersonDetails = new frmPersonDetails(Person);
            PersonDetails.ShowDialog();
        }
        private void _ShowLicenseInfos()
        {
            frmShowLocalLicenseInfo showLicenseInfos = new frmShowLocalLicenseInfo(Convert.ToInt32(ApplicationInfo.ApplicationID));
            showLicenseInfos.ShowDialog();
        }
        //buttons
        private void ucTestAppointments_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadUcTestAppointementsUserControl();
            }
        }

        private void lkblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowPersonDetailsForm();
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseInfos();
        }
    }
}
