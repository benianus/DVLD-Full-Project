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
    public partial class ucPersonLoginInfo : UserControl
    {
        public ucPersonLoginInfo()
        {
            InitializeComponent();
        }
        //Functions
        private void _LoadLoginInfo()
        {
            clsGlobalSettings.User = clsUserBusinessLayer.FindUser(clsGlobalSettings.UserID);

            lblUserID.Text = clsGlobalSettings.User.UserID.ToString();
            lblUserName.Text = clsGlobalSettings.User.UserName;
            if (clsGlobalSettings.User.IsActive == true)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
            
        }
        //butttons
        private void ucPersonLoginInfo_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadLoginInfo();
            }
        }
    }
}
