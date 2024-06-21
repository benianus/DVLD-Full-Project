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

namespace DVLD_Full_Project.Licenses
{
    public partial class frmShowLicenseHistory : Form
    {
        public frmShowLicenseHistory()
        {
            InitializeComponent();
        }
        public frmShowLicenseHistory(int PersonID)
        {
            InitializeComponent();
            clsGlobalSettings.PersonID = PersonID;
            if (clsGlobalSettings.PersonID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }

        //function
        private void _CloseShowLicensesHistoryForm()
        {
            this.Close();
        }
        private void _RefreshLocalLicensesData()
        {
            dgvLocalLicensesHistory.DataSource = clsLicensesBusinessLayer.GetPersonLocalLicensesHistory(clsGlobalSettings.PersonID);
        }
        private void _RowsCounterLocalLicenses()
        {
            lblLocalHistoryRowsCounter.Text = dgvLocalLicensesHistory.RowCount.ToString();
        }
        private void _RefreshInternationalLicensesData()
        {
            dgvInternationlLicensesHistory.DataSource = clsInternationalLicensesBusinessLayer.GetInternationalLicense(clsGlobalSettings.PersonID);
        }
        private void _RowsCounterInternationalLicenses()
        {
            lblInternationalHistoryRowsCounter.Text = dgvInternationlLicensesHistory.RowCount.ToString();
        }
        private void _LoadShowLiceneseHistory()
        {
            if (!DesignMode)
            {
                _RefreshInternationalLicensesData();
                _RefreshLocalLicensesData();
                _RowsCounterInternationalLicenses();
                _RowsCounterLocalLicenses();
            }
        }
       
        //buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseShowLicensesHistoryForm();
        }
        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            _LoadShowLiceneseHistory();
        }
        
    }
}
