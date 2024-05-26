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

namespace DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses
{
    public partial class frmAddNewLocalDrivingLicenseApplication : Form
    {
        public frmAddNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }

        //functions
        private void _CloseAddNewLocalDrivingLicenseApplicationForm()
        {
            this.Close();
        }
        private void _GoToTheNextTabApplicationInfo()
        {
            tpPeronalApplicationInfo.SelectTab(tpApplicationInfo.Name);
        }
        private void _ReturnToThePreviousPersonalInfoTab()
        {
            tpPeronalApplicationInfo.SelectTab(tpPersonalInfo.Name);
        }
        private void _LoadAddNewLocalDrivingLicenseApplicationForm()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                lblApplicationDate.Text = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                cbLicsenseClass.SelectedIndex = 0;
                lblApplicatonFees.Text = clsApplicationsTypesBusinessLayer.GetApplicationTypeFees("New Local Driving License Service").ToString();
                lblCreateBy.Text = clsGlobalSettings.User.UserName;
                clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
                return;
            }
        }
        private void _LoadLicenseClassToComboBox()
        {
            DataTable ClassesTable = clsLocalDriverLicenseApplicationBusinessLayer.GetLicenseClasses();
            foreach (DataRow rows in ClassesTable.Rows)
            {
                cbLicsenseClass.Items.Add(rows[0].ToString());
            }
        }
        private void _SaveLocalDrivingLicenseApplication()
        {
            clsGlobalSettings.Applications.ApplicantPersonID = clsGlobalSettings.Person.PersonId;
            clsGlobalSettings.Applications.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Applications.ApplicationTypeID = cbLicsenseClass.SelectedIndex;
            clsGlobalSettings.Applications.ApplicationStatus = 1;
            clsGlobalSettings.Applications.LastStatusDate = DateTime.Now;
            clsGlobalSettings.Applications.PaidFees = 15;
            clsGlobalSettings.Applications.CreatedByUserID = clsGlobalSettings.User.UserID;

            //check if person already have the appliction in the same license class
            if (clsApplicationsBusinessLayer.isApplicationsExists(clsGlobalSettings.Applications.ApplicantPersonID, clsGlobalSettings.Applications.ApplicationTypeID,
                clsGlobalSettings.Applications.ApplicationStatus))
            {
                //save applicatio to database
                if (clsGlobalSettings.Applications.Save())
                {
                    MessageBox.Show("Application Saved");
                }
                else
                {
                    MessageBox.Show("Application not Saved");
                }
            }
            else
            {
                MessageBox.Show("Person Already have same License type application");
            }


        }

        //buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseAddNewLocalDrivingLicenseApplicationForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _GoToTheNextTabApplicationInfo();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _ReturnToThePreviousPersonalInfoTab();
        }

        private void frmAddNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadLicenseClassToComboBox();
                _LoadAddNewLocalDrivingLicenseApplicationForm();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveLocalDrivingLicenseApplication();
        }
    }
}
