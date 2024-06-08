using System;
using System.Collections.Generic;
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
        }
        public clsTestsBusinessLayer()
        {
            this.TestID = 0;
            this.TestAppointmentID = 0;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = 0;
        }
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }


    }
}
