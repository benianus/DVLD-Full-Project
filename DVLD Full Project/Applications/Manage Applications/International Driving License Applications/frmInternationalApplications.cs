using clsBusinessLayer;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
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

namespace DVLD_Full_Project.Applications.Manage_Applications.International_Driving_License_Applications
{
    public partial class frmInternationalApplications : Form
    {
        public frmInternationalApplications()
        {
            InitializeComponent();
        }
        //function
        private void _CloseManageInternationalApplicationsForm()
        {
            this.Close();
        }
        private void _ShowAddNewInternationalLicenseApplicationsForm()
        {
            frmAddInternationalLicenseApplication addInternationalLicenseApplication = new frmAddInternationalLicenseApplication(-1);
            addInternationalLicenseApplication.ShowDialog();
        }
        private void _LoadManageInternationalApplicationsForm()
        {
            _RefreshInternationalApplicationsDataView();
            _RowsCounter();
            _LoadFilterToComboBox();
        }
        private void _RefreshInternationalApplicationsDataView()
        {
            dgvInternationlLicenseApplcations.DataSource = clsInternationalLicensesBusinessLayer.GetAllInternationalLicenses();
        }
        private void _RowsCounter()
        {
            lblRecordsNumber.Text = dgvInternationlLicenseApplcations.RowCount.ToString();
        }
        private DataTable _RefreshInternationalApplicationsDataView(DataTable internationalLicenseTable)
        {
            dgvInternationlLicenseApplcations.DataSource = internationalLicenseTable;
            return internationalLicenseTable;
        }
        private void _RowsCounter(DataTable internationalLicenseTable)
        {
            lblRecordsNumber.Text = internationalLicenseTable.Rows.Count.ToString();    
        }
        private void _LoadFilterToComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("InternationalLicenseID");
            cbFilters.Items.Add("ApplicationID");
            cbFilters.Items.Add("DriverID");
            cbFilters.Items.Add("IssuedUsingLocalLicenseID");
            cbFilters.Items.Add("IsActive");

            //default
            cbFilters.SelectedIndex = 0;

            _ShowOrHideFilterSerachBox();
        }
        private void _ShowOrHideFilterSerachBox()
        {
            switch (cbFilters.Text)
            {
                case "None":
                    txtFilterBy.Visible = false;
                    break;
                default:
                    txtFilterBy.Visible = true;
                    break;
            }
        }
        private DataTable _FilterInternationlApplicationsData(string filter, string condition)
        {
            return clsInternationalLicensesBusinessLayer.GetAllInternationalLicenses(filter, condition);
        }
        private void _ShowPersonDetailsForm()
        {
            frmPersonDetails personDetails = new frmPersonDetails(clsApplicationsBusinessLayer.GetApplicantPersonID(Convert.ToInt32(dgvInternationlLicenseApplcations.CurrentRow.Cells["ApplicationID"].Value)));
            personDetails.ShowDialog();
        }
        private void _ShowLicenseDetailsForm()
        {
            frmShowInternationalLicenseInfo showInternationalLicenseInfos = new frmShowInternationalLicenseInfo(Convert.ToInt32(dgvInternationlLicenseApplcations.CurrentRow.Cells["InternationalLicenseID"].Value));
            showInternationalLicenseInfos.ShowDialog();
        }
        private void _ShowPersonLicensesHistoryForm()
        {
            frmShowLicenseHistory showLicenseHistory = new frmShowLicenseHistory(clsApplicationsBusinessLayer.GetApplicantPersonID(Convert.ToInt32(dgvInternationlLicenseApplcations.CurrentRow.Cells["ApplicationID"].Value))); 
            showLicenseHistory.ShowDialog();
        }
        //buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseManageInternationalApplicationsForm();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            _CloseManageInternationalApplicationsForm();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _ShowAddNewInternationalLicenseApplicationsForm();
        }
        private void frmInternationalApplications_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadManageInternationalApplicationsForm();
            }
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ShowOrHideFilterSerachBox();

            string filter = cbFilters.Text;
            string condition = txtFilterBy.Text;

            _RowsCounter(_RefreshInternationalApplicationsDataView(_FilterInternationlApplicationsData(filter, condition)));
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filter = cbFilters.Text;
            string condition = txtFilterBy.Text;

            _RowsCounter(_RefreshInternationalApplicationsDataView(_FilterInternationlApplicationsData(filter, condition)));
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
    }
}
