using clsDataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsTestsBusinessLayer
    {
        public clsTestsBusinessLayer(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        public clsTestsBusinessLayer()
        {
            this.TestID = 0;
            this.TestAppointmentID = 0;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = 0;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public static clsTestsBusinessLayer FindTest(int TestAppointmentID)
        {
            int TestID = 0;
            bool TestResult = false;
            string Notes = string.Empty;
            int CreatedByUserID = 0;

            if (clsTestsDataLayer.FindTest(ref TestID, TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTestsBusinessLayer(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        public bool AddNewTest()
        {
            this.TestID = clsTestsDataLayer.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return this.TestID > 0;
        }
        public bool Save()
        {
            switch(clsGlobalSettings.Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return AddNewTest();
                
            }
            
            return false;
        }
    }
}
