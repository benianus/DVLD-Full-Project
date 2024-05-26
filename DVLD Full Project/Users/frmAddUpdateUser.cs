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
    public partial class frmAddUpdateUser : Form
    {
        public delegate void eventRefreshUsersTable();
        public event eventRefreshUsersTable RefreshUsersTable;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            
        }
        public frmAddUpdateUser(int PersonID)
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
        public frmAddUpdateUser(int PersonID, int UserID)
        {
            InitializeComponent();

            clsGlobalSettings.PersonID = PersonID;
            clsGlobalSettings.UserID = UserID;
            if (clsGlobalSettings.PersonID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            if (clsGlobalSettings.PersonID > 0)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }
        //functions
        private void _CloseAddUpdateUser()
        {
            RefreshUsersTable?.Invoke();
            this.Close();
        }
        private void _GoToTheNextTabLoginInfo()
        {
            tpPeronalLogininfo.SelectTab(tpLoginInfo.Name);
            
        }
        private void _ReturnToThePreviousPage()
        {
            tpPeronalLogininfo.SelectTab(tpPersonalInfo.Name);
        }
        private void _SavaUser()
        {
            clsGlobalSettings.User.PersonID = clsGlobalSettings.Person.PersonId;
            clsGlobalSettings.User.UserName = txtUserName.Text;
            clsGlobalSettings.User.Password = txtPassword.Text;
            clsGlobalSettings.User.IsActive = CBoxIsActive.Checked;

            if (clsGlobalSettings.User.Save())
            {
                MessageBox.Show("User Saved");
                _ShowUpdateUserForm();
            }
            else
            {
                MessageBox.Show("User not Saved");
            }
        }
        private void _ShowUpdateUserForm()
        {
            lblUsersID.Text = clsGlobalSettings.User.UserID.ToString();
            txtUserName.Text = clsGlobalSettings.User.UserName.ToString();
            txtPassword.Text = clsGlobalSettings.User.Password.ToString();
            txtConfirmePassword.Text = clsGlobalSettings.User.Password.ToString();
            CBoxIsActive.Checked = clsGlobalSettings.User.IsActive;
        }

        //validation
        private void _ValidateAndConfirmePassword(CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmePassword.Text))
            {
                e.Cancel = true;
                epAddUpdateUser.SetError(txtConfirmePassword, "Fiel Required");
                txtConfirmePassword.Focus();

            }
            else if (txtConfirmePassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                epAddUpdateUser.SetError(txtConfirmePassword, "Password do not match");
                txtConfirmePassword.Focus();
            }
            else
            {
                e.Cancel = false;
                epAddUpdateUser.SetError(txtConfirmePassword, string.Empty);
            }
        }
        private void _ValidateUserName(CancelEventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                e.Cancel = true;
                epAddUpdateUser.SetError(txtUserName, "Field Required");
                txtUserName.Focus();
            }
            else
            {
                e.Cancel = false;
                epAddUpdateUser.SetError(txtUserName, string.Empty);
            }
        }
        private void _ValidatePassword(CancelEventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                e.Cancel = true;
                epAddUpdateUser.SetError(txtPassword, "Password Required");
                txtPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                epAddUpdateUser.SetError(txtPassword, string.Empty);
            }
        }
       
        //buttons

        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseAddUpdateUser();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUserBusinessLayer.isUserLinkedToPerson(clsGlobalSettings.PersonID))
            {
                MessageBox.Show("Person Already linked to a user");
            }
            else
            {
                _GoToTheNextTabLoginInfo();
            }
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateUserName(e);
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            _ValidatePassword(e);
        }
        private void txtConfirmePassword_Validating(object sender, CancelEventArgs e)
        {
            _ValidateAndConfirmePassword(e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SavaUser();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _ReturnToThePreviousPage();
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                this.Text = "Add New user";
                return;
            }

            this.Text = "Update user";
            lblAddUpdateUser.Text = "Update User";
            lblUsersID.Text = clsGlobalSettings.User.UserID.ToString();
            txtUserName.Text = clsGlobalSettings.User.UserName;
            txtPassword.Text = clsGlobalSettings.User.Password;
            txtConfirmePassword.Text = clsGlobalSettings.User.Password;
            CBoxIsActive.Checked = clsGlobalSettings.User.IsActive;
        }
    }
}
