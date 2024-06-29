using clsBusinessLayer;
using DVLD_Full_Project.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Applications.Detains_Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        //functions
        private void _LoadManageDetainedLicenses()
        {
            _RefreshDetainedLicenseData(cbFilters.Text, txtFilterBy.Text);
            _RowsCounter();
            _LoadFilters();
            _ShowAndHideSearchBox();
        }
        private void _LoadFilters()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("DetainID");
            cbFilters.Items.Add("LicenseID");
            cbFilters.Items.Add("IsReleased");
            cbFilters.Items.Add("NationalNo");
            cbFilters.Items.Add("FullName");
            cbFilters.Items.Add("ReleaseApplicationID");

            //default filter
            cbFilters.SelectedItem = "None";
        }
        private void _RefreshDetainedLicenseData(string filter = "", string condition = "")
        {
            dgvDetainedLicenses.DataSource = clsDetainedLicensesBusinessLayer.GetDetainedLicenses(filter, condition);
        }
        private void _RowsCounter()
        {
            lblRecordsNumber.Text = dgvDetainedLicenses.RowCount.ToString();
        }
        private void _ShowAndHideSearchBox()
        {
            switch (cbFilters.Text)
            {
                case "None":
                    txtFilterBy.Visible = false;
                    txtFilterBy.Clear();
                    break;
                default:
                    txtFilterBy.Visible = true;
                    txtFilterBy.Clear();
                    break;
            }
        }
        private void _CloseManageDetainedLicensesForm()
        {
            this.Close();
        }
        private void _ShowPersonDetailsForm()
        {
            frmPersonDetails personDetails = new frmPersonDetails(clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value)));
            personDetails.ShowDialog();
        }
        private void _ShowLicenseDetailsForm()
        {
            frmShowLocalLicenseInfo showLocalLicenseInfos = new frmShowLocalLicenseInfo(clsLicensesBusinessLayer.GetApplicationIDRelatedToLicense(Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value)));
            showLocalLicenseInfos.ShowDialog();
        }
        private void _ShowPersonLicensesHistoryForm()
        {
            frmShowLicenseHistory showLicenseHistory = new frmShowLicenseHistory(clsApplicationsBusinessLayer.GetPersonIDRelatedToLocalLicenseByLicenseID(Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value)));
            showLicenseHistory.ShowDialog();
        }
        private void _ShowAndHideReleaseDetainedLicenseOptionFromMenuStrip()
        {
            bool isReleased = Convert.ToBoolean(dgvDetainedLicenses.CurrentRow.Cells["IsReleased"].Value);
            switch (isReleased)
            {
                case true:
                    tsReleaseDetainedLicense.Enabled = false;
                    break;
                default:
                    tsReleaseDetainedLicense.Enabled = true;
                    break;
            }
        }
        private void _showDetainLicenseForm()
        {
            frmDetainLicense detainLicense = new frmDetainLicense();

            detainLicense._RefreshDetainedLicenseData += _RefreshDetainedLicenseData;
            detainLicense._RefreshRowsCounter += _RowsCounter;
            detainLicense._RefreshFilterAndSearchBox += _RefreshFilterSearchBox;

            detainLicense.ShowDialog();
        }
        private void _ShowReleaseDetainedLicenseForm()
        {
            frmReleaseLicense releaseLicense = new frmReleaseLicense(-1);
           
            releaseLicense._RefreshDetainedLicenseDate += _RefreshDetainedLicenseData;
            releaseLicense._RefreshRowsCounter += _RowsCounter;
            releaseLicense._RefreshFilterSearchBox += _RefreshFilterSearchBox;
           
            releaseLicense.ShowDialog();
        }
        private void _ShowReleaseSpecificDetainedLicense()
        {
            //get detainID and licenseID
            frmReleaseLicense releaseLicense = new frmReleaseLicense(Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value));
            
            releaseLicense._RefreshDetainedLicenseDate += _RefreshDetainedLicenseData;
            releaseLicense._RefreshRowsCounter += _RowsCounter;
            releaseLicense._RefreshFilterSearchBox += _RefreshFilterSearchBox;
            
            releaseLicense.ShowDialog();
        }
        private void _RefreshFilterSearchBox()
        {
            cbFilters.SelectedItem = "None";
            txtFilterBy.Clear();
        }

        //buttons
        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadManageDetainedLicenses();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseManageDetainedLicensesForm();
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ShowAndHideSearchBox();
            _RefreshDetainedLicenseData(cbFilters.Text, txtFilterBy.Text);
            _RowsCounter();

        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            _RefreshDetainedLicenseData(cbFilters.Text, txtFilterBy.Text);
            _RowsCounter();
        }
        private void tsPersonDetails_Click(object sender, EventArgs e)
        {
            _ShowPersonDetailsForm();
        }
        private void tsLicenseDetails_Click(object sender, EventArgs e)
        {
            _ShowLicenseDetailsForm();
        }
        private void tsLicenseHistory_Click(object sender, EventArgs e)
        {
            _ShowPersonLicensesHistoryForm();
        }
        private void cmsInternationalApplications_Opening(object sender, CancelEventArgs e)
        {
            _ShowAndHideReleaseDetainedLicenseOptionFromMenuStrip();
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            _showDetainLicenseForm();
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            _ShowReleaseDetainedLicenseForm();
        }
        private void tsReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            _ShowReleaseSpecificDetainedLicense();
        }
    }
}
