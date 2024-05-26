using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace clsDataLayer
{
    public static class clsPeopleDataLayer
    {
        public static DataTable GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string Query = "Select * From WithoutImagePath order by PersonID desc";
            
            SqlCommand command = new SqlCommand(Query, connection);

            DataTable dt = new DataTable();
            
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception)
            {
                
                throw;
            }
            finally { connection.Close(); }
            

            return dt;
        }
        public static DataTable GetAllCountries()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string Query = "Select * From Countries";
            SqlCommand command = new SqlCommand(Query, connection);

            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }


            return dt;
        }
        public static DataTable GetCountryName(int CountryID)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string SelectQuery = "Select CountryName from Countries where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(SelectQuery, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            DataTable dt = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return dt;

        }
        public static bool isExistByNationalID(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string FindQuery = "Select * from People where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(FindQuery, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
            { connection.Close(); }

            return isFound;
        }
        public static bool FindPersonByCondition(string Filter, string Condition, ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, 
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Email , ref string Phone, 
            ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string FindQuery = $"select * from People where {Filter} = @Condition;";
            SqlCommand command = new SqlCommand(FindQuery, connection);
            command.Parameters.AddWithValue("@Filter", Filter);
            command.Parameters.AddWithValue("@Condition", Condition);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.Read();

                PersonID = (int)reader["PersonID"];
                NationalNo = (string)reader["NationalNo"];
                FirstName = (string)reader["FirstName"];
                SecondName = (string)reader["SecondName"];
                ThirdName = (string)reader["ThirdName"];
                LastName = (string)reader["LastName"];
                DateOfBirth = (DateTime)reader["DateOfBirth"];
                Gendor = (byte)reader["Gendor"];
                Address = (string)reader["Address"];
                Email = (string)reader["Email"];
                Phone = (string)reader["Phone"];
                NationalityCountryID = (int)reader["NationalityCountryID"];

                if (reader["ImagePath"] != System.DBNull.Value)
                {
                    ImagePath = (string)reader["ImagePath"];
                }
                else
                {
                    ImagePath = string.Empty;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return isFound;
                throw;
            }
            finally { connection.Close(); }

            return isFound;
        }
        public static bool FindByPersonID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref int Gendor, ref string Address, ref string Email, ref string Phone, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string FindQuery = "Select * from People where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(FindQuery, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.Read();

                PersonID = (int)reader["PersonID"];
                NationalNo = (string)reader["NationalNo"];
                FirstName = (string)reader["FirstName"];
                SecondName = (string)reader["SecondName"];
                ThirdName = (string)reader["ThirdName"];
                LastName = (string)reader["LastName"];
                DateOfBirth = (DateTime)reader["DateOfBirth"];
                Gendor = (byte)reader["Gendor"];
                Address = (string)reader["Address"];
                Email = (string)reader["Email"];
                Phone = (string)reader["Phone"];
                NationalityCountryID = (int)reader["NationalityCountryID"];

                if ((string)reader["ImagePath"] != "")
                {
                    ImagePath = (string)reader["ImagePath"];
                }
                else
                {
                    ImagePath = System.DBNull.Value.ToString();
                }
            }
            catch (Exception)
            {
                return isFound;
                throw;
            }
            finally
            { connection.Close(); }

            return isFound;
        }
        public static bool FindByNationalNO(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref int Gendor, ref string Address, ref string Email, ref string Phone, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string FindQuery = "Select * from People where NationalNO = @NationalNO";
            SqlCommand command = new SqlCommand(FindQuery, connection);
            command.Parameters.AddWithValue("@NationalNO", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.Read();

                PersonID = (int)reader["PersonID"];
                NationalNo = (string)reader["NationalNo"];
                FirstName = (string)reader["FirstName"];
                SecondName = (string)reader["SecondName"];
                ThirdName = (string)reader["ThirdName"];
                LastName = (string)reader["LastName"];
                DateOfBirth = (DateTime)reader["DateOfBirth"];
                Gendor = (byte)reader["Gendor"];
                Address = (string)reader["Address"];
                Email = (string)reader["Email"];
                Phone = (string)reader["Phone"];
                NationalityCountryID = (int)reader["NationalityCountryID"];

                if ((string)reader["ImagePath"] != "")
                {
                    ImagePath = (string)reader["ImagePath"];
                }
                else
                {
                    ImagePath = System.DBNull.Value.ToString();
                }
            }
            catch (Exception)
            {
                return isFound;
                throw;
            }
            finally
            { connection.Close(); }

            return isFound;
        }
        public static DataTable FilterBy(string Filter)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string FilterQuery = $"select * from WithoutImagePath order by {Filter} asc";

            if (Filter == "None")
            {
                FilterQuery = $"select * from WithoutImagePath order by PersonID desc";
            }
            else
            {
                FilterQuery = $"select * from WithoutImagePath order by {Filter} asc";
            }

            SqlCommand command = new SqlCommand(FilterQuery, connection);

            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return dt;
        }
        public static DataTable FilterBy(string Filter, string Condition)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string FilterQuery = $"select * from WithoutImagePath where {Filter} like '%' + @Condition + '%' order by {Filter} asc";

            if (Filter == "None")
            {
                FilterQuery = $"select * from WithoutImagePath where {Filter} like '%' + @Condition + '%' order by PersonID desc";
            }
            else
            {
                FilterQuery = $"select * from WithoutImagePath where {Filter} like '%' + @Condition + '%' order by {Filter} asc";
            }

            SqlCommand command = new SqlCommand(FilterQuery, connection);
            command.Parameters.AddWithValue("@Condition", Condition);

            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return dt;
        }
        public static int AddNewPerson( string NationalNo,  string FirstName,  string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth,
             int Gendor,  string Address,  string Email,  string Phone,  int NationalityCountryID,  string ImagePath)
        {
            int PersonID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string InsertQuery = @"Insert into People (NationalNO, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Email, Phone, NationalityCountryID, ImagePath)
                                    values (@NationalNO, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address,@Email, @Phone, @NationalityCountryID, @ImagePath);
                                    select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(InsertQuery, connection);

            command.Parameters.AddWithValue("@NationalNO", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string NationalNO, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
           int Gendor, string Address, string Email, string Phone, int NationalityCountryID, string ImagePath )
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string UpdateQuery = @"Update People set 
                                    NationalNO = @NationalNO, FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName,
                                    DateOfBirth = @DateOfBirth, Gendor = @Gendor, Address = @Address, Email = @Email, Phone = @Phone, NationalityCountryID = @NationalityCountryID,
                                    ImagePath = @ImagePath where PersonID = @PersonID;
                                    ";

            SqlCommand command = new SqlCommand(UpdateQuery, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNO", NationalNO);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value); 
            }
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { connection.Close(); }

            return RowsAffected > 0;

        }
        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string DeleteQuery = "Delete from People where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(DeleteQuery, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception )
            {
                
                return false;
                throw;
            }
            finally { connection.Close(); };

            return RowsAffected > 0;
        }
    }
}
