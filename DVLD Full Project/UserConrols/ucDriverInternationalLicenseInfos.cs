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
    public partial class ucDriverInternationalLicenseInfos : UserControl
    {
        public ucDriverInternationalLicenseInfos()
        {
            InitializeComponent();
        }
        //functions
        private void _LoadDriverInternationalLicenseInfos()
        {
            DataTable InternationalLicenses = clsInternationalLicensesBusinessLayer.GetInternationalLicenseInfos(clsGlobalSettings.InternationalLicenseID);

            lblName.Text = InternationalLicenses.Rows[0]["FullName"].ToString();
            lblIntInternationalLicenseID.Text = InternationalLicenses.Rows[0]["InternationalLicenseID"].ToString();
            lblLicenseID.Text = InternationalLicenses.Rows[0]["IssuedUsingLocalLicenseID"].ToString();
            lblNationalNo.Text = InternationalLicenses.Rows[0]["NationalNo"].ToString();
            lblGendor.Text = InternationalLicenses.Rows[0]["Gendor"].ToString();
            lblIssueDate.Text = InternationalLicenses.Rows[0]["IssueDate"].ToString();
            lblApplicationID.Text = InternationalLicenses.Rows[0]["ApplicationID"].ToString();
            lblIsActive.Text = InternationalLicenses.Rows[0]["IsActive"].ToString();
            lblDateOfBirth.Text = InternationalLicenses.Rows[0]["DateOfBirth"].ToString();
            lblDriverID.Text = InternationalLicenses.Rows[0]["DriverID"].ToString();
            lblExpirationDate.Text = InternationalLicenses.Rows[0]["ExpirationDate"].ToString();

            if (InternationalLicenses.Rows[0]["ImagePath"].ToString() == string.Empty)
            {
                pbPerson.ImageLocation = null;
            }
            else
            {
                pbPerson.ImageLocation = InternationalLicenses.Rows[0]["ImagePath"].ToString();
            }
        }
        private void ucDriverInternationalLicenseInfos_Load(object sender, EventArgs e)
        {
            _LoadDriverInternationalLicenseInfos();
        }
    }
}
