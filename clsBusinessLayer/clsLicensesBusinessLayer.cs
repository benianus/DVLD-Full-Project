using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsLicensesBusinessLayer
    {
        public clsLicensesBusinessLayer(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate,
            string notes, decimal paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
        }

        public clsLicensesBusinessLayer()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LicenseClass = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = 0;
        }
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public static DataTable GetDriverLicenseInfos(int LicenseID)
        {
            return clsLicensesDataLayer.GetDriverLicenseInfos(LicenseID);
        }
        public static DataTable GetPersonLocalLicensesHistory(int PersonID)
        {
            return clsLicensesDataLayer.GetPersonLocalLicensesHistory(PersonID);
        }
        public static bool isApplicationHasDriverLicense(int ApplicationID)
        {
            return clsLicensesDataLayer.isApplicationHasDriverLicense(ApplicationID);
        }
        public bool _AddNewDriverLicense()
        {
            this.LicenseID = clsLicensesDataLayer.AddNewDriverLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

            return this.LicenseID > 0;
        }
        public bool Save()
        {
            return _AddNewDriverLicense();
        }
    }
}
