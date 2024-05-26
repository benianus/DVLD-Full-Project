using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsApplicationsTypesBusinessLayer
    {
        public clsApplicationsTypesBusinessLayer(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
        }
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { set; get; }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationsTypesDataLayer.GetAllApplicationTypes();
        }
        public static int GetApplicationTypeFees(string ApplicatonTypeTitle)
        {
            return clsApplicationsTypesDataLayer.GetApplicationTypeFees(ApplicatonTypeTitle);
        }
        public static clsApplicationsTypesBusinessLayer FindApplicationType(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = string.Empty;
            decimal ApplicationFees = 0;

            if (clsApplicationsTypesDataLayer.FindApplicationType(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationsTypesBusinessLayer(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            else
            {
                return null;
            }
        }
        private bool _UpdateApplicationType()
        {
            return clsApplicationsTypesDataLayer.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }
        public bool Save()
        {
            return _UpdateApplicationType();
        }
    }
}
