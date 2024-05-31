using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace clsDataLayer
{
    public class clsLocalDriverLicenseApplicationDataLayer
    {
        public static DataTable GetLicenseClasses()
        {
            DataTable ClassesTitlesTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select ClassName from LicenseClasses;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    ClassesTitlesTable.Load(reader);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); } 

            return ClassesTitlesTable;
        }
        public static int GetHowMuchTestsPassed(int LDLApplication)
        {
            int PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select PassedTestCount from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID  = @LocalDriverLicenseApplication;" +
                "Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDriverLicenseApplication", LDLApplication);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int valueRetrieved))
                {
                    PassedTestCount = valueRetrieved;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return PassedTestCount;
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.connectionString);
            string GetQuery = "SELECT * FROM LocalDrivingLicenseApplications_View order by LocalDrivingLicenseApplicationID desc;";
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
                MessageBox.Show(error.Message);
                throw;
            }
            finally { Connection.Close(); }

            return dt;
        }
        public static DataTable GetDrivingLicenseApplicationnInfo(int LDLApplication)
        {
            DataTable LocalDrivingLicenseApplicationTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @LDLApplication";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLApplication", LDLApplication);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    LocalDrivingLicenseApplicationTable.Load(reader);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return LocalDrivingLicenseApplicationTable;
        }
        public static DataTable FilterLocalDrivingLicenseApplicationBy(string Filter, string Condition)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.connectionString);
            string GetQuery = $"SELECT * FROM LocalDrivingLicenseApplications_View where {Filter} = @Condition;";

            if (Filter == "None" || Condition == "All" || Condition == string.Empty)
            {
                GetQuery = "Select * From LocalDrivingLicenseApplications_View;";
            }
            
            SqlCommand command = new SqlCommand(GetQuery, Connection);
            //command.Parameters.AddWithValue("@Filter", Filter);
            command.Parameters.AddWithValue("@Condition", Condition);

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
                MessageBox.Show(error.Message);
                throw;
            }
            finally { Connection.Close(); }

            return dt;
        }
        public static bool isLocalApplcationNew(string NationalNo, string ClassName, string Status)
        {
            bool isExists = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select * from LocalDrivingLicenseApplications_View where NationalNo = @NationalNo and Status = @Status and ClassName = @ClassName;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isExists = reader.Read();
            }
            catch (Exception)
            {
                return isExists;
                throw;
            }
            finally { connection.Close(); }
            return isExists;
        }
        public static bool isLocalApplcationCompleted(string NationalNo, string ClassName, string Status)
        {
            bool isExists = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select * from LocalDrivingLicenseApplications_View where NationalNo = @NationalNo and Status = @Status and ClassName = @ClassName;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isExists = reader.Read();
            }
            catch (Exception)
            {
                return isExists;
                throw;
            }
            finally { connection.Close(); }
            return isExists;
        }
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplication = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "insert into LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) values (@ApplicationID, @LicenseClassID);" +
                "Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplication = insertedID;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return LocalDrivingLicenseApplication;
        }
    }
}
