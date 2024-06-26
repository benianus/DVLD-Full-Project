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
    public partial class frmShowLocalLicenseInfo : Form
    {
        public frmShowLocalLicenseInfo()
        {
            InitializeComponent();
        }

        public frmShowLocalLicenseInfo(int ApplicationID)
        {
            InitializeComponent();
            clsGlobalSettings.ApplicationID = ApplicationID;
            if (clsGlobalSettings.LocalDrivingLicenseApplicationID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
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
