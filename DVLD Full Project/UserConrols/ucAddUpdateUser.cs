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
    public partial class ucAddUpdateUser : UserControl
    {
        public ucAddUpdateUser()
        {
            InitializeComponent();
        }

        //Functions
        private void _LoadAddUpdateUser()
        {
            _LoadFilters();
            _SetDefaultFilter();
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                /*create new user object if the user object is null (empty)*/
                if (clsGlobalSettings.User == null)
                {
                    clsGlobalSettings.User = new clsUserBusinessLayer();
                }
                clsGlobalSettings.Person = new clsPeopleBusinessLayer();

                _ShowPersonDetailsIfModeAddNew();
                return;
            }

            clsGlobalSettings.User = clsUserBusinessLayer.FindUser(clsGlobalSettings.User.UserID);
            clsGlobalSettings.Person = clsPeopleBusinessLayer.FindPersonByPersonID(clsGlobalSettings.PersonID);

            //Disabl filters in case Mode is update
            gbFilter.Enabled = false;
            _ShowPersonDetailsIfModeUpdate();
        }
        private void _LoadFilters()
        {
            cbAddNewUserFilter.Items.Add("PersonID");
            cbAddNewUserFilter.Items.Add("NationalNo");
        }
        private void _SetDefaultFilter()
        {
            cbAddNewUserFilter.SelectedIndex = 1;
        }
        private bool _FindAndLoadPersonDetails()
        {
            if (string.IsNullOrEmpty(txtSearchUser.Text))
            {
                clsGlobalSettings.Person = null;
                MessageBox.Show("You should enter a Filter");
                return true;
            }
            else if (!string.IsNullOrEmpty(txtSearchUser.Text))
            {
                string Filter = cbAddNewUserFilter.SelectedItem.ToString();
                string Condition = txtSearchUser.Text;
                clsGlobalSettings.Person = clsPeopleBusinessLayer.FindPersonByCondition(Filter, Condition);
                return false;
            }
            return false;
        }
        private string _GetCountryName(int CountryID)
        {
            string CountryName = string.Empty;
            
            DataTable dt = clsPeopleBusinessLayer.GetCountryName(CountryID);
            if (dt.Columns.Count == 0)
            {
                return string.Empty;
            }
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
            _ShowPersonDetailsIfModeUpdate();
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
        public void _ShowPersonDetailsIfModeUpdate()
        {
            cbAddNewUserFilter.SelectedIndex = 1;
            txtSearchUser.Text = clsGlobalSettings.Person.NationalNo.ToString();
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
        private void _ChangeFilterToPersonIdAfterAddingPerson()
        {
            cbAddNewUserFilter.SelectedItem = "PersonID";
            txtSearchUser.Text = clsGlobalSettings.Person.PersonId.ToString();
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
            frmAddEditPerson AddEditPerson = new frmAddEditPerson(clsGlobalSettings.Person.PersonId);
            AddEditPerson._SendBackToPersonDetails += _LoadPersonDetails;
            AddEditPerson.ShowDialog();
        }
        private void _ShowAddNewPersonForm()
        {
            frmAddEditPerson AddEditPerson = new frmAddEditPerson(-1);
            AddEditPerson.SendPersonToAddNewUser += _ShowPersonDetailsIfModeAddNew;
            AddEditPerson.SendPersonToAddNewUserUpdate += _ShowPersonDetailsIfModeUpdate;
            AddEditPerson.ChangeFilterAndFillSearchBox += _ChangeFilterToPersonIdAfterAddingPerson;
            AddEditPerson.ShowDialog();
        }

        //buttons
        private void AddUpdateUser_Load(object sender, EventArgs e)
        {
            _LoadAddUpdateUser();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (_FindAndLoadPersonDetails())
            {
                return;
            }

            if (clsGlobalSettings.Person != null)
            {
                gbFilter.Enabled = true;
                _ShowPersonDetailsIfModeUpdate();
                return;
            }
            else
            {
                gbFilter.Enabled = true;
                _ShowPersonDetailsIfModeAddNew();
                MessageBox.Show("Person is not exists in the system");
            }
        }
        private void linkLblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowEditPersonForm();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            _ShowAddNewPersonForm();
        }

        private void txtSearchUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
    

}
