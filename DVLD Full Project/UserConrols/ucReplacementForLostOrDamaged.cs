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

namespace DVLD_Full_Project.UserConrols
{
    public partial class ucReplacementForLostOrDamaged : UserControl
    {
        public ucReplacementForLostOrDamaged()
        {
            InitializeComponent();
        }

        public event Action<int> onClickSearch;
        protected virtual void ClickSearch(int LicenseID)
        {
            Action<int> Handler = onClickSearch;
            if (Handler != null)
            {
                Handler(LicenseID);
            }
        }
        
        //functions
        private void _LoadRenewLicenseApplicationUserControl()
        {
            lblClass.Text = "??";
            lblName.Text = "??";
            lblNationalNo.Text = "??";
            lblGendor.Text = "??";
            lblLicenseID.Text = "??";
            lblIssueDate.Text = "??";
            lblIssueReason.Text = "??";
            lblNotes.Text = "??";
            lblIsActive.Text = "??";
            lblDateOfBirth.Text = "??";
            lblDriverID.Text = "??";
            lblExpirationDate.Text = "??";
            pbPerson.ImageLocation = null;
            lblIsDetained.Text = "??";
        }
        private void _LoadDriverLicenseInfos()
        {
            if (txtLiceneseID.Text == string.Empty)
            {
                return;
            }

            clsGlobalSettings.LicenseID = Convert.ToInt32(txtLiceneseID.Text);
            if (!clsLicensesBusinessLayer.isLicenseExists(clsGlobalSettings.LicenseID))
            {
                MessageBox.Show("Driver License not Exists, choose an active one");
                _LoadRenewLicenseApplicationUserControl();

                if (onClickSearch != null)
                {
                    ClickSearch(clsGlobalSettings.LicenseID);
                }
                return;
            }
            //check if the license exists, active or expired
            if (!clsLicensesBusinessLayer.isLicenseActive(clsGlobalSettings.LicenseID))
            {
                MessageBox.Show("Driver License not Active, choose an active one");

                _LoadLicenseInfosToForm();

                if (onClickSearch != null)
                {
                    ClickSearch(clsGlobalSettings.LicenseID);
                }
                return;
            }

            _LoadLicenseInfosToForm();

            //event where search button clicked
            if (onClickSearch != null)
            {
                ClickSearch(clsGlobalSettings.LicenseID);
            }
        }
        private void _LoadLicenseInfosToForm()
        {
            DataTable DriverLicenseInfosTable = clsLicensesBusinessLayer.GetLicenseInfos(clsGlobalSettings.LicenseID);

            lblClass.Text = DriverLicenseInfosTable.Rows[0]["ClassName"].ToString();
            lblName.Text = DriverLicenseInfosTable.Rows[0]["Name"].ToString();
            lblLicenseID.Text = DriverLicenseInfosTable.Rows[0]["LicenseID"].ToString();
            lblNationalNo.Text = DriverLicenseInfosTable.Rows[0]["NationalNo"].ToString();
            lblGendor.Text = DriverLicenseInfosTable.Rows[0]["Gendor"].ToString();
            lblIssueDate.Text = DriverLicenseInfosTable.Rows[0]["IssueDate"].ToString();
            lblIssueReason.Text = DriverLicenseInfosTable.Rows[0]["IssueReason"].ToString();
            lblDateOfBirth.Text = DriverLicenseInfosTable.Rows[0]["DateOfBirth"].ToString();
            lblDriverID.Text = DriverLicenseInfosTable.Rows[0]["DriverID"].ToString();
            lblExpirationDate.Text = DriverLicenseInfosTable.Rows[0]["ExpirationDate"].ToString();
            pbPerson.ImageLocation = DriverLicenseInfosTable.Rows[0]["ImagePath"].ToString();

            if (_IsLicenseDetained(lblLicenseID.Text))
            {
                lblIsDetained.Text = "Yes";
            }
            else
            {
                lblIsDetained.Text = "No";
            }

            lblIsActive.Text = DriverLicenseInfosTable.Rows[0]["IsActive"].ToString();

            if (DriverLicenseInfosTable.Rows[0]["Notes"].ToString() == string.Empty)
            {
                lblNotes.Text = "No Notes";
            }
            else
            {
                lblNotes.Text = DriverLicenseInfosTable.Rows[0]["Notes"].ToString();
            }
        }
        
        private bool _IsLicenseDetained(string LicenseID)
        {
            return clsDetainedLicensesBusinessLayer.isLicenseDetained(LicenseID);
        }
        //buttons
        private void ucReplacementForLostOrDamaged_Load(object sender, EventArgs e)
        {
            _LoadRenewLicenseApplicationUserControl();
        }

        private void btnLicenseSearch_Click(object sender, EventArgs e)
        {
            _LoadDriverLicenseInfos();
        }
    }
}
