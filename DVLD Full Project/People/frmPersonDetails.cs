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
        //Properties

        //private int _PersonID;
        //public int PersonID { get { return _PersonID; } }

        //Constructors
        public frmPersonDetails()
        {
            InitializeComponent();
        }
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            if (PersonID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
                clsGlobalSettings.PersonID = PersonID;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                clsGlobalSettings.PersonID = PersonID;
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
            RefreshManagePeopleData.Invoke();
            this.Close();
        }

        //Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _Close();
            
        }

       
    }
}
