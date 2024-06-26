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
        public static int GetDriverRelatedToPerson(int personID)
        {
            int driverID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT DriverID FROM Drivers WHERE PersonID = @personID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    driverID = (int)result;
                }
            }
            finally
            {
                connection.Close();
            }

            return driverID;
        }
        public static DataTable FilterDriversBy(string filter, string condition)
        {
            DataTable driversTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = $"SELECT * FROM Drivers_view where {filter} = @condition;";

            if (filter == "None" || condition == string.Empty)
            {
                query = "SELECT * FROM Drivers_view;";
            }

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@condition", condition);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    driversTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return driversTable;
        }
        public static DataTable GelAllDrivers()
        {
            DataTable driversTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM Drivers_view;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    driversTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return driversTable;
        }
        public static bool isDriverAlreadyExists(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static int AddNewDriver(int PersonID, int CreateByUserID, DateTime CreatedDate)
        {
            int DriverID = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "Insert into Drivers (PersonID, CreatedByUserID, CreatedDate) values (@PersonID, @CreatedByUserID, @CreatedDate);" +
                "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreateByUserID);    
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
                }
            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }
        public static DataTable GetDriverLicenseInfosByLDLApplicationID(int ApplicationID)
        {
            DataTable DriverLicenseInfosTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from DriverLicenseInfos_view where ApplicationID = @ApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
        public static DataTable GetDriverLicenseInfosByLicenseID(int LDLApplicationID)
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
