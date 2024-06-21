using clsDataLayer;
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

        public static DataTable GetInternationalLicense(int PersonID)
        {
            return clsInternationalLicensesDataLayer.GetInternationalLicense(PersonID);
        }
        public static bool isPersonHasInternationalLicense(int LocalLicenseID)
        {
            return clsInternationalLicensesDataLayer.isPersonHasInternationalLicense(LocalLicenseID);
        }
    }
}
