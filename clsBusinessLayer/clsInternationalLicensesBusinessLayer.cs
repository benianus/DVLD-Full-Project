﻿using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsInternationalLicensesBusinessLayer
    {
        public clsInternationalLicensesBusinessLayer(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate,
            DateTime expirationDate, bool isActive, int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        public clsInternationalLicensesBusinessLayer()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            IssuedUsingLocalLicenseID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = 0;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesDataLayer.GetAllInternationalLicenses();
        }
        public static DataTable GetAllInternationalLicenses(string filter, string condition)
        {
            return clsInternationalLicensesDataLayer.GetAllInternationalLicenses(filter, condition);
        }
        public static clsInternationalLicensesBusinessLayer FindDriverInternationalLicense(int LicenseID)
        {
            int InternationalLicenseID = 0;
            int ApplicationID = 0;
            int DriverID = 0;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = 0;

            if (clsInternationalLicensesDataLayer.FindDriverInternationalLicense(ref InternationalLicenseID, ref ApplicationID, 
                ref DriverID, LicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicensesBusinessLayer(InternationalLicenseID, ApplicationID, DriverID, LicenseID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
    }
        public static DataTable GetInternationalLicenseInfos(int internationalLicenseID)
        {
            return clsInternationalLicensesDataLayer.GetInternationalLicenseInfos(internationalLicenseID);

        }
        public static DataTable GetInternationalLicense(int PersonID)
        {
            return clsInternationalLicensesDataLayer.GetInternationalLicense(PersonID);
        }
        public static bool isPersonHasInternationalLicense(int LocalLicenseID)
        {
            return clsInternationalLicensesDataLayer.isPersonHasInternationalLicense(LocalLicenseID);
        }

        public bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesDataLayer.AddNewInternationalLicense(this.ApplicationID, this.DriverID,
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return this.InternationalLicenseID > 0;
        }
        public bool _UpdateInternationalLicense()
        {
            return true;
        }
        public bool Save()
        {
            switch (clsGlobalSettings.Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewInternationalLicense();
                case clsGlobalSettings.enMode.Update:
                    return _UpdateInternationalLicense();
            }
            return false;
        }
    }
}
