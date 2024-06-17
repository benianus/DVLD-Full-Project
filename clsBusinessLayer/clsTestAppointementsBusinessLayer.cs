using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsTestAppointementsBusinessLayer
    {
        public clsTestAppointementsBusinessLayer(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, 
            decimal paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        public clsTestAppointementsBusinessLayer()
        {
            TestAppointmentID = 0;
            TestTypeID = 0;
            LocalDrivingLicenseApplicationID = 0;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = 0;
            IsLocked = false;
            RetakeTestApplicationID = 0;
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public static bool isPersonPassTestAppointment(int LDLApplicationID, int TestTypeID)
        {
            return clsTestAppointementsDataLayer.isPersonPassTestAppointment(LDLApplicationID, TestTypeID);
        }
        public static bool isTestAppointmentLinkedToRetakeTestApplicationType(int TestAppointmentID)
        {
            return clsTestAppointementsDataLayer.isTestAppointmentLinkedToRetakeTestApplicationType(TestAppointmentID);
        }
        public static bool isTestAppointmentLockedAndTestFailed(int TestAppointmentID)
        {
            return clsTestAppointementsDataLayer.isTestAppointmentLockedAndTestFailed(TestAppointmentID);
        }
        public static bool isPersonFailInTheTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointementsDataLayer.isPersonFailInTheTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static int _GetTestTrialNumber(string LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointementsDataLayer._GetTestTrialNumber(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static bool isTestAppointmentLocked(int testAppointmentID)
        {
            return clsTestAppointementsDataLayer.isTestAppointmentLocked(testAppointmentID);
        }
        public static clsTestAppointementsBusinessLayer FindTestAppointment(int TestAppointmentID)
        {
            int TestTypeID = 0;
            int LocalDrivingLicenseApplicationID = 0;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = 0;
            bool IsLocked = false;
            int RetakeTestApplicationID = 0;

            if (clsTestAppointementsDataLayer.FindTestAppointment(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees,
                ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointementsBusinessLayer(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID,
                    IsLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }
        public static int GetTestAppointmentID(int LDLApplicationID)
        {
            return clsTestAppointementsDataLayer.GetTestAppointmentID(LDLApplicationID);
        }
        public static DataTable GetAllTestAppointment()
        {
            return clsTestAppointementsDataLayer.GetAllTestAppointmen();
        }
        public static DataTable GetTestAppointmentByID(int TestAppointmentID)
        {
            return clsTestAppointementsDataLayer.GetTestAppointmentByID(TestAppointmentID);
        }
        public static DataTable GetTestAppointmentByLDLApplicationID(int LDLApplicationID, int TestTypeID)
        {
            return clsTestAppointementsDataLayer.GetTestAppointmentByLDLApplicationID(LDLApplicationID, TestTypeID);
        }
        
        public static bool isPersonHasTestAppointment(int LDLApplcication, int TestTypeID)
        {
            return clsTestAppointementsDataLayer.isPersonHasTestAppointment(LDLApplcication, TestTypeID);
        }
        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointementsDataLayer.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return this.TestAppointmentID > 0;
        }
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointementsDataLayer.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID); 
        }
        public bool Save()
        {
            switch (clsGlobalSettings.Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewTestAppointment();
                case clsGlobalSettings.enMode.Update:
                    return _UpdateTestAppointment();
            }
            return false;
        }
    }
}
