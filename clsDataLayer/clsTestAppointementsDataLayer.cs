using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsTestAppointementsDataLayer
    {
        public static bool isPersonHasTestAppointment(int LDLApplcication)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments_View where LocalDrivingLicenseApplicationID = @LDLApplcication and TestTypeTitle = 'Vision Test' and IsLocked = 0;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLApplcication", LDLApplcication);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.Read();
            }
            catch (Exception)
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
