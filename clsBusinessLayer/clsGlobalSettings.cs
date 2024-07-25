using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        public static clsDetainedLicensesBusinessLayer DetainedLicenses;

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
        public static int DetainID;

        public static enMode Mode;
        public static enApplicationStatus Status;
        public static enTestTypes TestType;

        public static bool IsNumber(int number)
        {
            string pattern = @"[0-9]$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(number.ToString());
        }

        public static void CreateEventLog(Exception error)
        {
            string Source = error.Source;
            
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, "Application");
            }

            EventLog.WriteEntry(Source, error.Message, EventLogEntryType.Error);
        }

        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
