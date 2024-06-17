using clsDataLayer;
using System;
using System.Collections.Generic;
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
            DetainedID = detainedID;
            LicensesID = licensesID;
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
            DetainedID = 0;
            LicensesID = 0;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = 0;
            ReleaseApplicationID = 0;
        }
        public int DetainedID { get; set; } 
        public int LicensesID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }   
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }   
        public int ReleaseApplicationID { get; set; }

        public static bool isLicenseDetained(string LicenseID)
        {
            return clsDetainedLicensesDataLayer.isLicenseDetained(LicenseID);
        }
    }
}
