using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    
    public class clsLicensesDataLayer
    {
        public static bool isPersonHasLocalLicense(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from Licenses where licenseID = @LicenseID and IsActive = 1 and LicenseClass = 3;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isFound = reader.Read();
                }
            }
            catch
            {
                return isFound;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetDriverLicenseInfos(int LicenseID)
        {
            DataTable DriverLicenseInfos = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from LicenseInfos_view where licenseID = @LicenseID and IsActive = 'Yes' and ExpirationDate > IssueDate and ClassName = 'Class 3 - Ordinary driving license';";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DriverLicenseInfos.Load(reader);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }

            return DriverLicenseInfos;
        }
        public static DataTable GetPersonLocalLicensesHistory(int PersonID)
        {
            DataTable LocalLicensesHistoryTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate," +
                " Licenses.IsActive from Licenses Join LicenseClasses" +
                " on Licenses.LicenseClass = LicenseClasses.LicenseClassID " +
                " join Applications on Applications.ApplicationID = Licenses.ApplicationID" +
                " where Applications.ApplicantPersonID = @ApplicantPersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    LocalLicensesHistoryTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return LocalLicensesHistoryTable;
        }
        public static bool isApplicationHasDriverLicense(int ApplicationID)
        {
            bool isApplicationHasDriverLicense = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "Select * from Licenses where ApplicationID = @ApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    isApplicationHasDriverLicense = reader.Read();
                }
            }
            catch {
                return isApplicationHasDriverLicense;
                throw; }
            finally
            {
                connection.Close();
            }

            return isApplicationHasDriverLicense;
        }
        public static int AddNewDriverLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, 
            bool IsActive, byte IssueReason, int CreatedByUserId)
        {
            int LicenseID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "Insert into Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserId)" +
                "Values (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserId);" +
                "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes == string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }
            catch { throw; }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }
    }
}
