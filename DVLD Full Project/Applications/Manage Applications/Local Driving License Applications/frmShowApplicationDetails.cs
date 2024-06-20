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

namespace DVLD_Full_Project.Applications.Manage_Applications.Local_Driving_License_Applications
{
    public partial class frmShowApplicationDetails : Form
    {
        public frmShowApplicationDetails(int LDLApplicationID)
        {
            InitializeComponent();
            clsGlobalSettings.LocalDrivingLicenseApplicationID = LDLApplicationID;
        }
        
        //functions
        private void _CloseShowApplicationDetailsForm()
        {
            this.Close();
        }

        //buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseShowApplicationDetailsForm();
        }
    }
}
