using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsBusinessLayer;

namespace DVLD_Full_Project
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        //Functions
        private void _RefreshPeopleData()
        {
            dgvLocalLicenseApplications.DataSource = clsPeopleBusinessLayer.GetAllPeople();
        }
        private void _RefreshPeopleData(DataTable Table)
        {
            dgvLocalLicenseApplications.DataSource = Table;
            _RowsCounter(dgvLocalLicenseApplications);
        }
        private void _DefaultFilter()
        {
            cbFilters.Items.Add("None");
            cbFilters.SelectedIndex = 0;
            
        }
        private void _GetDataFilteredBy()
        {
            string FilterBy = cbFilters.SelectedItem.ToString();
            DataTable Table = clsPeopleBusinessLayer.FilterBy(FilterBy);
            _RefreshPeopleData(Table);
        }
        private void _AddNewPerson()
        {
            frmAddEditPerson AddEditPerson = new frmAddEditPerson(-1);
            AddEditPerson.ShowDialog();
            _RefreshPeopleData();
        }
        private void _EditPerson()
        {
            int PersonID = Convert.ToInt32(dgvLocalLicenseApplications.CurrentRow.Cells[0].Value);
            frmAddEditPerson AddEditPerson = new frmAddEditPerson(PersonID);
            AddEditPerson.ShowDialog();
            _RefreshPeopleData();
        }
        private void _DeletePerson()
        {
            if (MessageBox.Show("Are you sure", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (_isItLinkedToData())
                {
                    MessageBox.Show("Person Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Delete Failed, Because it has deta linked to it");
                }
            }
        }
        private bool _isItLinkedToData()
        {
            int rowIndex = dgvLocalLicenseApplications.CurrentRow.Index;
            int PersonID = Convert.ToInt32(dgvLocalLicenseApplications.Rows[rowIndex].Cells[0].Value);
            if (clsPeopleBusinessLayer.Delete(PersonID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void _FilterBy()
        {
            _DefaultFilter();

            DataTable dt = clsPeopleBusinessLayer.GetAllPeople();

            foreach (DataColumn columns in dt.Columns)
            {
                cbFilters.Items.Add(columns.ColumnName);
            }
            
        }
        private void _RowsCounter()
        {
            lblRecordsNumber.Text = dgvLocalLicenseApplications.RowCount.ToString();
        }
        private void _RowsCounter(DataGridView dataGridView)
        {
            lblRecordsNumber.Text = dataGridView.RowCount.ToString();
        }
        private void _ShowFilterSearchBar()
        {
            string filtersSelectedItem = cbFilters.SelectedItem.ToString();

            switch (filtersSelectedItem)
            {
                case "None":
                    txtFilterBy.Visible = false;
                    break;
                default:
                    txtFilterBy.Visible = true;
                    break;
            }
        }
        private void _PreventTypingLettersWhereFilterIsPersonID(KeyPressEventArgs e)
        {
            if (cbFilters.SelectedItem.ToString() == "PersonID" && !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }
        }
        private void _FilterBySearchBar(string Filter, string Condition)
        {        
            DataTable Table = clsPeopleBusinessLayer.FilterBy(Filter, Condition);
            _RefreshPeopleData(Table);
        }
        private void _ShowAllPersonsIfSearchBarIsEmpty()
        {
            if (txtFilterBy.Text == string.Empty)
            {
                _RefreshPeopleData();
            }
        }
        private void _LoadShowPersonInformations()
        {
            int PersonID = Convert.ToInt32(dgvLocalLicenseApplications.CurrentRow.Cells[0].Value);
            frmPersonDetails personDetails = new frmPersonDetails(PersonID);
            personDetails.RefreshManagePeopleData += _RefreshPeopleData;
            personDetails.ShowDialog();
        }
        private void _CloseManagePeople()
        {
            this.Close();
        }
        private void _SendEmailToPerson()
        {
            MessageBox.Show("Feature is not implemented yet");
        }
        private void _PhoneCallPerson()
        {
            MessageBox.Show("Feature is not implemented yet");
        }

        //Buttons
        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleData();
            _FilterBy();
            _RowsCounter();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _EditPerson();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ShowFilterSearchBar();
            _GetDataFilteredBy();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeletePerson();
            _RefreshPeopleData();
        }
        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            _PreventTypingLettersWhereFilterIsPersonID(e);
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string Filter = cbFilters.SelectedItem.ToString();
            string Condition = txtFilterBy.Text;

            _FilterBySearchBar(Filter, Condition);
            _ShowAllPersonsIfSearchBarIsEmpty();
        }
        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadShowPersonInformations();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseManagePeople();
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SendEmailToPerson();
        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PhoneCallPerson();
        }
    }
}
