using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public class clsTestAppointementsDataLayer
    {
        public static bool isPersonPassTestAppointment(int LDLApplicationID, int TestTypeID)
        {
            bool isPersonPassTheTest = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments " +
                "INNER JOIN Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID " +
                "WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestResult = 1 and TestTypeID = @TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isPersonPassTheTest = reader.Read();
            }
            catch
            {
                return isPersonPassTheTest;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return isPersonPassTheTest;
        }
        public static bool isTestAppointmentLinkedToRetakeTestApplicationType(int TestAppointmentID)
        {
            bool isTestAppointmentLinkedToRetake = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments where TestAppointmentID = @TestAppointmentID and RetakeTestApplicationID is not null;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isTestAppointmentLinkedToRetake = reader.Read();

            }
            catch 
            {
                return isTestAppointmentLinkedToRetake;
                throw; 
            }
            finally
            {
                connection.Close();
            }

            return isTestAppointmentLinkedToRetake;
        }
        public static bool isTestAppointmentLockedAndTestFailed(int TestAppointmentID)
        {
            bool isTestAppointmentLockedAndFail = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select * from TestAppointments " +
                "join tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID " +
                "where TestAppointments.TestAppointmentID = @TestAppointmentID and TestAppointments.IsLocked = 1 and Tests.TestResult = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isTestAppointmentLockedAndFail = reader.Read();
            }
            catch
            {
                return isTestAppointmentLockedAndFail;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return isTestAppointmentLockedAndFail;
        }
        public static bool isPersonFailInTheTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isPersonFailInTheTest = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments " +
                "INNER JOIN Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID " +
                "WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestResult = 0 and TestTypeID = @TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isPersonFailInTheTest = reader.Read();
            }
            catch 
            {
                return isPersonFailInTheTest;
                throw; 
            }
            finally
            {
                connection.Close();
            }
            return isPersonFailInTheTest;
        }
        public static int _GetTestTrialNumber(string LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int trial = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select count(*) as Trial from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and IsLocked = 1 and TestTypeID = @TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int TrialCount))
                {
                    trial = TrialCount;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return trial;
        }
        public static bool isTestAppointmentLocked(int TestAppointementID)
        {
            bool isLocked = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments where TestAppointmentID = @TestAppointementID and IsLocked = 1;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointementID", TestAppointementID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isLocked = reader.HasRows;
            }
            catch
            {
                return isLocked;
                throw; }
            finally
            {
                connection.Close();
            }

            return isLocked;    
        }
        public static bool FindTestAppointment(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees,
                ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
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
                    if (reader["RetakeTestApplicationID"] == System.DBNull.Value)
                    {
                        RetakeTestApplicationID = 0;
                    }
                    else
                    {
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    }
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
        public static DataTable GetTestAppointmentByLDLApplicationID(int LDLApplicationID, int TestTypeID)
        {
            DataTable TestAppointmentTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked FROM TestAppointments " +
                "WHERE (LocalDrivingLicenseApplicationID = @LDLApplicationID) and (TestTypeID = @TestTypeID) " +
                "ORDER BY IsLocked ASC;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    TestAppointmentTable.Load(reader);
                }
            }
            catch { throw; }
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
        public static bool isPersonHasTestAppointment(int LDLApplcication, int TestTypeID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query = "select * from TestAppointments where LocalDrivingLicenseApplicationID = @LDLApplcication and TestTypeID = @TestTypeID and IsLocked = 0;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLApplcication", LDLApplcication);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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
        public static int AddNewTestAppointment(int TestTypeID, int LDLApplication, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int TestAppointmentID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string query =  "INSERT INTO TestAppointments " +
                                        "(TestTypeID, " +
                                        "LocalDrivingLicenseApplicationID, " +
                                        "AppointmentDate, " +
                                        "PaidFees, " +
                                        "CreatedByUserID, " +
                                        "IsLocked," +
                                        "RetakeTestApplicationID)" +
                            "VALUES " +
                                        "(@TestTypeID, " +
                                        "@LocalDrivingLicenseApplicationID, " +
                                        "@AppointmentDate, " +
                                        "@PaidFees, " +
                                        "@CreatedByUserID, " +
                                        "@IsLocked," +
                                        "@RetakeTestApplicationID);" +
                            "SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplication);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID == 0)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }

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
                 int CreatedByUserID,  bool IsLocked, int RetakeTestApplicationID)
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
            if (RetakeTestApplicationID == 0)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }

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
