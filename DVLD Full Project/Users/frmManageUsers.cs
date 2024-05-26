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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        //Functions
        private void _RefreshUsersData()
        {
            dtgManageUsers.DataSource = clsUserBusinessLayer.GetAllUsers();
        }
        private void _RefreshUsersData(DataTable UsersTable)
        {
            dtgManageUsers.DataSource = UsersTable;
        }
        private void _LoadUsersFilter()
        {
            cbFilterUsersBy.SelectedIndex = 0;
            DataTable dt = clsUserBusinessLayer.GetAllUsers();
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName == "Password")
                {
                    continue;
                }
                cbFilterUsersBy.Items.Add(column.ColumnName);
            }
        }
        private void _CloseManageUserForm()
        {
            this.Close();
        }
        private void _preventFromTypingCharachters(KeyPressEventArgs e)
        {
            string selectedFilter = cbFilterUsersBy.SelectedItem.ToString();
            if ((selectedFilter == "UserID" || selectedFilter == "PersonID") && !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }
        private void _RowsCounter()
        {
            lblRecordsCounter.Text = dtgManageUsers.RowCount.ToString();
        }
        private void _RowsCounter(DataTable usersTable)
        {
            lblRecordsCounter.Text = usersTable.Rows.Count.ToString();
        }
        private void _LoadIsActiveFilters()
        {
            cbIsActive.Items.Add("All") ;
            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");

            cbIsActive.SelectedIndex = 0;
        }
        private void _showSearchBar()
        {
            string selectedFilter = cbFilterUsersBy.SelectedItem.ToString();
            switch (selectedFilter)
            {
                case "None":
                    txtFilterUsersBy.Visible = false;
                    cbIsActive.Visible = false;
                    break;
                case "IsActive":
                    txtFilterUsersBy.Visible = false;
                    cbIsActive.Visible = true;
                    _LoadIsActiveFilters();
                    break;

                default:
                    txtFilterUsersBy.Visible = true;
                    cbIsActive.Visible = false;
                    break;
            }
        }
        private void _FilterUsersBy(string Filter, string Condition)
        {
            DataTable UsersTable = clsUserBusinessLayer.GetUsersFilteredBy(Filter, Condition);
            _RefreshUsersData(UsersTable);
            _RowsCounter(UsersTable);
        }
        private void _showAllUsersDataIfSearchBarIsEmpty()
        {
            if (txtFilterUsersBy.Text == string.Empty)
            {
                _RefreshUsersData();
            }
        }
        private void _ShowAddNewUser()
        {
            frmAddUpdateUser addNewUser = new frmAddUpdateUser(-1);
            addNewUser.RefreshUsersTable += _RefreshUsersData;
            addNewUser.ShowDialog();
        }
        private void _GetUsersFilteredBy()
        {
            string Filter = cbFilterUsersBy.SelectedItem as string;
            string Condition = txtFilterUsersBy.Text;
            _FilterUsersBy(Filter, Condition);
        }
        private void _FilterUsersByIsActive()
        {
            string Filter = cbFilterUsersBy.SelectedItem as string;
            string Condition = cbIsActive.SelectedItem as string;
            _FilterUsersBy(Filter, Condition);
        }
        private void _DeleteUser()
        {
            int selectedUser = Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[0].Value);
            int PersonID = Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[1].Value);

            if (!clsUserBusinessLayer.isUserLinkedToPerson(PersonID))
            {
                if (MessageBox.Show("Are you sure to delete user", "Delte", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    clsUserBusinessLayer.DeleteUser(selectedUser);
                }
            }
            else
            {
                MessageBox.Show("Failed to delete, User linked to a Person");
            }

            _RefreshUsersData();
            _RowsCounter();
        }
        private void _ShowChangePasswordForm()
        {
            _GetPersonInfo();
            frmChangePassword ChangePassword = new frmChangePassword(Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[0].Value));
            ChangePassword.ShowDialog();
        }
        private void _GetPersonInfo()
        {
            clsGlobalSettings.PersonID = Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[1].Value);
        }
        private void _EditUser()
        {
            int PersonID = Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[1].Value);
            int UserID = Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[0].Value);

            frmAddUpdateUser AddUpdateUser = new frmAddUpdateUser(PersonID, UserID);
            AddUpdateUser.ShowDialog();
        }
        private void _showUserInfoForm()
        {
            int UserID = Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[0].Value);
            int PersonID = Convert.ToInt32(dtgManageUsers.CurrentRow.Cells[1].Value) ;
            frmUserInfo UserInfo = new frmUserInfo(UserID, PersonID);
            UserInfo.ShowDialog();
        }
        //Buttons
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersData();
            _LoadUsersFilter();
            _RowsCounter();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseManageUserForm();
        }
        private void txtFilterUsersBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            _preventFromTypingCharachters(e);
        }
        private void cbFilterUsersBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _GetUsersFilteredBy();
            _showSearchBar();
        }
        private void txtFilterUsersBy_TextChanged(object sender, EventArgs e)
        {
            _GetUsersFilteredBy();
            _showAllUsersDataIfSearchBarIsEmpty();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            _ShowAddNewUser();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterUsersByIsActive();
        }
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowAddNewUser();
        }
        private void sendEmalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature will be impelemented soon");
        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature will be impelemented soon");
        }
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeleteUser();
            _RefreshUsersData();
        }
        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ShowChangePasswordForm();
        }
        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _EditUser();
        }

        private void showUserInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showUserInfoForm();
        }
    }
}
