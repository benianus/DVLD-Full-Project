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
    public class clsUserBusinessLayer
    {
        public clsUserBusinessLayer(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
        }
        public clsUserBusinessLayer()
        {
            UserID = 0;
            PersonID = 0;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;

            clsGlobalSettings.Mode = clsGlobalSettings.enMode.AddNew;
        }
        public int UserID { get; set; } 
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public static DataTable GetAllUsers()
        {
            return clsUserDataLayer.GetAllUsers();
        }
        public static DataTable GetUsersFilteredBy(string Filter, string Condition)
        {
            return clsUserDataLayer.GetUsersFilteredBy(Filter, Condition);
        }
        public static int GetPersonIDofCurrentUser(int UserID)
        {
            return clsUserDataLayer.GetPersonIDofCurrentUser(UserID);
        }
        public static bool isUserExist(string UserName, string Password)
        {

            if (clsUserDataLayer.isUserExist(UserName, Password))
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
        public static bool isUserActive(string UserName, string Password)
        {
            if (clsUserDataLayer.isUserActive(UserName, Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static clsUserBusinessLayer FindUser(string Filter, string Condition)
        {
            int UserID = 0;
            int PersonID = 0;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserDataLayer.FindUser(Filter, Condition, ref UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUserBusinessLayer(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUserBusinessLayer FindUser(int UserID)
        {
            int PersonID = 0;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserDataLayer.FindUser(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUserBusinessLayer(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
        public static bool isUserLinkedToPerson(int PersonID)
        {
            return clsUserDataLayer.isUserLinkedToPerson(PersonID);
        }
        public bool _AddNewUser()
        {
            this.UserID = clsUserDataLayer.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }
        public bool _UpdateUser()
        {
            return clsUserDataLayer.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserDataLayer.DeleteUser(UserID);
        }
        public bool Save()
        {
            switch (clsGlobalSettings.Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    clsGlobalSettings.Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewUser();
                case clsGlobalSettings.enMode.Update:
                    return _UpdateUser();
                
            }
            return false;
        }

    }
}
