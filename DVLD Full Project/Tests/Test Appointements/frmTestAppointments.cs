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
        public frmTestAppointments(int LDLApplicationID)
        {
            InitializeComponent();
            clsGlobalSettings.LocalDrivingLicenseApplicationID = LDLApplicationID;
        }
        //functions
        private void _CloseTestAppointementsForm()
        {
            this.Close();
        }
        private void _refreshTestAppointmentsData(int TestAppointmentID)
        {
            dgvTestAppointments.DataSource = clsTestAppointementsBusinessLayer.GetTestAppointmentByID(TestAppointmentID);
        }
        
        private void _refreshTestAppointmentsData()
        {
            dgvTestAppointments.DataSource = clsTestAppointementsBusinessLayer.GetAllTestAppointment();
        }
        private void _rowsCounter()
        {
            lblRecordsNumber.Text = dgvTestAppointments.RowCount.ToString();
        }
        private void _ShowSechduleTestAppointmentForm()
        {
            frmSechduleTest sechduleTest = new frmSechduleTest(-1);
            sechduleTest.RefreshTestAppointmentData += _refreshTestAppointmentsData;
            sechduleTest.RowsCounter += _rowsCounter;
            sechduleTest.ShowDialog();
        }
        private bool isPersonHasTestAppointment(int LDLApplcication)
        {
            return clsTestAppointementsBusinessLayer.isPersonHasTestAppointment(LDLApplcication);
        }
        private void _CheckIfTestAppointementExisits()
        {
            if (isPersonHasTestAppointment(clsGlobalSettings.LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("Person Already has test appointement");
            }
            else
            {
                _ShowSechduleTestAppointmentForm();
            }
        }
        private void _LoadTestAppointementForm()
        {
            
            _refreshTestAppointmentsData(clsGlobalSettings.TestAppointementID);
            _rowsCounter();            
        }

        private void EditSechudleTest()
        {
            int TestAppointmentID = Convert.ToInt32(dgvTestAppointments.CurrentRow.Cells[0].Value);
            frmSechduleTest sechduleTest = new frmSechduleTest(TestAppointmentID);

            //call refresh data grid view and rows counte after saving
            sechduleTest.RefreshTestAppointmentData += _refreshTestAppointmentsData;
            sechduleTest.RowsCounter += _rowsCounter;

            //show form
            sechduleTest.ShowDialog();
        }
        private void _ShowTakeTestForm()
        {
            int TestAppointmentID = Convert.ToInt32(dgvTestAppointments.CurrentRow.Cells[0].Value);  
            frmTakeTest TakeTest = new frmTakeTest(TestAppointmentID);
            TakeTest.RefreshTestAppointmentData += _refreshTestAppointmentsData;
            TakeTest.RowsCounter += _rowsCounter;
            TakeTest.ShowDialog();
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
    }
}
