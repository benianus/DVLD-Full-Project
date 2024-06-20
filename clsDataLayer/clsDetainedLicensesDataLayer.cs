using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsDetainedLicensesDataLayer
    {
        public static bool isLicenseDetained(string LicenseID)
        {
            bool isDetained = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select * from DetainedLicenses where LicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isDetained = reader.Read();

            }
            finally
            {
                connection.Close();
            }

            return isDetained;
        }
    }
}
