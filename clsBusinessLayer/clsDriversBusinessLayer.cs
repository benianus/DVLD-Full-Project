using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsDriversBusinessLayer
    {
        public clsDriversBusinessLayer(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }
        public clsDriversBusinessLayer()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.Now;
        }
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public static DataTable GetDriverLicenseInfos(int LDLApplicationID)
        {
            return clsDriversDataLayer.GetDriverLicenseInfos(LDLApplicationID);
        }
        public static clsDriversBusinessLayer FindDriverByPersonID(int PersonID)
        {
            int DriverID = 0;
            int CreatedByUserID = 0;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversDataLayer.FindDriverByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriversBusinessLayer(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }
    }
}
