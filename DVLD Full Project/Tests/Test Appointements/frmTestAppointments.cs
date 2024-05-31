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
        private void _ShowSechduleTestAppointmentForm()
        {
            frmSechduleTest sechduleTest = new frmSechduleTest();
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

        //button
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseTestAppointementsForm();
        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            _CheckIfTestAppointementExisits();
        }

        
    }
}
