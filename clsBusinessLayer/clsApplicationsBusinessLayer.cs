using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsApplicationsBusinessLayer
    {
        public clsApplicationsBusinessLayer(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, 
            DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        public clsApplicationsBusinessLayer()
        {
            this.ApplicationID = 0;
            this.ApplicantPersonID = 0;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = 0;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = 0;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public static DataTable GetApplicationInfos(int LDLApplication)
        {
            return clsApplicationsDataLayer.GetApplicationInfos(LDLApplication);
        }
        public static bool CancelApplication(byte selectedApplication)
        {
            return clsApplicationsDataLayer.CancelApplication(selectedApplication);
        }
        public bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsDataLayer.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus
                , this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return this.ApplicationID > 0;
        }
        public bool _UpdateApplication()
        {

            return true;
        }
        public bool Save()
        {
            switch (clsGlobalSettings.Mode )
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewApplication();
                case clsGlobalSettings.enMode.Update:
                    return _UpdateApplication();
            }
            return _AddNewApplication();
        }
    }
}
