using clsBusinessLayer;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
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
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        //functions
        private void _LoadLocalDrivingLicenseApplication()
        {

        }
        private void _RefreshLocalDrivingLicenseAppsData()
        {
            dgvLocalLicenseApplcations.DataSource = clsLocalDriverLicenseApplicationBusinessLayer.GetAllLocalDrivingLicenseApplications();
        }
        private void _RowsCounter()
        {
            lblRecordsNumber.Text = dgvLocalLicenseApplcations.RowCount.ToString();
        }
        private void _CLoseLocalDrivingLicenseApplication()
        {
            this.Close();
        }
        private void _AddNewLocalDrivingLicenseApplication()
        {
            frmAddNewLocalDrivingLicenseApplication AddNewLocalDrivingLicenseApplication = new frmAddNewLocalDrivingLicenseApplication();
            AddNewLocalDrivingLicenseApplication.ShowDialog();
        }
        //buttons
        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _RefreshLocalDrivingLicenseAppsData();
                _RowsCounter();
                _LoadLocalDrivingLicenseApplication();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _CLoseLocalDrivingLicenseApplication();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            _CLoseLocalDrivingLicenseApplication();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddNewLocalDrivingLicenseApplication();
        }
    }
}
