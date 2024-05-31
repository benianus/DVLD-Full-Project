using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public static class clsGlobalSettings
    {
        public enum enMode
        {
            AddNew,
            Update
        }
        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public static clsUserBusinessLayer User;
        public static clsPeopleBusinessLayer Person;
        public static clsApplicationsTypesBusinessLayer ApplicationType;
        public static clsTestTypesBusinessLayer TestTypes;
        public static clsLocalDriverLicenseApplicationBusinessLayer LocalDriverLicenseApplication;
        public static clsApplicationsBusinessLayer Applications;
        public static clsLicenseClassesBusinessLayer LicenseClasses;
        public static clsLicensesBusinessLayer Licenses;
        public static clsTestAppointementsBusinessLayer TestAppointements;
        public static clsTestsBusinessLayer Tests;
        public static clsDriversBusinessLayer Drivers;

        public static int TestTypeID;
        public static int TestAppointementID;
        public static int TestID;
        public static int ApplicationID;
        public static int ApplicationTypeID;
        public static int LocalDrivingLicenseApplicationID;
        public static int PersonID;
        public static int UserID;
        public static int LicenseClassID;
        public static int LicenseID;
        public static int DriverID;

        public static enMode Mode;
        public static enApplicationStatus Status;
        
    }
}
