using clsBusinessLayer;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
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
    public partial class ucSearchInternationalLicenseApplication : UserControl
    {
       
        public event Action<int> onClickSearchForDriverLicense;
        protected virtual void ClickSearch(int LicenseID)
        {
            Action<int> Handler = onClickSearchForDriverLicense;
            if (Handler != null)
            {
                Handler(LicenseID);
            }
        }
        public ucSearchInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        //Functions
        private void _LoadSearchInternationalLicenseApplication()
        {
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                //License Infos
                lblClass.Text = "??";
                lblName.Text = "??";
                lblLicenseID.Text = "??";
                lblNationalNo.Text = "??";
                lblGendor.Text = "??";
                lblIssueDate.Text = "??";
                lblIssueReason.Text = "??";
                lblNotes.Text = "??";
                lblIsActive.Text = "??";
                lblDateOfBirth.Text = "??";
                lblDriverID.Text = "??";
                lblExpirationDate.Text = "??";
                lblIsDetained.Text = "??";
                pbPerson.ImageLocation = null;

                return;
            }

        }
        private void _LoadDriverLicenseInfos()
        {
            if (txtLiceneseID.Text == string.Empty)
            {
                return;
            }

            clsGlobalSettings.LicenseID = Convert.ToInt32(txtLiceneseID.Text);

            DataTable DriverLicenseInfosTable = _GetDriverLicenseInfos(clsGlobalSettings.LicenseID);

            if (DriverLicenseInfosTable == null)
            {
                MessageBox.Show("Driver License is doesn't exist, not Active, Expired or Not Ordinary Driving License Type");
                if (onClickSearchForDriverLicense != null)
                {
                    ClickSearch(clsGlobalSettings.LicenseID);
                }
                return;
            }

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

            //event whene search button clicked
            if (onClickSearchForDriverLicense != null)
            {
                ClickSearch(clsGlobalSettings.LicenseID);
            }
        }
        private DataTable _GetDriverLicenseInfos(int LicenseID)
        {
            return clsLicensesBusinessLayer.GetDriverLicenseInfos(LicenseID);
        }
        private bool _IsLicenseDetained(string LicenseID)
        {
            return clsDetainedLicensesBusinessLayer.isLicenseDetained(LicenseID);
        }

        //buttons
        private void ucSearchInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadSearchInternationalLicenseApplication();
            }
        }
        private void btnLicenseSearch_Click(object sender, EventArgs e)
        {
            _LoadDriverLicenseInfos();
        }
    }
}
