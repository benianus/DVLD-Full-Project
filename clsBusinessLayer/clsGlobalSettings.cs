using System;
using System.Collections.Generic;
using System.IO;
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
        public enum enTestTypes : byte
        {
            VisionTest = 1,
            WrittenTheoryTest = 2 ,
            PracticalStreetTest = 3
        }

        public static clsUserBusinessLayer User;
        public static clsPeopleBusinessLayer Person;
        public static clsApplicationsTypesBusinessLayer ApplicationType;
        public static clsTestTypesBusinessLayer TestTypes;
        public static clsLocalDriverLicenseApplicationBusinessLayer LocalDriverLicenseApplications;
        public static clsApplicationsBusinessLayer Applications;
        public static clsLicenseClassesBusinessLayer LicenseClasses;
        public static clsLicensesBusinessLayer Licenses;
        public static clsTestAppointementsBusinessLayer TestAppointements;
        public static clsTestsBusinessLayer Tests;
        public static clsDriversBusinessLayer Drivers;
        public static clsInternationalLicensesBusinessLayer InternationalLicenses;

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
        public static int InternationalLicenseID;

        public static enMode Mode;
        public static enApplicationStatus Status;
        public static enTestTypes TestType;
        
    }
}
