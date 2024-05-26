using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsLicenseClassesBusinessLayer
    {
        public clsLicenseClassesBusinessLayer(int licenseClassID, string className, string classDescription, bool minimumAllowedAge, bool defaultValidityLength,
            decimal classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public bool MinimumAllowedAge { get; set; }
        public bool DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

    }
}
