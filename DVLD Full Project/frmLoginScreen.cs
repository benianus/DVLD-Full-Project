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
using System.IO;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace DVLD_Full_Project
{
    public partial class frmLoginScreen : Form
    {
        
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        //functions
        private void _Login()
        {
            string Username = txtUserName.Text;
            string Password = txtPassWord.Text;
            _CheckIfsUserExists(Username, Password);
        }
        private void _CloseLoginScreen()
        {
            this.Close();
            this.Dispose();
        }
        private void _CheckIfsUserExists(string Username, string Password)
        {
            //check if user exist in database
            if (clsUserBusinessLayer.isUserExist(Username, Password))
            {
                //check if the Active
                if (!clsUserBusinessLayer.isUserActive(Username, Password))
                {
                    MessageBox.Show("User exist, but it's not Active, Please contact Support");
                    return;
                }
                clsGlobalSettings.User = clsUserBusinessLayer.FindUser("UserName", Username);
                _LoadManagePeopleForm();
                _RememberMe(Username, Password);
            }
            else
            {
                MessageBox.Show("Wrong Password or Username");
            }
        }
        private void _LoadManagePeopleForm()
        {
            frmMain ManagePeople = new frmMain();
            ManagePeople.ShowDialog();
        }
        private void _RememberMe(string Username, string Password)
        {
            string keyName = @"HKEY_CURRENT_USER\Software\Login_Informations";
            
            string UserNameValueName = "Username";
            string UserNameValueData = Username.ToString();

            string PasswordValueName = "Password";
            string PasswordValueData = Password.ToString();

            if (checkBoxRememberMe.Checked)
            {
                try
                {
                    Registry.SetValue(keyName, UserNameValueName, UserNameValueData, RegistryValueKind.String);
                    Registry.SetValue(keyName, PasswordValueName, PasswordValueData, RegistryValueKind.String);
                }
                catch (Exception error)
                {
                    clsGlobalSettings.CreateEventLog(error);
                    throw;
                }
            }

            //string path = @"E:\Programming_Development\Programming advices\Programming advices Courses\Course 19 - Full Project in C#\DVLD Full Project\RegisterFile\LoginRegistered.txt";
            //string Contents = $"{Username}/{Password}";

            //if (checkBoxRememberMe.Checked && File.Exists(path))
            //{
            //    File.WriteAllText(path, Contents);
            //}
            //else
            //{
            //    File.WriteAllText(path, "");
            //}
        }
        
        private void _LoadLoginScreen()
        {
            string keyName = @"HKEY_CURRENT_USER\Software\Login_Informations";

            string UserNameValueName = "Username";
            string PasswordValueName = "Password";

            try
            {
                string username = (string)Registry.GetValue(keyName, UserNameValueName, null);
                string password = (string)Registry.GetValue(keyName, PasswordValueName, null);

                if (username == null && password == null)
                {
                    txtUserName.Text = string.Empty;
                    txtPassWord.Text = string.Empty;
                }
                else
                {
                    txtUserName.Text = username;
                    txtPassWord.Text = password;
                    checkBoxRememberMe.Checked = true;
                }
            }
            catch (Exception Error)
            {
                clsGlobalSettings.CreateEventLog(Error);
                throw;
            }

            /// old code using file
            /// now we use registry save
            /// 

            //string path = @"E:\Programming_Development\Programming advices\Programming advices Courses\Course 19 - Full Project in C#\DVLD Full Project\RegisterFile\LoginRegistered.txt";
            //string FileContent = File.ReadAllText(path);

            //if (File.Exists(path))
            //{
            //    _isLoginRegisterFileEmpty(FileContent);
            //}

        }
        private bool _isLoginRegisterFileEmpty(string FileContent)
        {
            if (FileContent.Length == 0)
            {
                txtUserName.Text = string.Empty;
                txtPassWord.Text = string.Empty;
                return false;
            }
            else
            {
                string[] loginInfos = FileContent.Split('/');

                string username = loginInfos[0];
                string password = loginInfos[1];

                txtUserName.Text = username;
                txtPassWord.Text = password;
                checkBoxRememberMe.Checked = true;

                return true;
            }
        }

        //buttons
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _Login();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            _LoadLoginScreen();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseLoginScreen();
        }

        private void CloseIfEscapeClicked(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _CloseLoginScreen();
            }
        }
    }
}
