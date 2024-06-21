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

namespace DVLD_Full_Project
{
    public partial class ucInternationaApplicationInfos : UserControl
    {
        public ucInternationaApplicationInfos()
        {
            InitializeComponent();
        }
        //functions
        private void _LoadInternationalApplicationInfosForm()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                lblILApplicationID.Text = "??";
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblIssueDate.Text = DateTime.Now.ToString();
                lblLicenseID.Text = "??";
                lblLocalLicenseID.Text = "??";
                lblExpirationDate.Text = DateTime.Now.AddDays(1).ToString();
                lblCreatedBy.Text = clsGlobalSettings.User.UserName;
            }
        }
        private void ucInternationaApplicationInfos_Load(object sender, EventArgs e)
        {
            _LoadInternationalApplicationInfosForm();
        }
    }
}
