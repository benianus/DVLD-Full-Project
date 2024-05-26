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
    public partial class ucPersonDetails : UserControl
    {
        public ucPersonDetails()
        {
            InitializeComponent();
        }
        //Functions
        private string _GetCountryName(int CountryID)
        {
            string CountryName = string.Empty;
            DataTable dt = clsPeopleBusinessLayer.GetCountryName(CountryID);
           
            DataRow rows = dt.Rows[0];
            CountryName = rows["CountryName"].ToString();

            return CountryName;
        }
        private void _LoadPersonDetails()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                _ShowPersonDetailsIfModeAddNew();
                return;
            }

            clsGlobalSettings.Person = clsPeopleBusinessLayer.FindPersonByPersonID(clsGlobalSettings.PersonID);
            _ShowPersonDetailsIfModeUpdae();
        }
        private void _ShowPersonDetailsIfModeAddNew()
        {
            lblPersonID.Text = "???";
            lblNationalNo.Text = "???";
            lblName.ForeColor = Color.Red;
            lblName.Text = "???";
            lblDateOfBirth.Text = "???";
            lblAddress.Text = "???";
            lblEmail.Text = "???";
            lblPhone.Text = "???";
            lblCountry.Text = "???";
            lblGendor.Text = "???";
            pbPersoPicture.ImageLocation = null;
        }
        public void _ShowPersonDetailsIfModeUpdae()
        {
            
            lblPersonID.Text = clsGlobalSettings.Person.PersonId.ToString();
            lblNationalNo.Text = clsGlobalSettings.Person.NationalNo;
            lblName.ForeColor = Color.Red;
            lblName.Text = _GetPersonFullName();
            lblDateOfBirth.Text = _GetDateOfBirth();
            lblAddress.Text = clsGlobalSettings.Person.Address;
            lblEmail.Text = clsGlobalSettings.Person.Email;
            lblPhone.Text = clsGlobalSettings.Person.Phone;
            lblCountry.Text = _GetCountryName(clsGlobalSettings.Person.NationalityCountryID);

            if (clsGlobalSettings.Person.Gendor == 0)
            {
                lblGendor.Text = "Male";
            }
            else
            {
                lblGendor.Text = "Female";
            }

            if (clsGlobalSettings.Person.ImagePath != null)
            {
                pbPersoPicture.ImageLocation = clsGlobalSettings.Person.ImagePath;
            }
            else
            {
                pbPersoPicture.ImageLocation = null;
            }
        }
        private string _GetDateOfBirth()
        {
            return $"{clsGlobalSettings.Person.DateOfBirth.Day.ToString()}/{clsGlobalSettings.Person.DateOfBirth.Month}/{clsGlobalSettings.Person.DateOfBirth.Year}";
        }
        private string _GetPersonFullName()
        {
            return $"{clsGlobalSettings.Person.FirstName} {clsGlobalSettings.Person.SecondName} {clsGlobalSettings.Person.ThirdName} {clsGlobalSettings.Person.LastName}";
        }
        private void _ShowEditPersonForm()
        {
            frmAddEditPerson AddEditPerson = new frmAddEditPerson(clsGlobalSettings.PersonID);
            AddEditPerson._SendBackToPersonDetails += _LoadPersonDetails;
            AddEditPerson.ShowDialog();
        }

        //Buttons
        private void ucPersonDetails_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                _LoadPersonDetails();
            }
            
        }
        private void linkLblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowEditPersonForm();
        }
                
    }
}
