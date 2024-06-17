using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsLicenseClassesDataLayer
    {
        public static int GetLicenseClassID(string ClassName)
        {
            int LicenseClassID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return LicenseClassID;
        }

        public static byte GetDefaultValidityLength(int LicenseClassID)
        {
            byte defaultValidityLength = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "Select DefaultValidityLength from LicenseClasses where LicenseClassID = @LicenseClassID;";
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null && byte.TryParse(result.ToString(), out byte Years))
                {
                    defaultValidityLength = Years;
                }
            }
            finally
            {
                connection.Close();
            }

            return defaultValidityLength;
        }
    }
}
