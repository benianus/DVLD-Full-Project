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
        public delegate void eventRefreshTestAppointmentData(int LDLApplicationID);
        public event eventRefreshTestAppointmentData RefreshTestAppointmentData;

        public delegate void eventRowsCounter();
        public event eventRowsCounter RowsCounter;
        public frmTakeTest()
        {
            InitializeComponent();
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
                ifModeAddNew();
                return;
            }
            
            //Find test appointment and put in an object
            clsGlobalSettings.TestAppointements = clsTestAppointementsBusinessLayer.FindTestAppointment(clsGlobalSettings.TestAppointementID);

            //Find test using test appointment
            clsGlobalSettings.Tests = new clsTestsBusinessLayer();
            ifModeUpdate();
        }

        private void ifModeUpdate()
        {
            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = "0";
            lblDate.Text = clsGlobalSettings.TestAppointements.AppointmentDate.ToString();
            lblFees.Text = _GetTestTypeFees("Vision Test");
            lblTestID.Text = "N/A";
        }
        private void ifModeAddNew()
        {
            clsGlobalSettings.TestAppointements = new clsTestAppointementsBusinessLayer();

            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = "0";
            lblDate.Text = clsGlobalSettings.TestAppointements.AppointmentDate.ToString();
            lblFees.Text = _GetTestTypeFees("Vision Test");
        }

        private string _GetTestTypeFees(string TestTypeTitle)
        {
            return clsTestTypesBusinessLayer._GetTestTypeFees(TestTypeTitle);
        }
        private void _SaveTest()
        {
            //
            clsGlobalSettings.Tests.TestAppointmentID = clsGlobalSettings.TestAppointementID;
            clsGlobalSettings.Tests.TestResult = _getTestResult();
            clsGlobalSettings.Tests.Notes = txtNotes.Text;
            clsGlobalSettings.Tests.CreatedByUserID = clsGlobalSettings.TestAppointements.CreatedByUserID;

            clsGlobalSettings.TestAppointements.IsLocked = true;

            if (clsGlobalSettings.TestAppointements.Save())
            {
                if (MessageBox.Show("Test appointment saved") == DialogResult.OK)
                {
                    RefreshTestAppointmentData?.Invoke(clsGlobalSettings.TestAppointements.TestAppointmentID);
                    RowsCounter?.Invoke();
                    this.Close();
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
