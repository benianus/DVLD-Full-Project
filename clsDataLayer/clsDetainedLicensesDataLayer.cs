using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsDetainedLicensesDataLayer
    {
        public static DataTable GetDetainedLicenses(string filter, string condition)
        {
            DataTable detainedLicenseTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "SELECT * FROM DetainedLicenses_view" +
                $" WHERE {filter} = @condition" +
                $" ORDER BY {filter} DESC;";
                

            if (filter == "None" || condition == string.Empty)
            {
                query = "SELECT * FROM DetainedLicenses_view" +
                " ORDER BY DetainID DESC;";
            }

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@condition", condition);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    detainedLicenseTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return detainedLicenseTable;
        }
        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
                bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "UPDATE DetainedLicenses SET " +
                " LicenseID = @LicenseID," +
                " DetainDate = @DetainDate," +
                " FineFees = @FineFees," +
                " CreatedByUserID = @CreatedByUserID," +
                " IsReleased = @IsReleased," +
                " ReleaseDate = @ReleaseDate," +
                " ReleasedByUserID = @ReleasedByUserID," +
                " ReleaseApplicationID = @ReleaseApplicationID" +
                " WHERE DetainID = @detainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
        public static bool ReleaseLicense(int detainID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "UPDATE DetainedLicenses SET IsReleased = 1 WHERE DetainID = @detainID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@licenseID", detainID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
        public static bool FindDetainedLicense(ref int detainID, int licenseID, ref DateTime detainDate, ref decimal finFees,  
           ref int createdByUserID, ref bool isReleased, ref DateTime releaseDate, ref int releasedByUserID, ref int releaseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @licenseID and IsReleased = 0;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@licenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    isFound = reader.Read();

                    detainID = (int)reader["DetainID"];
                    licenseID = (int)reader["LicenseID"];
                    detainDate = (DateTime)reader["DetainDate"];
                    finFees = (decimal)reader["FineFees"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == System.DBNull.Value)
                    {
                        releaseDate = default;
                    }
                    else
                    {
                        releaseDate = (DateTime)reader["ReleaseDate"];
                    }

                    if (reader["ReleasedByUserID"] == System.DBNull.Value)
                    {
                        releasedByUserID = default;
                    }
                    else
                    {
                        releasedByUserID = (int)reader["ReleasedByUserID"];
                    }

                    if (reader["ReleaseApplicationID"] == System.DBNull.Value)
                    {
                        releaseApplicationID = default;
                    }
                    else
                    {
                        releaseApplicationID = (int)reader["releaseApplicationID"];
                    }
                }
            }
            finally
            {
                connection.Close();
            }

            return isFound; 
        }
        public static bool isLicenseDetained(string LicenseID)
        {
            bool isDetained = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select * from DetainedLicenses where LicenseID = @LicenseID and IsReleased = 0";
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
        public static bool isLicenseReleased(string LicenseID)
        {
            bool isDetained = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select * from DetainedLicenses where LicenseID = @LicenseID and IsReleased = 1";
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
        public static int AddNewDetainedLicense(int LicensesID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
                bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int detainID = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)" +
                " VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);" +
                " SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicensesID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);

            if (FineFees == 0)
            {
                command.Parameters.AddWithValue("@FineFees", 0);
            }
            else
            {
                command.Parameters.AddWithValue("@FineFees", FineFees);
            }

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (ReleaseDate == default)
            {
                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }

            if (ReleasedByUserID == default)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            }

            if (ReleaseApplicationID == default)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    detainID = insertedID;
                }
            }
            finally
            {
                connection.Close();
            }

            return detainID;
        }
    }
}
