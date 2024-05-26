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
    public partial class ucPersonAddEdit : UserControl
    {
        public ucPersonAddEdit()
        {
            InitializeComponent();
        }

        public string NationalNO { get { return txtNationalId.Text; } }
        public string FirstName { get { return txtFirstName.Text; }  }
        public string SecondName { get { return txtSecondName.Text; } }
        public string ThirdName { get { return txtThirdName.Text; } }
        public string LastName { get { return txtLastName.Text; } }
        public DateTime DateOfBirth { get { return dtpDateOfBirth.Value; } }
        public int Gendor { get { return GetGendor(); } }
        public string Address { get { return txtAddress.Text; } }
        public string Email { get { return txtEmail.Text; } }
        public string Phone { get { return txtPhone.Text; } }
        public int NationinalityCountryID { get { return cbCountry.SelectedIndex; } }
        public string ImagePath { get { return GetImageLocation(); } }

        //Functions
        public string GetImageLocation()
        {
            if (pbPerson.Image != null)
            {
                return pbPerson.ImageLocation;
            }
            return "";
        }
        public int GetGendor()
        {
            if (rbFemale.Checked)
            {
                return 1;
            }
            else if (rbMale.Checked)
            {
                return 0;
            };

            return 0;
        }
        private void _ValidateFirstName(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                epNationalID.SetError(txtFirstName, "Field Required");
                txtFirstName.Focus();
            }
            else
            {
                e.Cancel = false;
                epNationalID.SetError(txtFirstName, string.Empty);
            }
        }
        private void _ValidateSecondName(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                e.Cancel = true;
                epNationalID.SetError(txtSecondName, "Field Rquired");
                txtSecondName.Focus();  
            }
            else
            {
                e.Cancel = false;
                epNationalID.SetError(txtSecondName, string.Empty);
            }
        }
        private void _ValidateLastName(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                epNationalID.SetError(txtLastName, "Field Required");
                txtLastName.Focus();
            }
            else
            {
                e.Cancel = false;
                epNationalID.SetError(txtLastName, string.Empty);
            }
        }
        private void _ValidateEmail(object sender, CancelEventArgs e)
        {
            
            if ((!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains(".")) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                epNationalID.SetError(txtEmail, "Write a correct email");
                txtEmail.Focus();
            }
            else
            {
                e.Cancel = false;
                epNationalID.SetError(txtEmail, string.Empty);
            }
        }
        private void _ValidatePhone(object sender, CancelEventArgs e)
        {
            bool isNumeric = int.TryParse(txtPhone.Text, out _);   
            if(string.IsNullOrEmpty(txtPhone.Text) || !isNumeric)
            {
                e.Cancel = true;
                epNationalID.SetError(txtPhone, "Field Required, should be number");
                txtPhone.Focus();
            }
            else
            {
                e.Cancel = false;
                epNationalID.SetError(txtPhone, string.Empty);
            }
        }
        private void _ValidateAddress(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                epNationalID.SetError(txtAddress, "Field Required");
                txtAddress.Focus();
            }
            else
            {
                e.Cancel = false;
                epNationalID.SetError(txtAddress, string.Empty);
            }
        }
        private void _ValidateNationalNumber(object sender, CancelEventArgs e)
        {
            if (clsPeopleBusinessLayer.isExistByNationalID(txtNationalId.Text))
            {
                e.Cancel = true;
                epNationalID.SetError(txtNationalId, "National Number already exists");
                txtNationalId.Focus();
            }
            else
            {
                e.Cancel = false;
                epNationalID.SetError(txtNationalId, string.Empty);
            }
        }
        private void _LoadCountryName()
        {
            DataTable dt = clsPeopleBusinessLayer.GetAllCountries();
            foreach (DataRow rows in dt.Rows)
            {
                cbCountry.Items.Add(rows["CountryName"]);
            }
        }
        public void _Load(object sender)
        {
            _LoadCountryName();
            if(clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                clsGlobalSettings.Person = new clsPeopleBusinessLayer();
                dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
                rbMale.Checked = true;
                cbCountry.SelectedItem = "Algeria";
                linklblRemove.Visible = false;
                return;
            }

            clsGlobalSettings.Person = clsPeopleBusinessLayer.FindPersonByPersonID(clsGlobalSettings.PersonID);
           
            if (clsGlobalSettings.Person == null)
            {
                MessageBox.Show("Peson not exist");
            }

            txtFirstName.Text = clsGlobalSettings.Person.FirstName;
            txtSecondName.Text = clsGlobalSettings.Person.SecondName;
            txtThirdName.Text = clsGlobalSettings.Person.ThirdName;
            txtLastName.Text = clsGlobalSettings.Person.LastName;
            txtNationalId.Text = clsGlobalSettings.Person.NationalNo;
            dtpDateOfBirth.Value = clsGlobalSettings.Person.DateOfBirth;
            if (clsGlobalSettings.Person.Gendor == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            txtPhone.Text = clsGlobalSettings.Person.Phone;
            txtEmail.Text = clsGlobalSettings.Person.Email;
            cbCountry.SelectedIndex = clsGlobalSettings.Person.NationalityCountryID;
            txtAddress.Text = clsGlobalSettings.Person.Address;
            if (clsGlobalSettings.Person.ImagePath != "")
            {
                pbPerson.ImageLocation = clsGlobalSettings.Person.ImagePath;
                linklblRemove.Visible = true;
            }
            else
            {
                pbPerson.ImageLocation = null;
                linklblRemove.Visible = false;
            }
        }
        private void _SetPersonImage()
        {
            openFileDialog1.DefaultExt = ".txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Filter = "File Formats| *.jpeg; *.png; *.jpg";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linklblRemove.Visible = true;
                string FilePath = openFileDialog1.FileName;
                pbPerson.ImageLocation = FilePath;
            }


        }
        private void _RemoveSetImage()
        {
            pbPerson.Image = null;
            linklblRemove.Visible = false;
            File.Delete(clsGlobalSettings.Person.ImagePath);
        }
        private void _DefaultLoadGendorPicture(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPerson.Image = Properties.Resources.Man;
            }
            else if (rbFemale.Checked)
            {
                pbPerson.Image = Properties.Resources.Women;
            }
        }
        
        public void UpdateUserControl(int PersonID)
        {
            clsGlobalSettings.Person.PersonId = PersonID;
            if (clsGlobalSettings.Person.PersonId == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            if (clsGlobalSettings.Person.PersonId > 0)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }
        
        //buttons
        private void ucPersonAddEdit_Load(object sender, EventArgs e)
        {
            _Load(sender);
        }
        private void txtNationalId_Validating(object sender, CancelEventArgs e)
        {
            _ValidateNationalNumber(sender, e);
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _DefaultLoadGendorPicture(sender, e);
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _DefaultLoadGendorPicture(sender, e);
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateFirstName(sender, e);
        }
        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateSecondName(sender, e);
        }
        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateLastName(sender, e);
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            _ValidatePhone(sender, e);
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmail(sender, e);
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            _ValidateAddress(sender, e);
        }
        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SetPersonImage();
        }
        private void linklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RemoveSetImage();
        }

    }
}
