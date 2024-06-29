using clsBusinessLayer;
using DVLD_Full_Project.Applications;
using DVLD_Full_Project.Applications.Detains_Licenses;
using DVLD_Full_Project.Applications.Driver_Licenses_Services;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.Renew_Driving_License;
using DVLD_Full_Project.Applications.Manage_Applications.International_Driving_License_Applications;
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
        private void _ShowManageInternationalLicenseApplications()
        {
            frmInternationalApplications internationalApplications = new frmInternationalApplications();
            internationalApplications.ShowDialog();
        }
        private void _ShowRenewLicenseApplicationForm()
        {
            frmRenewDrivingLicense renewLicenseApplication = new frmRenewDrivingLicense(-1);
            renewLicenseApplication.ShowDialog();
        }
        private void _ShowReplacementForDamagedOrLostLicenseForm()
        {
            frmReplacementForLostOrDamagedLicense replacementForDamagedOrLostLicense = new frmReplacementForLostOrDamagedLicense();
            replacementForDamagedOrLostLicense.ShowDialog();
        }
        private void _ShowDetainLicenseForm()
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }
        private void _ShowRealeaseLicenseForm()
        {
            frmReleaseLicense releaseLicense = new frmReleaseLicense(-1);
            releaseLicense.ShowDialog();    
        }
        private void _ShowManageDetainedLicensesForm()
        {
            frmManageDetainedLicenses manageDetainedLicenses = new frmManageDetainedLicenses();
            manageDetainedLicenses.ShowDialog();
        }
        private void _ShowReleaseDetianedLicenseForm()
        {
            frmReleaseLicense releaseLicense = new frmReleaseLicense(-1);
            releaseLicense.ShowDialog();
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

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageInternationalLicenseApplications();
        }

        private void renewDriverLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowRenewLicenseApplicationForm();
        }

        private void replacementForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowReplacementForDamagedOrLostLicenseForm();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageLocalLicenseDrivingApplications();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowDetainLicenseForm();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowRealeaseLicenseForm();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageDetainedLicensesForm();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowReleaseDetianedLicenseForm();
        }
    }
}
