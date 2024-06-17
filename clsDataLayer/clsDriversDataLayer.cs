using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsDriversDataLayer
    {
        public static DataTable GetDriverLicenseInfos(int LDLApplicationID)
        {
            DataTable DriverLicenseInfosTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from DriverLicenseInfos_view where LocalDrivingLicenseApplicationID = @LDLApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DriverLicenseInfosTable.Load(reader);
                }
            }
            catch { throw; }
            finally
            {
                connection.Close();
            }

            return DriverLicenseInfosTable;
        }
        public static bool FindDriverByPersonID(ref int DriverID, int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM Drivers where PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isFound = reader.Read();

                    DriverID = (int)reader["DriverID"];
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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
    }
}
