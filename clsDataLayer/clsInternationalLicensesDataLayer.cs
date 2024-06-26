using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsInternationalLicensesDataLayer
    {
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable ILApplicationsTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT        InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive" +
                " FROM            InternationalLicenses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    ILApplicationsTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return ILApplicationsTable;
        }
        public static DataTable GetAllInternationalLicenses(string filter, string condition)
        {
            DataTable ILApplicationsTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = $"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, " +
                $"IsActive FROM InternationalLicenses WHERE {filter} = @condition;";

            

            if (filter == "None" || condition == string.Empty)
            {
                query = "SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive" +
                " FROM InternationalLicenses";
            }

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@condition", condition);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    ILApplicationsTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return ILApplicationsTable;
        }
        public static bool FindDriverInternationalLicense(ref int InternationalLicenseID, ref int ApplicationID,
                ref int DriverID, int LicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from InternationalLicenses where IssuedUsingLocalLicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    isFound = reader.Read();

                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
            }
            catch (Exception)
            {
                return isFound;
                throw;
            }finally { connection.Close(); }

            return isFound;
        }
        public static DataTable GetInternationalLicenseInfos(int internationalLicenseID)
        {
            DataTable internationalLicenseInfos = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT InternationalLicenses.InternationalLicenseID, InternationalLicenses.IssuedUsingLocalLicenseID, " +
                "People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS FullName, " +
                " People.NationalNo, " +
                " (CASE WHEN People.Gendor = 0 THEN 'Male' WHEN People.Gendor = 1 THEN 'Female' END) AS Gendor, " +
                " InternationalLicenses.IssueDate, Applications.ApplicationID, " +
                " (CASE WHEN InternationalLicenses.IsActive = 1 THEN 'Yes' WHEN InternationalLicenses.IsActive = 0 THEN 'No' END) " +
                " AS IsActive, People.DateOfBirth, InternationalLicenses.DriverID, InternationalLicenses.ExpirationDate," +
                " People.ImagePath" +
                " FROM Applications INNER JOIN" +
                " InternationalLicenses ON InternationalLicenses.ApplicationID = Applications.ApplicationID INNER JOIN" +
                " People ON Applications.ApplicantPersonID = People.PersonID" +
                " WHERE (InternationalLicenses.InternationalLicenseID = @internationalLicenseID);";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    internationalLicenseInfos.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return internationalLicenseInfos;
        }
        public static DataTable GetInternationalLicense(int PersonID)
        {
            DataTable InternationalLicensesTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT InternationalLicenses.* FROM InternationalLicenses JOIN Applications" +
                " ON InternationalLicenses.ApplicationID = Applications.ApplicationID" +
                " WHERE Applications.ApplicantPersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    InternationalLicensesTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return InternationalLicensesTable;
        }
        public static bool isPersonHasInternationalLicense(int localLicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID = @localLicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localLicenseID", localLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.Read();
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime issueDate, 
            DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int internationalLicenseID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, " +
                "IsActive, CreatedByUserID) VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, " +
                "@IsActive, @CreatedByUserID);" +
                "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    internationalLicenseID = insertedID;
                }
            }
            finally
            {
                connection.Close();
            }

            return internationalLicenseID;
        }
    }
}
