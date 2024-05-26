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
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.connectionString);
            string GetQuery = "SELECT * FROM LocalDrivingLicenseApplications_View;";
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
    }
}
