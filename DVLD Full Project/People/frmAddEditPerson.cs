using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Full_Project
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void EventSendBackToPersonDetails();
        public event EventSendBackToPersonDetails _SendBackToPersonDetails;

        public delegate void eventSendPersonToAddNewUser();
        public event eventSendPersonToAddNewUser SendPersonToAddNewUser;
        public event eventSendPersonToAddNewUser SendPersonToAddNewUserUpdate;
        public event eventSendPersonToAddNewUser ChangeFilterAndFillSearchBox;
        public frmAddEditPerson()
        {
            InitializeComponent();
            
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            clsGlobalSettings.PersonID = PersonID;
            if (clsGlobalSettings.PersonID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            if (clsGlobalSettings.PersonID > 0)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }

        //Functions
        
        private void _LoadAddEditPerson()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                this.Text = "Add new person";
                lblAddEditPerson.Text = "Add new Person";
                return;
            }

            this.Text = "Update person";
            lblAddEditPerson.Text = $"Edit Pesron with ID = {clsGlobalSettings.PersonID}";
            lblPersonID.Text = clsGlobalSettings.Person.PersonId.ToString();
        }
        private void _ChangeModeToUpdate()
        {
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        private void _ChangeModeToAddNew()
        {
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        private void _CloseForm()
        {
            
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                _ChangeModeToAddNew();
                SendPersonToAddNewUser?.Invoke();
                this.Close();
                return;
            }
            _ChangeModeToUpdate();
            _SendBackToPersonDetails?.Invoke();
            SendPersonToAddNewUserUpdate?.Invoke();
            ChangeFilterAndFillSearchBox?.Invoke();
            
            this.Close();
        }

        private void _SavePersonImage()
        {
            Guid guid = Guid.NewGuid();
            string FileName = guid.ToString();
            string sourceFileName = ucPersonAddEdit.ImagePath;
            string destFileName = $"E:\\Programming_Development\\Programming advices\\Programming advices Courses\\Course 19 - Full Project in C#\\DVLD Full Project\\Images\\{FileName}{Path.GetExtension(sourceFileName)}";

            _CopyOrDeleteImageFile(sourceFileName, destFileName);

            _SavePerson(destFileName);

        }
        private void _CopyOrDeleteImageFile(string sourceFileName, string destFileName)
        {
            if (File.Exists(sourceFileName))
            {
                if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
                {
                    File.Copy(sourceFileName, destFileName, true);
                }

                if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.Update)
                {
                    File.Copy(sourceFileName, destFileName, true);
                    if (clsGlobalSettings.Person.ImagePath != "")
                    {
                        File.Delete(clsGlobalSettings.Person.ImagePath);
                    }

                }
            }
        }
        private void _SavePerson(string destFileName)
        {
            clsGlobalSettings.Person.NationalNo = ucPersonAddEdit.NationalNO;
            clsGlobalSettings.Person.FirstName = ucPersonAddEdit.FirstName;
            clsGlobalSettings.Person.SecondName = ucPersonAddEdit.SecondName;
            clsGlobalSettings.Person.ThirdName = ucPersonAddEdit.ThirdName;
            clsGlobalSettings.Person.LastName = ucPersonAddEdit.LastName;
            clsGlobalSettings.Person.DateOfBirth = ucPersonAddEdit.DateOfBirth;
            clsGlobalSettings.Person.Gendor = ucPersonAddEdit.Gendor;
            clsGlobalSettings.Person.Address = ucPersonAddEdit.Address;
            clsGlobalSettings.Person.Email = ucPersonAddEdit.Email;
            clsGlobalSettings.Person.Phone = ucPersonAddEdit.Phone;
            clsGlobalSettings.Person.NationalityCountryID = ucPersonAddEdit.NationinalityCountryID;
            if (ucPersonAddEdit.ImagePath != null)
            {
                clsGlobalSettings.Person.ImagePath = destFileName;
            }
            else
            {
                clsGlobalSettings.Person.ImagePath = null;
            }

            if (clsGlobalSettings.Person.Save())
            {
                MessageBox.Show("Person Saved!");
            }
            else
            {
                MessageBox.Show("Person not Saved");
            }
        }

        //buttons
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadAddEditPerson();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseForm();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SavePersonImage();
        }
    }
}
