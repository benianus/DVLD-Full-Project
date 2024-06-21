using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsInternationalLicensesDataLayer
    {
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
    }
}
