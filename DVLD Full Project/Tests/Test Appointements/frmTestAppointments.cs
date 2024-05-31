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

        //button
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseTestAppointementsForm();
        }
    }
}
