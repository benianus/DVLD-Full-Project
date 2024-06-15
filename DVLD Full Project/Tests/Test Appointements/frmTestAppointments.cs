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
    public partial class frmTestAppointments : Form
    {
        public delegate void eventRefreshLicenseDrivingLicenseApplicationsData();
        public delegate void eventRefreshRowsCounter();

        public event eventRefreshRowsCounter RefreshRowsCounter;
        public event eventRefreshLicenseDrivingLicenseApplicationsData RefreshLicenseDrivingLicenseApplicationsData;
        public frmTestAppointments(int LDLApplicationID)
        {
            InitializeComponent();
            clsGlobalSettings.LocalDrivingLicenseApplicationID = LDLApplicationID;
        }
        //functions
        private void _CloseTestAppointementsForm()
        {
            RefreshLicenseDrivingLicenseApplicationsData?.Invoke();
            RefreshRowsCounter?.Invoke();
            this.Close();
        }
        private void _refreshTestAppointmentsData()
        {
            dgvTestAppointments.DataSource = clsTestAppointementsBusinessLayer.GetAllTestAppointment();
        }
        private void _refreshTestAppointmentsData(int TestAppointmentID)
        {
            dgvTestAppointments.DataSource = clsTestAppointementsBusinessLayer.GetTestAppointmentByID(TestAppointmentID);
        }
        //
        private void _refreshTestAppointmentsDataByLDLApplicationID(int LDLApplicationID)
        {
            dgvTestAppointments.DataSource = clsTestAppointementsBusinessLayer.GetTestAppointmentByLDLApplicationID(LDLApplicationID);
        }
        
        private void _rowsCounter()
        {
            lblRecordsNumber.Text = dgvTestAppointments.RowCount.ToString();
        }
        private void _ShowSechduleTestAppointmentForm()
        {
            frmSechduleTest sechduleTest = new frmSechduleTest(-1);
            sechduleTest.RefreshTestAppointmentData += _refreshTestAppointmentsDataByLDLApplicationID;
            sechduleTest.RowsCounter += _rowsCounter;
            sechduleTest.ShowDialog();
        }
        private void _CheckIfTestAppointementExisits()
        {
            if (isPersonHasTestAppointment())
            {
                MessageBox.Show("Person Already has an active appointement for this test, you can not add new appointment");
            }
            else if (isPersonPassTestAppointment())
            {
                MessageBox.Show("Person Already pass the appointement for this test, you can't add Test Appointment");
            }
            else
            {
                _ShowSechduleTestAppointmentForm();
            }
        }
        
        private bool isPersonPassTestAppointment()
        {
            return clsTestAppointementsBusinessLayer.isPersonPassTestAppointment(clsGlobalSettings.LocalDrivingLicenseApplicationID);
        }
        private bool isPersonHasTestAppointment()
        {
            return clsTestAppointementsBusinessLayer.isPersonHasTestAppointment(clsGlobalSettings.LocalDrivingLicenseApplicationID);
        }
        private void _LoadTestAppointementForm()
        {
            _refreshTestAppointmentsDataByLDLApplicationID(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            _rowsCounter();            
        }

        private void EditSechudleTest()
        {
            int TestAppointmentID = Convert.ToInt32(dgvTestAppointments.CurrentRow.Cells[0].Value);
            frmSechduleTest sechduleTest = new frmSechduleTest(TestAppointmentID);

            //call refresh data grid view and rows counte after saving
            sechduleTest.RefreshTestAppointmentData += _refreshTestAppointmentsDataByLDLApplicationID;
            sechduleTest.RowsCounter += _rowsCounter;

            //show form
            sechduleTest.ShowDialog();
        }
        private void _ShowTakeTestForm()
        {
            //get the test appointment ID from the Data grid view
            int TestAppointmentID = Convert.ToInt32(dgvTestAppointments.CurrentRow.Cells[0].Value);
            
            //put the test appointment globally to use it during the program runtime
            clsGlobalSettings.TestAppointementID = TestAppointmentID;

            //initialize the take test form
            frmTakeTest TakeTest = null;

            //if not locked, load the taken test
            if (clsTestAppointementsBusinessLayer.isTestAppointmentLocked(TestAppointmentID))
            {
                TakeTest = new frmTakeTest(TestAppointmentID);
                TakeTest.RefreshTestAppointmentData += _refreshTestAppointmentsDataByLDLApplicationID;
                TakeTest.RowsCounter += _rowsCounter;
                TakeTest.ShowDialog();
                return;
            }

            //if the test appointment is locked create new test
            TakeTest = new frmTakeTest();
            TakeTest.RefreshTestAppointmentData += _refreshTestAppointmentsDataByLDLApplicationID;
            TakeTest.RowsCounter += _rowsCounter;
            TakeTest.ShowDialog();
            
        }
        private void _showOrHideTakeTestMenuStrip()
        {
            int testAppointmentID = Convert.ToInt32(dgvTestAppointments.CurrentRow.Cells[0].Value);
            if (clsTestAppointementsBusinessLayer.isTestAppointmentLocked(testAppointmentID))
            {
                tsmiTakeTest.Enabled = false;
            }
            else
            {
                tsmiTakeTest.Enabled = true;
            }
        }

        //button
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            _CheckIfTestAppointementExisits();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            _CloseTestAppointementsForm();
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestAppointementForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSechudleTest();
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowTakeTestForm();
        }

        private void cmsTestAppointment_Opened(object sender, EventArgs e)
        {
            _showOrHideTakeTestMenuStrip();
        }

        
    }
}
