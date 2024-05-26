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

namespace DVLD_Full_Project.Applications.ManageApplicationTypes
{
    
    public partial class frmUpdateApplicationType : Form
    {
        public delegate void eventSendDataToManageApplicationTypesForm();
        public event eventSendDataToManageApplicationTypesForm RefreshManageApplicationTypeData;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            clsGlobalSettings.ApplicationID = ApplicationTypeID;
        }
        //Function
        private void _LoadUpdateFormInfos()
        {
            //Find and fill the Application object if exists
            clsGlobalSettings.ApplicationType = clsApplicationsTypesBusinessLayer.FindApplicationType(clsGlobalSettings.ApplicationID);

            lblApplicationID.Text = clsGlobalSettings.ApplicationID.ToString();
            txtTitle.Text = clsGlobalSettings.ApplicationType.ApplicationTypeTitle;
            txtFees.Text = clsGlobalSettings.ApplicationType.ApplicationFees.ToString();

        }
        private void _CloseUpdateApplicationTypeForm()
        {
            RefreshManageApplicationTypeData?.Invoke();
            this.Close();
        }
        private void _SaveUpdateApplicationTypeInfos()
        {
            clsGlobalSettings.ApplicationType.ApplicationTypeTitle = txtTitle.Text;
            clsGlobalSettings.ApplicationType.ApplicationFees = Convert.ToDecimal(txtFees.Text);

            if (clsGlobalSettings.ApplicationType.Save())
            {
                MessageBox.Show("Application type save!");
            }
            else
            {
                MessageBox.Show("Application type not saved");
            }
        }

        //buttons
        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadUpdateFormInfos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseUpdateApplicationTypeForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveUpdateApplicationTypeInfos();
        }
    }
}
