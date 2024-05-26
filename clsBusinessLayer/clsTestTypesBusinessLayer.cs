using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsDataLayer;

namespace clsBusinessLayer
{
    public class clsTestTypesBusinessLayer
    {
        public clsTestTypesBusinessLayer(int testTypeID, string testTypeTitle, string testTypeDescription, decimal testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }

        public int TestTypeID { get; set; } 
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataLayer.GetAllTestTypes();
        }
        public static clsTestTypesBusinessLayer FindTestType(int TestTypeID)
        {
            string TestTypeTitle = string.Empty;
            string TestTypeDescription = string.Empty;
            decimal TestTypeFees = 0;

            if (clsTestTypesDataLayer.FindTestType(TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestTypesBusinessLayer(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }
        }
        public bool _updateTestType()
        {
            return clsTestTypesDataLayer.updateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        public bool Save()
        {
            return _updateTestType();
        }
    }
}
