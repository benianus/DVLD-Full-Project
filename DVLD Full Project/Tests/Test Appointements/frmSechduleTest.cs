using clsBusinessLayer;
using DVLD_Full_Project.Applications.Manage_Applications.Local_Driving_License_Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Tests.Test_Appointements
{
    public partial class frmSechduleTest : Form
    {
        public delegate void eventRefreshTestAppointmentData(int LDLApplicationID, int TestTypeID);
        public event eventRefreshTestAppointmentData RefreshTestAppointmentData;

        public delegate void eventRowsCounter();
        public event eventRowsCounter RowsCounter;
        public frmSechduleTest()
        {
            InitializeComponent();
        }
        public frmSechduleTest(int TestAppointmentID)
        {
            InitializeComponent();
            clsGlobalSettings.TestAppointementID = TestAppointmentID;
            if (clsGlobalSettings.TestAppointementID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }

        //Functions
        private void _CloseSechduleTestForm()
        {
            this.Close();   
        }
        private void _LoadScheduleTestForm()
        {
            //vision test
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                ifModeAddNew();
                return;
            }

            clsGlobalSettings.TestAppointements = clsTestAppointementsBusinessLayer.FindTestAppointment(clsGlobalSettings.TestAppointementID);
            ifModeUpdate();
        }
        private void ifModeUpdate()
        {
            if (isTestAppointmentLinkedToRetakeTestApplicationType())
            {
                LblTestType.Text = "Schedule Retake Test";
                lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
                lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
                lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
                lblTrial.Text = _GetTestTrialNumber();
                dtpDate.Value = clsGlobalSettings.TestAppointements.AppointmentDate;
                dtpDate.Enabled = true;
                lblFees.Text = _GetTestTypeFees(frmTestAppointments._GetTestTypeTitle());

                //retake test
                gbRetakeTestInfo.Enabled = true;
                lblRetakeFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Retake Test").ToString();
                lblTotalFees.Text = (Convert.ToInt32(lblFees.Text) + Convert.ToInt32(lblRetakeFees.Text)).ToString();
                lblTestAppID.Text = clsGlobalSettings.TestAppointementID.ToString();

                //disable save button
                btnSave.Enabled = true;
                return;
            }
            if (isTestAppointmentLocked())
            {
                LblTestType.Text = "Schedule Retake Test";
                _ShowWarningMessage();
                lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
                lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
                lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
                lblTrial.Text = _GetTestTrialNumber();
                dtpDate.Value = clsGlobalSettings.TestAppointements.AppointmentDate;
                dtpDate.Enabled = false;
                lblFees.Text = _GetTestTypeFees(frmTestAppointments._GetTestTypeTitle());

                //retake test
                gbRetakeTestInfo.Enabled = true;
                lblRetakeFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Retake Test").ToString(); ;
                lblTotalFees.Text = (Convert.ToInt32(lblFees.Text) + Convert.ToInt32(lblRetakeFees.Text)).ToString();
                lblTestAppID.Text = "N/A";

                //disable save button
                btnSave.Enabled = false;
                return;
            }

            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = _GetTestTrialNumber();
            dtpDate.Value = clsGlobalSettings.TestAppointements.AppointmentDate;
            lblFees.Text = _GetTestTypeFees(frmTestAppointments._GetTestTypeTitle());
            gbRetakeTestInfo.Enabled = false;

            //retake test
            lblRetakeFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Retake Test").ToString();
            lblTotalFees.Text = "0";
            lblTestAppID.Text = "N/A";
        }
        private bool isTestAppointmentLinkedToRetakeTestApplicationType()
        {
            return clsTestAppointementsBusinessLayer.isTestAppointmentLinkedToRetakeTestApplicationType(clsGlobalSettings.TestAppointementID);
        }
        private void _ShowWarningMessage()
        {
            lblWarningMessage.Text = "You cani't Edit the test, Please schedule a Retake Test";
            lblWarningMessage.ForeColor = Color.Red;
            lblWarningMessage.Visible = true;
        }
        private bool isTestAppointmentLocked()
        {
            return clsTestAppointementsBusinessLayer.isTestAppointmentLocked(clsGlobalSettings.TestAppointementID);
        }
        private void ifModeAddNew()
        {
            if (isPersonFailInTheTest())
            {
                clsGlobalSettings.TestAppointements = new clsTestAppointementsBusinessLayer();

                LblTestType.Text = "Schedule Retake Test";
                lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
                lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
                lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
                lblTrial.Text = _GetTestTrialNumber();
                dtpDate.Value = DateTime.Now;
                lblFees.Text = _GetTestTypeFees(frmTestAppointments._GetTestTypeTitle());


                //retake test
                gbRetakeTestInfo.Enabled = true;
                lblRetakeFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Retake Test").ToString();
                lblTotalFees.Text = (Convert.ToInt32(lblFees.Text)+ Convert.ToInt32(lblRetakeFees.Text)).ToString();
                lblTestAppID.Text = "N/A";

                return;
            }

            clsGlobalSettings.TestAppointements = new clsTestAppointementsBusinessLayer();

            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = _GetTestTrialNumber();
            dtpDate.Value = DateTime.Now;
            lblFees.Text = _GetTestTypeFees(frmTestAppointments._GetTestTypeTitle());
            gbRetakeTestInfo.Enabled = false;

            //retake test
            lblRetakeFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("Retake Test").ToString();
            lblTotalFees.Text = "0";
            lblTestAppID.Text = "N/A";
        }
        private bool isPersonFailInTheTest()
        {
            return clsTestAppointementsBusinessLayer.isPersonFailInTheTest(clsGlobalSettings.LocalDrivingLicenseApplicationID, (int)clsGlobalSettings.TestType);
        }
        private string _GetTestTrialNumber()
        {
            return clsTestAppointementsBusinessLayer._GetTestTrialNumber(ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID, (int)clsGlobalSettings.TestType).ToString();  
        }
        private string _GetTestTypeFees(string TestTypeTitle)
        {
            return clsTestTypesBusinessLayer._GetTestTypeFees(TestTypeTitle);
        }
        private void _SaveTestAppointmentAndRetakeApplication()
        {
            //Save Retake application if it's schedule retake test
            if (LblTestType.Text == "Schedule Retake Test")
            {
                if (MessageBox.Show("Are you sure", "Confirme", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    MessageBox.Show("Save cancelled");
                    return;
                }

                _SaveRetakeApplication();

                clsGlobalSettings.TestAppointements.TestTypeID = (int)clsGlobalSettings.TestType;
                clsGlobalSettings.TestAppointements.LocalDrivingLicenseApplicationID = Convert.ToInt32(ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID);

                //Add date validation for retake test, you can't add date before the last test appointment date from the same test type
                DateTime LastTestAppointmentDate = clsTestAppointementsBusinessLayer.GetLastTestAppointmentDate(Convert.ToInt32(ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID), (int)clsGlobalSettings.TestType);
                if (DateTime.Compare(dtpDate.Value, LastTestAppointmentDate) >= 0)
                {
                    clsGlobalSettings.TestAppointements.AppointmentDate = dtpDate.Value;
                }
                else
                {
                    MessageBox.Show("You can't add Date before last appointment date, please change date!");
                    return;
                }

                clsGlobalSettings.TestAppointements.PaidFees = Convert.ToDecimal(lblFees.Text);
                clsGlobalSettings.TestAppointements.CreatedByUserID = clsGlobalSettings.User.UserID;
                clsGlobalSettings.TestAppointements.IsLocked = false;
                clsGlobalSettings.TestAppointements.RetakeTestApplicationID = clsGlobalSettings.Applications.ApplicationID;

                //turn the mode to add new to save the test appointment linked to this retake application
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            
            //save or update test appointment
            _SaveTestAppointment();
        }
      
        private void _SaveTestAppointment()
        {
            clsGlobalSettings.TestAppointements.TestTypeID = (int)clsGlobalSettings.TestType;
            clsGlobalSettings.TestAppointements.LocalDrivingLicenseApplicationID = Convert.ToInt32(ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID);
            clsGlobalSettings.TestAppointements.AppointmentDate = dtpDate.Value;
            clsGlobalSettings.TestAppointements.PaidFees = Convert.ToDecimal(lblFees.Text);
            clsGlobalSettings.TestAppointements.CreatedByUserID = clsGlobalSettings.User.UserID;
            clsGlobalSettings.TestAppointements.IsLocked = false;

            if (clsGlobalSettings.TestAppointements.Save())
            {
                if (MessageBox.Show("Test appointment saved") == DialogResult.OK)
                {
                    RefreshTestAppointmentData?.Invoke(clsGlobalSettings.TestAppointements.LocalDrivingLicenseApplicationID, clsGlobalSettings.TestAppointements.TestTypeID);
                    RowsCounter?.Invoke();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Test appointment not saved");
            }
        }
       
        private static void _ChangeModeToAddNewOrUpdate()
        {
            //turn mode to addnew if it's in Update mode or vice Versa
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.Update)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }

        private void _SaveRetakeApplication()
        {
            //create new application with type retake
            clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();

            clsGlobalSettings.Applications.ApplicantPersonID = Convert.ToInt32(ucTestAppointments.ApplicationInfo.ApplicantPersonID);
            clsGlobalSettings.Applications.ApplicationDate = DateTime.Now;
            clsGlobalSettings.Applications.ApplicationTypeID = 8;
            clsGlobalSettings.Applications.ApplicationStatus = 1;
            clsGlobalSettings.Applications.LastStatusDate = DateTime.Now;
            clsGlobalSettings.Applications.PaidFees = Convert.ToInt32(lblTotalFees.Text);
            clsGlobalSettings.Applications.CreatedByUserID = clsGlobalSettings.User.UserID;

            clsGlobalSettings.Applications.Save();
        }
        private int _GetLicenseClassID(string ClassName)
        {
            return clsLicenseClassesBusinessLayer.GetLicenseClassID(ClassName);
        }


        //Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseSechduleTestForm();
        }
        private void frmSechduleTest_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadScheduleTestForm();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                _SaveTestAppointmentAndRetakeApplication();
            }
            else
            {
                _SaveTestAppointment();
            }
        }

    }
}
