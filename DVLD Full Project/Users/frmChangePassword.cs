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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            clsGlobalSettings.UserID = UserID;
            if (clsGlobalSettings.UserID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }
        public frmChangePassword(int PersonID, int UserID)
        {
            InitializeComponent();
            clsGlobalSettings.UserID = UserID;
            clsGlobalSettings.PersonID = PersonID;
            if (clsGlobalSettings.UserID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }
        //Functions
        private void _CloseChangePasswordForm()
        {
            this.Close();
        }
        private void _SaveNewPassword()
        {
            clsGlobalSettings.User.Password = clsGlobalSettings.ComputeHash(txtNewPassword.Text);

            if (clsGlobalSettings.User.Save())
            {
                MessageBox.Show("New Password Saved");
            }
            else
            {
                MessageBox.Show("Password not Saved");
            }
        }

        //Validations
        private void _ValidateCurrentPassword(object sender, CancelEventArgs e)
        {
            
            if(string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                epChangePassword.SetError(txtCurrentPassword, "Field Required");
                txtCurrentPassword.Focus();
            }
            else if (!(clsGlobalSettings.ComputeHash(txtCurrentPassword.Text) == clsGlobalSettings.User.Password))
            {
                e.Cancel = true;
                epChangePassword.SetError(txtCurrentPassword, "PassWord not match");
                txtCurrentPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                epChangePassword.SetError(txtCurrentPassword, string.Empty);
            }
        }
        private void _ValidateNewPassword(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                epChangePassword.SetError(txtNewPassword, "Field Required");
                txtNewPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                epChangePassword.SetError(txtNewPassword, string.Empty);
            }
        }
        private void _ValidateConfirmePassword(object sender, CancelEventArgs e)
        {
            if (txtConfirmePassword.Text == txtNewPassword.Text)
            {
                e.Cancel = true;
                epChangePassword.SetError(txtCurrentPassword, "PassWord not match");
                txtCurrentPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                epChangePassword.SetError(txtCurrentPassword, "Field Required");
                txtCurrentPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                epChangePassword.SetError(txtCurrentPassword, string.Empty) ;
            }
        }


        //buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseChangePasswordForm();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveNewPassword();
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            _ValidateCurrentPassword(sender, e);
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            _ValidateNewPassword(sender, e);
        }
        private void txtConfirmePassword_Validating(object sender, CancelEventArgs e)
        {
            _ValidateConfirmePassword(sender, e);
        }
    }
}
