﻿using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.Tests.Test_Appointements
{
    public partial class frmSechduleTest : Form
    {
        public delegate void eventRefreshTestAppointmentData(int LDLApplicationID);
        public event eventRefreshTestAppointmentData RefreshTestAppointmentData;

        public delegate void eventRowsCounter();
        public event eventRowsCounter RowsCounter;
        public frmSechduleTest()
        {
            InitializeComponent();
        }
        public frmSechduleTest(int TestAppointmentID)
        {
            InitializeComponent();
            clsGlobalSettings.TestAppointementID = TestAppointmentID;
            if (clsGlobalSettings.TestAppointementID == -1)
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
            }
            else
            {
                clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
            }
        }
        //Functions
        private void _CloseSechduleTestForm()
        {
            this.Close();   
        }
        private void _LoadScheduleTestForm()
        {
            //vision test
            if (clsGlobalSettings.Mode == clsGlobalSettings.enMode.AddNew)
            {
                ifModeAddNew();
                return;
            }

            clsGlobalSettings.TestAppointements = clsTestAppointementsBusinessLayer.FindTestAppointment(clsGlobalSettings.TestAppointementID);
            ifModeUpdate();
        }

        private void ifModeUpdate()
        {
            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = "0";
            dtpDate.Value = clsGlobalSettings.TestAppointements.AppointmentDate;
            lblFees.Text = _GetTestTypeFees("Vision Test");
            gbRetakeTestInfo.Enabled = false;

            //retake test
            lblRetakeFees.Text = "0";
            lblTotalFees.Text = clsApplicationsTypesBusinessLayer.GetApplicationTypeFees("Retake Test").ToString();
            lblTestAppID.Text = "N/A";
        }
        private void ifModeAddNew()
        {
            clsGlobalSettings.TestAppointements = new clsTestAppointementsBusinessLayer();

            lblDLAppID.Text = ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID;
            lblDClass.Text = ucTestAppointments.ApplicationInfo.ClassName;
            lblName.Text = ucTestAppointments.ApplicationInfo.FullName;
            lblTrial.Text = "0";
            dtpDate.Value = DateTime.Now;
            lblFees.Text = _GetTestTypeFees("Vision Test");
            gbRetakeTestInfo.Enabled = false;

            //retake test
            lblRetakeFees.Text = "0";
            lblTotalFees.Text = clsApplicationsTypesBusinessLayer.GetApplicationTypeFees("Retake Test").ToString();
            lblTestAppID.Text = "N/A";
        }

        private string _GetTestTypeFees(string TestTypeTitle)
        {
            return clsTestTypesBusinessLayer._GetTestTypeFees(TestTypeTitle);
        }
        private void _SaveTestAppointment()
        {
            clsGlobalSettings.TestAppointements.TestTypeID = 1;
            clsGlobalSettings.TestAppointements.LocalDrivingLicenseApplicationID = Convert.ToInt32(ucTestAppointments.ApplicationInfo.LocalDrivingLicenseApplicationID);
            clsGlobalSettings.TestAppointements.AppointmentDate = dtpDate.Value;
            clsGlobalSettings.TestAppointements.PaidFees = Convert.ToDecimal(lblFees.Text);
            clsGlobalSettings.TestAppointements.CreatedByUserID = clsGlobalSettings.User.UserID;
            clsGlobalSettings.TestAppointements.IsLocked = false;

            if (clsGlobalSettings.TestAppointements.Save())
            {
                if (MessageBox.Show("Test appointment saved") == DialogResult.OK)
                {
                    RefreshTestAppointmentData?.Invoke(clsGlobalSettings.TestAppointements.TestAppointmentID);
                    RowsCounter?.Invoke();
                    this.Close();   
                }
            }
            else
            {
                MessageBox.Show("Test appointment not saved");
            }
        }


        //Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseSechduleTestForm();
        }
        private void frmSechduleTest_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                _LoadScheduleTestForm();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveTestAppointment();
        }
    }
}
