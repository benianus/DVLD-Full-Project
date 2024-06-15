using clsBusinessLayer;
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
            lblDLAppID.Text = ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblAppliedForLicense.Text = ApplicationInfo.ClassName;
            lblPassedTests.Text = ApplicationInfo.PassedTestCount +"/3";

            //Application Basic info
            lblApplicationID.Text = ApplicationInfo.ApplicationID;
            lblStatus.Text = ApplicationInfo.ApplicationStatus;
            lblFees.Text = ApplicationInfo.PaidFees;
            lblApplicationType.Text = ApplicationInfo.ApplicationTypeTitle;
            lblApplicantName.Text = ApplicationInfo.FullName;
            lblDate.Text = ApplicationInfo.ApplicationDate;
            lblStatusDate.Text = ApplicationInfo.LastDateStatus;
            lblCreatedBy.Text = ApplicationInfo.Username;
        }
        private stApplicationInfo _GetAppInfos()
        {
            ApplicationInfo = new stApplicationInfo();
            DataTable LocalDriverLicenseApplicationsTable = clsLocalDriverLicenseApplicationBusinessLayer.GetDrivingLicenseApplicationInfo(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            DataRow dr = LocalDriverLicenseApplicationsTable.Rows[0];

            ApplicationInfo.LocalDrivingLicenseApplicationID = dr[0].ToString();
            ApplicationInfo.ApplicationID = dr[1].ToString();
            ApplicationInfo.ApplicationStatus = dr[2].ToString();
            ApplicationInfo.PaidFees = (Convert.ToInt32(dr[3])).ToString();
            ApplicationInfo.ApplicationTypeTitle = dr[4].ToString();
            ApplicationInfo.ClassName = dr[5].ToString();
            ApplicationInfo.FullName = dr[6].ToString();
            ApplicationInfo.ApplicationDate = dr[7].ToString();
            ApplicationInfo.LastDateStatus = dr[8].ToString();
            ApplicationInfo.PassedTestCount = dr[9].ToString();
            ApplicationInfo.Username = dr[10].ToString();
            ApplicationInfo.ApplicantPersonID = dr[11].ToString();

            return ApplicationInfo;
        }
        private void _ShowPersonDetailsForm()
        {
            //get the personId 
            int Person = Convert.ToInt32(ApplicationInfo.ApplicantPersonID);
            frmPersonDetails PersonDetails = new frmPersonDetails(Person);
            PersonDetails.ShowDialog();
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
    }
}
