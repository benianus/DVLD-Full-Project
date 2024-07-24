using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsDataLayer
{
    public class clsApplicationsTypesDataLayer
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.connectionString);
            string GetQuery = "SELECT * FROM ApplicationTypes;";
            SqlCommand command = new SqlCommand(GetQuery, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally { Connection.Close(); }

            return dt;
        }
        
        public static int GetApplicationTypeFees(string ApplicationTypeTitle)
        {
            int ApplicationFees = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select ApplicationFees from ApplicationTypes where ApplicationTypeTitle = @ApplicationTypeTitle;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    ApplicationFees = Convert.ToInt32(result);
                }
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally { connection.Close(); }

            return ApplicationFees;
        }
        public static bool FindApplicationType(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool isFound = true;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "Select * from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.Read();

                if (isFound)
                {
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)reader["ApplicationFees"];
                }
            }
            catch (Exception error)
            {
                
                clsDataSettings.CreateEventLog(error);
                return isFound;
                throw;
            }
            finally { connection.Close(); }

            return isFound;
        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string updateQuery = "Update ApplicationTypes set ApplicationTypeTitle = @ApplicationTypeTitle, ApplicationFees = @ApplicationFees where ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                return false;
                throw;
            }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }
    }
}
