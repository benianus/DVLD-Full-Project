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
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }
        public frmUserInfo(int UserID, int PersonID)
        {
            InitializeComponent();
            clsGlobalSettings.PersonID = PersonID;
            clsGlobalSettings.UserID = UserID;
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }

        //Functions
        private void _CloseShowUserInfo()
        {
            this.Close();
        }


        //Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseShowUserInfo();
        }
    }
}
