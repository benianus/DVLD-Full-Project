using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsLicensesDataLayer
    {
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
