using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses
{
    public partial class frmAddInternationalLicenseApplication : Form
    {
        public frmAddInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        //functions
        private void _LoadAddInternationalLicenseApplication()
        {

        }
        private void _CloseAddInternationalLicenseApplicationForm()
        {
            this.Close();
        }


        //buttons
        private void frmAddInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadAddInternationalLicenseApplication();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseAddInternationalLicenseApplicationForm();
        }
    }
}
