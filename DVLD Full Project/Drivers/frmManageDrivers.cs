﻿using clsBusinessLayer;
using DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses;
using DVLD_Full_Project.Applications.Manage_Applications.International_Driving_License_Applications;
using DVLD_Full_Project.Licenses;
using DVLD_Full_Project.Tests.Issue_Driver_Licnese;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Drivers
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }
        //functions
        private void _LoadManageDriversForm()
        {
            _refreshDriversData();
            _rowsCounter();
            _loadFiltersToComboBox();
            _showSearchBoxIf();
        }
        private void _showSearchBoxIf()
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
        private void _loadFiltersToComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("DriverID");
            cbFilters.Items.Add("PersonID");
            cbFilters.Items.Add("NationalNo");
            cbFilters.Items.Add("FullName");
            cbFilters.Items.Add("CreatedDate");
            cbFilters.Items.Add("NumberOfActiveLicenses");

            //default filter
            cbFilters.SelectedItem = "None";
        }
        private void _refreshDriversData()
        {
            dgvDrivers.DataSource = clsDriversBusinessLayer.GelAllDrivers();
        }
        private DataTable _refreshDriversData(DataTable filteredDriversTable)
        {
            dgvDrivers.DataSource = filteredDriversTable;

            return filteredDriversTable;
        }
        private void _rowsCounter()
        {
            lblRecordsNumber.Text = dgvDrivers.RowCount.ToString();
        }
        private void _rowsCounter(DataTable filteredDriversTable)
        {
            lblRecordsNumber.Text = filteredDriversTable.Rows.Count.ToString();
        }
        private void _closeManageDriversForm()
        {
            this.Close();
        }
        private DataTable _FilterDriversBy()
        {
            string Filter = cbFilters.SelectedItem.ToString();
            string condition = txtFilterBy.Text;
            return clsDriversBusinessLayer.FilterDriversBy(Filter, condition);
        }


        //buttons
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadManageDriversForm();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _closeManageDriversForm();
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDriversBusinessLayer.FilterDriversBy("None", string.Empty);
            _showSearchBoxIf();
            _rowsCounter(_refreshDriversData(_FilterDriversBy()));
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            _rowsCounter(_refreshDriversData(_FilterDriversBy()));
        }

        private void showPersonInfosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvDrivers.CurrentRow.Cells["PersonID"].Value;
            frmPersonDetails personDetails = new frmPersonDetails(personID);
            personDetails.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvDrivers.CurrentRow.Cells["PersonID"].Value;
            frmShowLicenseHistory licenseHistory = new frmShowLicenseHistory(personID);
            licenseHistory.ShowDialog();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvDrivers.CurrentRow.Cells["DriverID"].Value;
            if (clsDriversBusinessLayer.isDriverAlreadyHasInternationalLicense(DriverID))
            {
                MessageBox.Show("Driver Already has international License!");
                return;
            }
            frmAddInternationalLicenseApplication addInternationalLicenseApplication = new frmAddInternationalLicenseApplication(-1);
            addInternationalLicenseApplication.ShowDialog();
        }
    }
}
