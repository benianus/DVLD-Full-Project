using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some field are missing, please complete it");
                return;
            }

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

        private void frmUpdateTestTypes_Validating(object sender, CancelEventArgs e)
        {
            TextBox tempTextBox = (TextBox)sender;

            if (string.IsNullOrEmpty(tempTextBox.Text))
            {
                e.Cancel = true;
                epTestTypes.SetError(tempTextBox, "Filed required!");
                tempTextBox.Focus();
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            frmUpdateTestTypes_Validating(sender, e);
        }
        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            frmUpdateTestTypes_Validating(sender, e);
        }
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            frmUpdateTestTypes_Validating(sender, e);           
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                epTestTypes.SetError(txtFees, "Should be number");
            }

        }
    }
}
