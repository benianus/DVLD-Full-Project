﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsLicenseClassesDataLayer
    {
        public static int GetMinimumAllowedAge(int LicenseClassID)
        {
            int minimumAge = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT MinimumAllowedAge FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Value))
                {
                    minimumAge = Value;
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

            return minimumAge;
        }
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
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
            catch (Exception error)
            {
                clsDataSettings.CreateEventLog(error);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return defaultValidityLength;
        }
    }
}
