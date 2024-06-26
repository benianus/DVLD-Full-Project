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
    public partial class frmPersonDetails : Form
    {
        public delegate void EventRefreshDataTable();
        public event EventRefreshDataTable RefreshManagePeopleData;

        //Constructors
        public frmPersonDetails()
        {
            InitializeComponent();
        }
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            clsGlobalSettings.PersonID = PersonID;
            if (PersonID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
            
            _sendPersonIdToUserControl(clsGlobalSettings.PersonID);
        }

        //Functions
        private void _sendPersonIdToUserControl(int PersonID)
        {
            clsGlobalSettings.PersonID = PersonID;
        }
        private void _Close()
        {
            RefreshManagePeopleData?.Invoke();
            this.Close();
        }

        //Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _Close();
        }

       
    }
}
