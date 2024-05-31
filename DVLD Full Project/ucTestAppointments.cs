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

namespace DVLD_Full_Project
{
    public partial class ucTestAppointments : UserControl
    {
        public ucTestAppointments()
        {
            InitializeComponent();
        }
        
        //functions
        private void _LoadUcTestAppointementsUserControl()
        {
            //driving License Application Info
            lblDLAppID.Text = clsGlobalSettings.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = _GetDrivingLicenseApplicationInfos("ClassName");
            lblPassedTests.Text = _GetDrivingLicenseApplicationInfos("PassedTestCount") +"/3";

            //Application Basic info
            lblApplicationID.Text = _GetApplicationInfos("ApplicationID");
            lblStatus.Text = _GetApplicationInfos("ApplicationStatus");
            lblFees.Text = _GetApplicationInfos("PaidFees");
            lblApplicationType.Text = _GetApplicationInfos("ApplicationTypeTitle");
            lblApplicantName.Text = _GetApplicationInfos("FullName");
            lblDate.Text = _GetApplicationInfos("ApplicationDate");
            lblStatusDate.Text = _GetApplicationInfos("LastStatusDate");
            lblCreatedBy.Text = _GetApplicationInfos("UserName");
        }
        private string _GetApplicationInfos(string ColumnName)
        {
            DataTable ApplicationsTable = clsApplicationsBusinessLayer.GetApplicationInfos(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            DataRow ApplicationRow = ApplicationsTable.Rows[0];

            return ApplicationRow[ColumnName].ToString();   
        }
        private string _GetDrivingLicenseApplicationInfos(string ColumnName)
        {
            DataTable LocalDriverLicenseApplicationsTable = clsLocalDriverLicenseApplicationBusinessLayer.GetDrivingLicenseApplicationInfo(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            DataRow dr = LocalDriverLicenseApplicationsTable.Rows[0];

            return dr[ColumnName].ToString();
        }
        private void _ShowPersonDetailsForm()
        {
            //get the personId 
            int Person = Convert.ToInt32(_GetApplicationInfos("ApplicantPersonID"));
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
