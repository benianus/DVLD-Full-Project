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

        public static DataTable GetLicenseClasses()
        {
            return clsLocalDriverLicenseApplicationDataLayer.GetLicenseClasses();
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDriverLicenseApplicationDataLayer.GetAllLocalDrivingLicenseApplications();
        }

    }
}
