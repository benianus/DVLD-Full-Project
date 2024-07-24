using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace clsDataLayer
{
    
    public class clsLicensesDataLayer
    {
        public static DataTable GetLicenseInfos(int LicenseID)
        {
            DataTable DriverLicenseInfos = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from LicenseInfos_view where licenseID = @LicenseID;";
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return DriverLicenseInfos;
        }
        public static bool isLicenseExpired(int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID and ExpirationDate < GETDATE();";
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool isLicenseActive(int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID and IsActive = 1;";
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool isLicenseExists(int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID;";
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool DeactivateOldLicense(int Licenses)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "Update Licenses Set IsActive = 0 WHERE LicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", Licenses);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
        public static bool ActivateOldLicense(int Licenses)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "Update Licenses Set IsActive = 1 WHERE LicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", Licenses);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
        public static int GetLicenseClassID(int LicenseID)
        {
            int licenseClassID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT Licenses.LicenseClass FROM Licenses " +
                " JOIN LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID " +
                " WHERE Licenses.LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Value))
                {
                    licenseClassID = Value;
                }
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return licenseClassID;
        }
        public static int GetLicenseFees(int LicenseID)
        {
            decimal ApplicationFees = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT PaidFees FROM Licenses WHERE LicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out decimal Value))
                {
                    ApplicationFees = Value;
                }
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return (int)ApplicationFees;
        }
        public static int GetApplicationIDRelatedToLicense(int LicenseID)
        {
            int applicationID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT Applications.applicationID" +
                           " FROM Licenses INNER JOIN" +
                           " Applications ON Licenses.ApplicationID = Applications.ApplicationID where Licenses.LicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Value))
                {
                    applicationID = Value;
                }
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return applicationID;
        }
        public static int GetLocalApplicationIDRelatedToThisLicense(int ApplicationID)
        {
            int LDLApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID FROM Licenses INNER JOIN" +
                " Applications ON Licenses.ApplicationID = Applications.ApplicationID INNER JOIN" +
                " LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID " +
                " WHERE Applications.ApplicationID = @ApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LDLApplicationID = insertedID;
                }
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return LDLApplicationID;
        }
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
            catch(Exception error)
            {
                clsDataSettings.CreateEventLog(error);
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
            string query = "select * from LicenseInfos_view where licenseID = @LicenseID and IsActive = 'Yes' and ExpirationDate > IssueDate " +
                "and ClassName = 'Class 3 - Ordinary driving license';";
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return DriverLicenseInfos;
        }
        public static DataTable GetExpiredDriverLicense(int LicenseID)
        {
            DataTable DriverLicenseInfos = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from LicenseInfos_view where licenseID = @LicenseID and ExpirationDate < GETDATE();";
                ;
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return DriverLicenseInfos;
        }
        public static DataTable GetNotExpiredDriverLicense(int LicenseID)
        {
            DataTable DriverLicenseInfos = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from LicenseInfos_view where licenseID = @LicenseID and ExpirationDate > GETDATE();";
            ;
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
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
            string query = "select distinct Licenses.LicenseID, Licenses.ApplicationID, t1.ClassName," +
                           " Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive from Applications" +
                           " JOIN People ON APPLICATIONS.ApplicantPersonID = people.PersonID" +
                           " JOIN Licenses ON Applications.ApplicationID = licenses.ApplicationID" +
                           " JOIN(select * from Licenses JOIN LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID) t1 On Licenses.LicenseClass = t1.LicenseClassID" +
                           " Where people.PersonID = @PersonID" +
                           " ORDER BY Licenses.LicenseID DESC; ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    LocalLicensesHistoryTable.Load(reader);
                }
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
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
            catch (Exception e) 
            {
                clsDataSettings.CreateEventLog(e);
                return isApplicationHasDriverLicense;
                throw; 
            }
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }
    }
}
