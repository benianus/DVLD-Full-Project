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

namespace DVLD_Full_Project.Applications.Manage_Test_Types
{
    public partial class frmUpdateTestTypes : Form
    {
        public delegate void eventSendDataToManageTestTypesForm();
        public event eventSendDataToManageTestTypesForm refreshManageTestTypeData;
        public frmUpdateTestTypes(int TestTypeID)
        {
            InitializeComponent();
            clsGlobalSettings.TestTypeID = TestTypeID;
        }
        //Functions
        private void _LoadUpdateTestTypesForm()
        {
            //Fill and find the TestType object if exist
            clsGlobalSettings.TestTypes = clsTestTypesBusinessLayer.FindTestType(clsGlobalSettings.TestTypeID);

            lblTestTypeID.Text = clsGlobalSettings.TestTypeID.ToString();
            txtTitle.Text = clsGlobalSettings.TestTypes.TestTypeTitle;
            txtDescription.Text = clsGlobalSettings.TestTypes.TestTypeDescription;
            txtFees.Text = clsGlobalSettings.TestTypes.TestTypeFees.ToString();
        }
        private void _closeUpdateTestTypeForm()
        {
            refreshManageTestTypeData();
            this.Close();
        }
        private void _saveUpdatedTestType()
        {
            //fill the test types object with informations
            clsGlobalSettings.TestTypes.TestTypeTitle = txtTitle.Text;
            clsGlobalSettings.TestTypes.TestTypeDescription = txtDescription.Text;
            clsGlobalSettings.TestTypes.TestTypeFees = Convert.ToDecimal(txtFees.Text);

            //save function
            /**/
            if (clsGlobalSettings.TestTypes.Save())
            {
                MessageBox.Show("Test type save!");
            }
            else
            {
                MessageBox.Show("Test type failed to save");
            }
        }
        
        //buttons
        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadUpdateTestTypesForm();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _closeUpdateTestTypeForm();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _saveUpdatedTestType();
        }
    }
}
