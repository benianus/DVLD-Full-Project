using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsLocalDriverLicenseApplicationBusinessLayer
    {
        public clsLocalDriverLicenseApplicationBusinessLayer(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        public clsLocalDriverLicenseApplicationBusinessLayer()
        {
            this.LocalDrivingLicenseApplicationID = 0;
            this.ApplicationID = 0;
            this.LicenseClassID = 0;
            
            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public static int GetHowMuchTestsPassed(int LDLApplication)
        {
            return clsLocalDriverLicenseApplicationDataLayer.GetHowMuchTestsPassed(LDLApplication);
        }
        public static DataTable GetLicenseClasses()
        {
            return clsLocalDriverLicenseApplicationDataLayer.GetLicenseClasses();
        }
        public static DataTable GetDrivingLicenseApplicationInfo(int LDLApplication)
        {
            return clsLocalDriverLicenseApplicationDataLayer.GetDrivingLicenseApplicationnInfo(LDLApplication);
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDriverLicenseApplicationDataLayer.GetAllLocalDrivingLicenseApplications();
        }
        public static DataTable FilterLocalDrivingLicenseApplicationBy(string Filter, string Condition)
        {
            return clsLocalDriverLicenseApplicationDataLayer.FilterLocalDrivingLicenseApplicationBy(Filter, Condition);
        }
        public static bool isLocalApplcationNew(string NationalNo, string ClassName, string Status = "New")
        {
            return clsLocalDriverLicenseApplicationDataLayer.isLocalApplcationNew(NationalNo, ClassName, Status);
        }
        public static bool isLocalApplcationCompleted(string NationalNo, string ClassName, string Status = "Completed")
        {
            return clsLocalDriverLicenseApplicationDataLayer.isLocalApplcationCompleted(NationalNo, ClassName, Status);
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDriverLicenseApplicationDataLayer.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return this.LocalDrivingLicenseApplicationID > 0;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return true;
        }
        

        public bool Save()
        {
            switch (clsGlobalSettings.Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewLocalDrivingLicenseApplication();
                case clsGlobalSettings.enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
            }
            return false;
        }
    }
}
