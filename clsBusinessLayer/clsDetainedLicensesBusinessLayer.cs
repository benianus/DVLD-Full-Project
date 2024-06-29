using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsDetainedLicensesBusinessLayer
    {
        public clsDetainedLicensesBusinessLayer(int detainedID, int licensesID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased,
            DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            DetainID = detainedID;
            LicenseID = licensesID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
        }
        public clsDetainedLicensesBusinessLayer()
        {
            DetainID = 0;
            LicenseID = 0;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = 0;
            ReleaseApplicationID = 0;
        }
       
        public int DetainID { get; set; } 
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }   
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }   
        public int ReleaseApplicationID { get; set; }

        public static bool ReleaseLicense(int detainID)
        {
            return clsDetainedLicensesDataLayer.ReleaseLicense(detainID);
        }
        public static DataTable GetDetainedLicenses(string filter, string condition)
        {
            return clsDetainedLicensesDataLayer.GetDetainedLicenses(filter, condition);
        }
        public static clsDetainedLicensesBusinessLayer FindDetainedLicense(int licenseID)
        {
            int detainID = 0;
            DateTime detainDate = DateTime.Now;
            decimal finFees = 0;
            int createdByUserID = 0;
            bool isReleased = false;
            DateTime releaseDate = DateTime.Now;
            int releasedByUserID = 0;
            int releaseApplicationID = 0;

            if (clsDetainedLicensesDataLayer.FindDetainedLicense(ref detainID, licenseID, ref detainDate, ref finFees, ref createdByUserID
                , ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetainedLicensesBusinessLayer(detainID, licenseID, detainDate, finFees, createdByUserID, isReleased, releaseDate, releasedByUserID,
                    releaseApplicationID);
            }
            else { return null; }
        }
        public static bool isLicenseDetained(string LicenseID)
        {
            return clsDetainedLicensesDataLayer.isLicenseDetained(LicenseID);
        }
        public static bool isLicenseReleased(string LicenseID)
        {
            return clsDetainedLicensesDataLayer.isLicenseReleased(LicenseID);
        }
        public bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicensesDataLayer.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
                this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

            return this.DetainID > 0;
        }
        public bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesDataLayer.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
                this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public bool Save()
        {
            switch (clsGlobalSettings.Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewDetainedLicense();
                case clsGlobalSettings.enMode.Update:
                    return _UpdateDetainedLicense();
                
            }

            return false;
        }

    }
}
