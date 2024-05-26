using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsApplicationsDataLayer
    {
        public static bool isApplicationExists(int ApplicationPersonID, int ApplicationTypeID, byte ApplicationStatus)
        {
            bool isApplicationExists = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from Applications where ApplicationStatus = @ApplicationStatus and ApplicantPersonID = @ApplicantPersonID " +
                "and ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);   
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isApplicationExists = reader.Read();
            }
            catch (Exception)
            {
                return isApplicationExists;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return isApplicationExists;

        }

        public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string InsertQuery = "insert into Applications (ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees," +
                "CreatedByUserID) values (@ApplicationPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees,CreatedByUserID);" +
                "Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(InsertQuery, connection);
            command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ApplicationID;
        }
    }
}
