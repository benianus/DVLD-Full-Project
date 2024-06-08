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
    public class clsApplicationsDataLayer
    {
        public static bool FindApplication(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref byte ApplicationStatus,
                ref decimal PaidFees, ref int CreatedByUserID )
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from applications where applicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetApplicationInfos(int LDLApplication)
        {
            DataTable ApplicationTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from Applications_view where LocalDrivingLicenseApplicationID = @LDLApplication;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLApplication", LDLApplication);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    ApplicationTable.Load(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); } 

            return ApplicationTable;
        }
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string InsertQuery = "insert into Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees," +
                "CreatedByUserID) values (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);" +
                "Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(InsertQuery, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
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
        public static bool CancelApplication(byte selectedApplication)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = @"UPDATE Applications set Applications.ApplicationStatus = 2 from LocalDrivingLicenseApplications join Applications 
                            on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 
                            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @selectedApplication; ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SelectedApplication", selectedApplication);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
                throw;
            }
            finally { connection.Close(); }

            return RowsAffected > 0;    
        }
    }
}
