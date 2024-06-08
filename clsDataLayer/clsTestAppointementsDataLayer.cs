using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsTestAppointementsDataLayer
    {
        public static bool FindTestAppointment(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees,
                ref int CreatedByUserID, ref bool IsLocked)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments where TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    IsFound = reader.Read();

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                }
                

            }
            catch(Exception)
            {
                IsFound = false;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
        public static int GetTestAppointmentID(int LDLApplicationID)
        {
            int TestAppointemetID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select TestAppointmentID from TestAppointments where LocalDrivingLicenseApplicationID = @LDLApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    TestAppointemetID = ID;
                }
            }
            catch (Exception)
            { throw; }
            finally
            {
                connection.Close();
            }

            return TestAppointemetID;
        }
        public static DataTable GetTestAppointmentByID(int TestAppointmentID)
        {
            DataTable TestAppointmentTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments_View where TestAppointmentID = @TestAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    TestAppointmentTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentTable;
        }
        public static DataTable GetAllTestAppointmen()
        {
            DataTable TestAppointmentTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments;";
            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestAppointmentTable.Load(reader);
                }
            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentTable;
        }
        public static bool isPersonHasTestAppointment(int LDLApplcication)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments where LocalDrivingLicenseApplicationID = @LDLApplcication and TestTypeID = 1 and IsLocked = 0;";
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
        public static int AddNewTestAppointment(int TestTypeID, int LDLApplication, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int TestAppointmentID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query =  "INSERT INTO TestAppointments " +
                                        "(TestTypeID, " +
                                        "LocalDrivingLicenseApplicationID, " +
                                        "AppointmentDate, " +
                                        "PaidFees, " +
                                        "CreatedByUserID, " +
                                        "IsLocked)" +
                            "VALUES " +
                                        "(@TestTypeID, " +
                                        "@LocalDrivingLicenseApplicationID, " +
                                        "@AppointmentDate, " +
                                        "@PaidFees, " +
                                        "@CreatedByUserID, " +
                                        "@IsLocked);" +
                            "SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplication);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestAppointmentID = InsertedID;
                }
            }
            catch (Exception){ throw; }
            finally
            {
                connection.Close();
            }

            return TestAppointmentID;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID,  int TestTypeID,  int LocalDrivingLicenseApplicationID,  DateTime AppointmentDate,  decimal PaidFees,
                 int CreatedByUserID,  bool IsLocked)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = @"Update TestAppointments set
                                    TestTypeID = @TestTypeID,
                                    LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                    AppointmentDate = @AppointmentDate,
                                    PaidFees = @PaidFees,
                                    CreatedByUserID = @CreatedByUserID,
                                    IsLocked = @IsLocked
                           Where TestAppointmentID = @TestAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }            
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }
    }
}
