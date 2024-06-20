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

namespace DVLD_Full_Project.Tests.Test_Appointements
{
    public partial class frmTakeTest : Form
    {
        public delegate void eventRefreshTestAppointmentData(int LDLApplicationID, int TestTypeID);
        public event eventRefreshTestAppointmentData RefreshTestAppointmentData;

        public delegate void eventRowsCounter();
        public event eventRowsCounter RowsCounter;
        public frmTakeTest()
        {
            InitializeComponent();
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        public frmTakeTest(int TestAppointmentID)
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
        private void _CloseTakeTestForm()
        {
            this.Close();
        }
        private void _LoadTakeTestForm()
        {

            //vision test
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                //Find test appointment related to this test and put in an object
                clsGlobalSettings.TestAppointements = clsTestAppointementsBusinessLayer.FindTestAppointment(clsGlobalSettings.TestAppointementID);

                ifModeAddNew();
                return;
            }

            //Find test appointment related to this test and put in an object
            clsGlobalSettings.TestAppointements = clsTestAppointementsBusinessLayer.FindTestAppointment(clsGlobalSettings.TestAppointementID);
            clsGlobalSettings.Tests = clsTestsBusinessLayer.FindTest(clsGlobalSettings.TestAppointementID);

            //Find test using test appointment
            ifModeUpdate();
        }
        private void ifModeUpdate()
        {
            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = _GetTestTrialNumber();
            lblDate.Text = clsGlobalSettings.TestAppointements.AppointmentDate.ToString();
            lblFees.Text = _GetTestTypeFees("Vision Test");
            lblTestID.Text = clsGlobalSettings.Tests.TestID.ToString();
            if (clsGlobalSettings.Tests.TestResult == false)
            {
                rbFail.Checked = true;
            }
            else
            {
                rbPass.Checked = true;
            }
        }
        private string _GetTestTrialNumber()
        {
            return clsTestAppointementsBusinessLayer._GetTestTrialNumber(ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID, (int)clsGlobalSettings.TestType).ToString();
        }
        private void ifModeAddNew()
        {
            clsGlobalSettings.Tests = new clsTestsBusinessLayer();

            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = _GetTestTrialNumber();
            lblDate.Text = clsGlobalSettings.TestAppointements.AppointmentDate.ToString();
            lblFees.Text = _GetTestTypeFees("Vision Test");
            lblTestID.Text = "Not Taken Yet";
        }
        private string _GetTestTypeFees(string TestTypeTitle)
        {
            return clsTestTypesBusinessLayer._GetTestTypeFees(TestTypeTitle);
        }
        private void _SaveTest()
        {
            clsGlobalSettings.Tests.TestAppointmentID = clsGlobalSettings.TestAppointementID;
            clsGlobalSettings.Tests.TestResult = _getTestResult();

            //verify if the notes are empty or not, notes value int Database allow null value
            if (txtNotes.Text == string.Empty)
            {
                clsGlobalSettings.Tests.Notes = string.Empty;
            }
            else
            {
                clsGlobalSettings.Tests.Notes = txtNotes.Text;
            }
            clsGlobalSettings.Tests.CreatedByUserID = clsGlobalSettings.TestAppointements.CreatedByUserID;

            //set the value of the test appointment IsLockec to true after passing the test appointment
            //whatever the test is pass or fail, set it to locked
            clsGlobalSettings.TestAppointements.IsLocked = true;

            //turn the testappointment to locked first
            if (MessageBox.Show("Are you sure, If click save you will not take it again", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //then save the test including the test appointment related to this test

                if (clsGlobalSettings.Tests.Save())
                {
                    //update the test appointment to Locked 
                    if (clsGlobalSettings.TestAppointements.Save())
                    {
                    
                        MessageBox.Show("Test appointment saved");
                        RefreshTestAppointmentData?.Invoke(clsGlobalSettings.TestAppointements.LocalDrivingLicenseApplicationID, (int)clsGlobalSettings.TestType);
                        RowsCounter?.Invoke();
                        this.Close();
                    }
                }
            }            
            else
            {
                MessageBox.Show("Test appointment not saved");
            }
        }
        private bool _getTestResult()
        {
            if (rbPass.Checked)
            {
                return true;
            }
            else if (rbFail.Checked)
            {
                return false;
            }
            return false;
        }

        //buttons

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadTakeTestForm();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseTakeTestForm();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveTest();
        }
    }
}
