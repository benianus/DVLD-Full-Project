using clsBusinessLayer;
using DVLD_Full_Project.Applications;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
using DVLD_Full_Project.Applications.Manage_Applications.Local_Driving_License_Applications;
using DVLD_Full_Project.Applications.Manage_Test_Types;
using DVLD_Full_Project.Drivers;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Functions
        private void _LoadManageUsersForm()
        {
            frmManageUsers manageUsers = new frmManageUsers();
            manageUsers.ShowDialog();
        }
        private static void _LoadManagePeopleForm()
        {
            frmManagePeople managePeople = new frmManagePeople();
            managePeople.ShowDialog();
        }
        private void _SingOut()
        {
            this.Close();
        }
        private void _ShowChangePasswordForm()
        {
            int PersonID = clsUserBusinessLayer.GetPersonIDofCurrentUser(clsGlobalSettings.User.UserID);
            frmChangePassword ChangePassword = new frmChangePassword(PersonID, clsGlobalSettings.User.UserID);
            ChangePassword.ShowDialog();
        }
        private void _ShowCurrentUserInfoForm()
        {
            int PersonID = clsUserBusinessLayer.GetPersonIDofCurrentUser(clsGlobalSettings.User.UserID);
            frmUserInfo UserInfo = new frmUserInfo(clsGlobalSettings.User.UserID, PersonID);
            UserInfo.ShowDialog();
        }
        private void _ShowManageApplicationTypesForm()
        {
            frmManageApplicationTypes ManageApplicationTypes = new frmManageApplicationTypes();
            ManageApplicationTypes.ShowDialog();
        }
        private void _showManageTestTypesForm()
        {
            frmManageTestTypes ManageTestTypes = new frmManageTestTypes();
            ManageTestTypes.ShowDialog();
        }
        private void _showAddNewLocalDrivingLicenseApplicationForm()
        {
            frmAddEditLocalDrivingLicenseApplication AddNewLocalDrivingLicenseApplicaton = new frmAddEditLocalDrivingLicenseApplication(-1);
            AddNewLocalDrivingLicenseApplicaton.ShowDialog();
        }
        private void _ShowManageLocalLicenseDrivingApplications()
        {
            frmLocalDrivingLicenseApplications ManageLDLApplications = new frmLocalDrivingLicenseApplications();    
            ManageLDLApplications.ShowDialog();
        }
        private void _showManageDriversForm()
        {
            frmManageDrivers manageDrivers = new frmManageDrivers();
            manageDrivers.ShowDialog();
        }
        private void _showAddNewInternationalApplicationForm()
        {
            frmAddInternationalLicenseApplication addInternationalLicenseApplication = new frmAddInternationalLicenseApplication(-1);
            addInternationalLicenseApplication.ShowDialog();
        }

        //Buttons
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadManagePeopleForm();
        }
        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SingOut();
        }
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadManageUsersForm();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowChangePasswordForm();
        }
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowCurrentUserInfoForm();
        }
        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageApplicationTypesForm();
        }
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showManageTestTypesForm();
        }
        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showAddNewLocalDrivingLicenseApplicationForm();
        }
        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageLocalLicenseDrivingApplications();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showManageDriversForm();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showAddNewInternationalApplicationForm();
        }
    }
}
