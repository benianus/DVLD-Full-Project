using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        public delegate void eventRereshLocalDrivingLicenseApplication();
        public event eventRereshLocalDrivingLicenseApplication RefreshLocalDrivingLicenseApplication;
        public frmAddEditLocalDrivingLicenseApplication(int ApplicationID)
        {
            InitializeComponent();
            clsGlobalSettings.ApplicationID = ApplicationID;
            if (clsGlobalSettings.ApplicationID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }

        //functions
        private void _CloseAddNewLocalDrivingLicenseApplicationForm()
        {
            RefreshLocalDrivingLicenseApplication?.Invoke();
            this.Close();
        }
        private void _GoToTheNextTabApplicationInfo()
        {
            tpPeronalApplicationInfo.SelectTab(tpApplicationInfo.Name);

            clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
            clsGlobalSettings.LocalDriverLicenseApplications = new clsLocalDriverLicenseApplicationBusinessLayer();  
        }
        private void _ReturnToThePreviousPersonalInfoTab()
        {
            tpPeronalApplicationInfo.SelectTab(tpPersonalInfo.Name);
        }
        private void _ShowAddNewLocalDrivingLicenseApplicationForm()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                lblApplicationDate.Text = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                cbLicsenseClass.SelectedIndex = 0;
                lblApplicatonFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("New Local Driving License Service").ToString();
                lblCreateBy.Text = clsGlobalSettings.User.UserName;
                clsGlobalSettings.Applications = new clsApplicationsBusinessLayer();
                return;
            }

            clsGlobalSettings.LocalDriverLicenseApplications = clsLocalDriverLicenseApplicationBusinessLayer.FindLocalDrivingLicenseApplication(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            clsGlobalSettings.Applications = clsApplicationsBusinessLayer.FindApplication(clsGlobalSettings.ApplicationID);

            _ShowUpdateLocalDrivingLicenseApplication();
        }
        private void _ShowUpdateLocalDrivingLicenseApplication()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.Update)
            {
                tpPeronalApplicationInfo.SelectTab(1);
                lblNewLocalDrivingLicense.Text = "Update Local Driver License Application";
                lblDLApplicationiD.Text = clsGlobalSettings.LocalDriverLicenseApplications.LocalDrivingLicenseApplicationID.ToString();
                lblApplicationDate.Text = clsGlobalSettings.Applications.ApplicationDate.ToString();
                cbLicsenseClass.SelectedIndex = clsLocalDriverLicenseApplicationBusinessLayer.GetLicenseClasseID(clsGlobalSettings.LocalDriverLicenseApplications.LocalDrivingLicenseApplicationID) - 1;
                lblApplicatonFees.Text = clsApplicationsTypesBusinessLayer._GetApplicationTypeFees("New Local Driving License Service").ToString();
                lblCreateBy.Text = clsGlobalSettings.User.UserName;
            }
        }
        private int GetLicenseClasseID(int LDLApplicationID)
        {
            return clsLocalDriverLicenseApplicationBusinessLayer.GetLicenseClasseID(LDLApplicationID);
        }
        private void _LoadLicenseClassToComboBox()
        {
            DataTable ClassesTable = clsLocalDriverLicenseApplicationBusinessLayer.GetLicenseClasses();
            foreach (DataRow rows in ClassesTable.Rows)
            {
                cbLicsenseClass.Items.Add(rows[0].ToString());
            }
        }
        private void _SaveApplicationsAndLocalLicenseApplication()
        {
            string NationalNo, ClassName;
            _GetConditionsToVerifyIfApplicationExists(out NationalNo, out ClassName);

            //verify if person has the minimum required age
            int age = new DateTime((DateTime.Now - clsGlobalSettings.Person.DateOfBirth).Ticks).Year;
            
            if (age < clsLicenseClassesBusinessLayer.GetMinimumAllowedAge(cbLicsenseClass.SelectedIndex + 1))
            {
                MessageBox.Show("Person Is not old to get the license classe!");
                return;
            }

            //verify if the application 'New' or 'Completed'
            if (clsLocalDriverLicenseApplicationBusinessLayer.isLocalApplcationNew(NationalNo, ClassName))
            {
                MessageBox.Show("Application already exists, Status: \'New\'");
            }
            else if(clsLocalDriverLicenseApplicationBusinessLayer.isLocalApplcationCompleted(NationalNo, ClassName))
            {
                MessageBox.Show("Application already exists, Status \'Completed\'");
            }
            else
            {
                _SaveApplication();
            }
        }
        private void _SaveApplication()
        {
            _GetApplicationsObjectInfos();

            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.Update)
            {
                _GetLocalDrivingLicenseObjectInfos();

                if (clsGlobalSettings.Applications.Save())
                {
                    if (clsGlobalSettings.LocalDriverLicenseApplications.Save())
                    {
                        MessageBox.Show("Application Saved");
                    }
                }
            }
            else
            {
                if (clsGlobalSettings.Applications.Save())
                {
                    _GetLocalDrivingLicenseObjectInfos();

                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;

                    if (clsGlobalSettings.LocalDriverLicenseApplications.Save())
                    {
                        MessageBox.Show("Application Saved");
                    }
                }
            }

            //fill the objects if exists
            clsGlobalSettings.LocalDriverLicenseApplications = clsLocalDriverLicenseApplicationBusinessLayer.FindLocalDrivingLicenseApplication(clsGlobalSettings.LocalDriverLicenseApplications.LocalDrivingLicenseApplicationID);
            clsGlobalSettings.Applications = clsApplicationsBusinessLayer.FindApplication(clsGlobalSettings.Applications.ApplicationID);

            _ShowUpdateLocalDrivingLicenseApplication();

        }
        private void _GetConditionsToVerifyIfApplicationExists(out string NationalNo, out string ClassName)
        {
            NationalNo = clsGlobalSettings.Person.NationalNo;
            ClassName = cbLicsenseClass.SelectedItem.ToString();
        }
        private void _GetApplicationsObjectInfos()
        {
            clsGlobalSettings.Applications.ApplicantPersonID = clsGlobalSettings.Person.PersonId;
            clsGlobalSettings.Applications.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Applications.ApplicationTypeID = 1;
            clsGlobalSettings.Applications.ApplicationStatus = 1;
            clsGlobalSettings.Applications.LastStatusDate = Convert.ToDateTime(lblApplicationDate.Text);
            clsGlobalSettings.Applications.PaidFees = 15;
            clsGlobalSettings.Applications.CreatedByUserID = clsGlobalSettings.User.UserID;
        }
        private void _GetLocalDrivingLicenseObjectInfos()
        {
            //local driving License application object
            clsGlobalSettings.LocalDriverLicenseApplications.ApplicationID = clsGlobalSettings.Applications.ApplicationID;
            clsGlobalSettings.LocalDriverLicenseApplications.LicenseClassID = cbLicsenseClass.SelectedIndex + 1;
        }
        
        //--------------
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
                _ShowAddNewLocalDrivingLicenseApplicationForm();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveApplicationsAndLocalLicenseApplication();
        }
    }
}
