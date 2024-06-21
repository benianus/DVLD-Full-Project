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
    public partial class ucDriverLicenseInfo : UserControl
    {
        public ucDriverLicenseInfo()
        {
            InitializeComponent();
        }
       
        public struct stDriverLicenseInfos
        {
            public string Class;
            public string Name;
            public string LicenseID;
            public string NationalNO;
            public string Gendor;
            public string IssueDate;
            public string IssueReason;
            public string Notes;
            public string IsActive;
            public string DateOfBirth;
            public string DriverID;
            public string ExpirationDate;
            public string IsDetained;
            public string ImagePath;
        }

        public static stDriverLicenseInfos DriverLicenseInfos;

        //functions
        private stDriverLicenseInfos _GetDriverLicenseInfos()
        {
            DataTable DriverLicenseInfosTable = clsDriversBusinessLayer.GetDriverLicenseInfosByLDLApplicationID(clsGlobalSettings.LocalDrivingLicenseApplicationID);
            
            DriverLicenseInfos.Class = DriverLicenseInfosTable.Rows[0]["ClassName"].ToString();
            DriverLicenseInfos.Name = DriverLicenseInfosTable.Rows[0]["Name"].ToString();
            DriverLicenseInfos.LicenseID = DriverLicenseInfosTable.Rows[0]["LicenseID"].ToString();
            DriverLicenseInfos.NationalNO = DriverLicenseInfosTable.Rows[0]["NationalNo"].ToString();
            DriverLicenseInfos.Gendor = DriverLicenseInfosTable.Rows[0]["Gendor"].ToString();
            DriverLicenseInfos.IssueDate = DriverLicenseInfosTable.Rows[0]["IssueDate"].ToString();
            DriverLicenseInfos.IssueReason = DriverLicenseInfosTable.Rows[0]["IssueReason"].ToString();
            DriverLicenseInfos.DateOfBirth = DriverLicenseInfosTable.Rows[0]["DateOfBirth"].ToString();
            DriverLicenseInfos.DriverID = DriverLicenseInfosTable.Rows[0]["DriverID"].ToString();
            DriverLicenseInfos.ExpirationDate = DriverLicenseInfosTable.Rows[0]["ExpirationDate"].ToString();
            DriverLicenseInfos.ImagePath = DriverLicenseInfosTable.Rows[0]["ImagePath"].ToString();

            if (_IsLicenseDetained(DriverLicenseInfos.LicenseID))
            {
                DriverLicenseInfos.IsDetained = "Yes";
            }
            else
            {
                DriverLicenseInfos.IsDetained = "No";
            }

            return DriverLicenseInfos;
        }
        private bool _IsLicenseDetained(string LicenseID)
        {
            return clsDetainedLicensesBusinessLayer.isLicenseDetained(LicenseID);
        }
        private void _LoadDriverLicenseInfoUserControl()
        {

            DriverLicenseInfos = _GetDriverLicenseInfos();

            lblClass.Text = DriverLicenseInfos.Class;
            lblName.Text = DriverLicenseInfos.Name;
            lblLicenseID.Text = DriverLicenseInfos.LicenseID;
            lblNationalNo.Text = DriverLicenseInfos.NationalNO;
            lblGendor.Text = DriverLicenseInfos.Gendor;
            lblIssueDate.Text = DriverLicenseInfos.IssueDate;
            lblIssueReason.Text = DriverLicenseInfos.IssueReason;
            if (DriverLicenseInfos.Notes == null)
            {
                lblNotes.Text = "No Notes";
            }
            else
            {
                lblNotes.Text = DriverLicenseInfos.Notes;
            }
            lblIsActive.Text = DriverLicenseInfos.IsActive;
            lblDateOfBirth.Text = DriverLicenseInfos.DateOfBirth;
            lblDriverID.Text = DriverLicenseInfos.DriverID;
            lblExpirationDate.Text = DriverLicenseInfos.ExpirationDate;
            lblIsDetained.Text = DriverLicenseInfos.IsDetained;
            pbPerson.ImageLocation = DriverLicenseInfos.ImagePath;
        }

        //buttons
        private void ucDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadDriverLicenseInfoUserControl();
            }
        }
    }
}
