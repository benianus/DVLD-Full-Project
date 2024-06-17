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

namespace DVLD_Full_Project.Licenses
{
    public partial class frmShowLicenseInfo : Form
    {
        public frmShowLicenseInfo()
        {
            InitializeComponent();
        }

        public frmShowLicenseInfo(int LDLApplicationID)
        {
            InitializeComponent();
            clsGlobalSettings.LocalDrivingLicenseApplicationID = LDLApplicationID;
        }
        private void _CloseShowDriverLicenseInfosForms()
        {
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseShowDriverLicenseInfosForms();
        }
    }
}
