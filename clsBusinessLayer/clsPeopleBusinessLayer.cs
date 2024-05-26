using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsDataLayer;

namespace clsBusinessLayer
{
    public class clsPeopleBusinessLayer
    {
        
        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }

        public clsPeopleBusinessLayer()
        {
            PersonId = 0;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty ;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = 0;
            ImagePath = string.Empty;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        private clsPeopleBusinessLayer(int PersonId, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, 
            int Gendor, string Address, string Email, string Phone, int NationalityCountryID, string ImagePath)
        {
            this.PersonId = PersonId;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName; 
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        public static DataTable FilterBy(string Filter)
        {
            return clsPeopleDataLayer.FilterBy(Filter);
        }
        public static DataTable FilterBy(string Filter, string Condition)
        {
            return clsPeopleDataLayer.FilterBy(Filter, Condition);
        }
        public static DataTable GetAllPeople()
        {
            return clsPeopleDataLayer.GetAllPeople();
        }
        public static DataTable GetAllCountries()
        {
            return clsPeopleDataLayer.GetAllCountries();
        }
        public static DataTable GetCountryName(int CountryID)
        {
            return clsPeopleDataLayer.GetCountryName(CountryID);
        }
        public static bool isExistByNationalID(string NationalNo)
        {
            if (clsPeopleDataLayer.isExistByNationalID(NationalNo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static clsPeopleBusinessLayer FindPersonByPersonID(int PersonID)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0;
            string Address = string.Empty;
            string Email = string.Empty;
            string Phone = string.Empty;
            int NationalityCountryID = 0;
            string ImagePath = string.Empty;
            
            if (clsPeopleDataLayer.FindByPersonID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
            ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Email, ref Phone, ref NationalityCountryID,
            ref  ImagePath))
            {
                return new clsPeopleBusinessLayer(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Email, Phone,
                    NationalityCountryID, ImagePath) ;
            }
            else
            {
                return null;
            }
        }
        public static clsPeopleBusinessLayer FindByNationalNO(string NationalNO)
        {
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0;
            string Address = string.Empty;
            string Email = string.Empty;
            string Phone = string.Empty;
            int NationalityCountryID = 0;
            string ImagePath = string.Empty;

            if (clsPeopleDataLayer.FindByNationalNO(ref clsGlobalSettings.PersonID, NationalNO, ref FirstName, ref SecondName, ref ThirdName,
            ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Email, ref Phone, ref NationalityCountryID,
            ref ImagePath))
            {
                return new clsPeopleBusinessLayer(clsGlobalSettings.PersonID, NationalNO, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Email, Phone,
                    NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPeopleBusinessLayer FindPersonByCondition(string Filter, string Condition)
        {
            int PersonID = 0;
            string NationalNO = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0;
            string Address = string.Empty;
            string Email = string.Empty;
            string Phone = string.Empty;
            int NationalityCountryID = 0;
            string ImagePath = string.Empty;

            if (clsPeopleDataLayer.FindPersonByCondition(Filter, Condition, ref PersonID, ref NationalNO, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth,ref Gendor, ref Address, ref Email , ref Phone, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeopleBusinessLayer(PersonID, NationalNO, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Email, Phone,
                    NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }
        private bool _AddNew()
        {
            this.PersonId = clsPeopleDataLayer.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address,
                this.Email, this.Phone, this.NationalityCountryID, this.ImagePath);

            return (this.PersonId != -1);
        }
        private bool _Update()
        {
            return clsPeopleDataLayer.UpdatePerson(this.PersonId, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gendor, this.Address, this.Email, this.Phone, this.NationalityCountryID, this.ImagePath);
        }
        public static bool Delete(int PersonID)
        {
            return clsPeopleDataLayer.DeletePerson(PersonID);
        }
        public bool Save()
        {
            switch (clsGlobalSettings.Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return _AddNew();
                case clsGlobalSettings.enMode.Update:
                    return _Update();
            }

            return false;
        }
    }
}
