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
    public static class clsUserDataLayer
    {
        public static DataTable GetAllUsers()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string SelectQuery = "select * from UsersWithFullName ORDER by UserID DESC";
            SqlCommand command = new SqlCommand(SelectQuery, connection);

            DataTable UsersTable = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    UsersTable.Load(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return UsersTable;
        }
        public static DataTable GetUsersFilteredBy(string Filter, string Condition)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            
            string FilterQuery = string.Empty;

            if (Filter == "None")
            {
                 FilterQuery = $"select * from UsersWithFullName order by UserID desc";
            }
            else if (Filter == "IsActive")
            {
                FilterQuery = _IsActiveFilters(Filter, Condition);
            }
            else
            {
                 FilterQuery = $"select * from UsersWithFullName where {Filter} like '%' + @Condition + '%' order by {Filter} asc";
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
        public static int GetPersonIDofCurrentUser(int UserID)
        {
            int PersonID = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.connectionString);
            string Query = $"Select PersonID from Users where {UserID} = @UserID;";
            SqlCommand Command  = new SqlCommand(Query, Connection );

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return PersonID;             
        }
        private static string _IsActiveFilters(string Filter, string Condition)
        {
            string FilterQuery;
            switch (Condition)
            {
                case "All":
                    FilterQuery = $"select * from UsersWithFullName order by {Filter} desc";
                    break;
                case "Yes":
                    FilterQuery = $"select * from UsersWithFullName where {Filter} = 1 order by {Filter} asc";
                    break;
                default:
                    FilterQuery = $"select * from UsersWithFullName where {Filter} = 0 order by {Filter} asc";
                    break;
            }

            return FilterQuery;
        }
        public static bool isUserExist(string Username, string Password)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string SelectQuery = "select * from Users where UserName = @UserName and Password = @Password;";
            SqlCommand command = new SqlCommand(SelectQuery, connection);
            command.Parameters.AddWithValue("@UserName", Username);
            command.Parameters.AddWithValue("@Password", Password);

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
            finally { connection.Close(); }

            return isFound;
        }
        public static bool isUserActive(string Username, string Passoword)
        {
            bool isActive = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string SelectQuery = "select * from Users where UserName = @UserName and Password = @Password and IsActive = 1";
            SqlCommand command = new SqlCommand(SelectQuery, connection);

            command.Parameters.AddWithValue("@UserName", Username);
            command.Parameters.AddWithValue("@Password", Passoword);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader ();

                isActive = reader.Read();
            }
            catch (Exception)
            {
                return isActive;
                throw;
            }
            finally { connection.Close(); }

            return isActive;
        }
        public static bool FindUser(string Filter, string Condition,ref int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string Query = $"Select * From Users where {Filter} = @Condition";
            SqlCommand command = new SqlCommand (Query, connection);

            command.Parameters.AddWithValue("@Filter", Filter);
            command.Parameters.AddWithValue("@Condition", Condition);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.Read();

                if (isFound)
                {
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                
            }
            catch (Exception)
            {
                return isFound;
                throw;
            }finally { connection.Close(); }

            return isFound;
        }
        public static bool FindUser(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string Query = "Select * From Users where UserID = @UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.Read();

                if (isFound)
                {
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                
            }
            catch (Exception)
            {
                return isFound;
                throw;
            }
            finally { connection.Close(); }

            return isFound;
        }
        public static bool isUserLinkedToPerson(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string FindQuery = "Select * From Users INNER JOIN People on Users.PersonID = People.PersonID where People.PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(FindQuery, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
            }
            catch (Exception)
            {
                return isFound;
                throw;
            }
            return isFound;
        }
        public static int AddNewUser(int PersonID, string UserName, string Password, bool isActive)
        {
            int UserID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string InsertQuery = @"Insert into Users (PersonID, UserName, Password, IsActive) values (@PersonID, @UserName, @Password, @IsActive);
                                    Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(InsertQuery, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("Password", Password);
            command.Parameters.AddWithValue("IsActive", isActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedUserID))
                {
                    UserID = insertedUserID;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                throw;
            }
            finally { connection.Close(); }


            return UserID;
        }
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string UpdateQuery = "update Users set PersonID = @PersonID, UserName = @UserName, Password = @Password, IsActive = @IsActive where UserID = @UserID;";
            SqlCommand command = new SqlCommand(UpdateQuery, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return RowsAffected > 0;
                throw;
            }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }
        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            string DeleteQuery = "delete from Users where UserID = @UserID;";
            SqlCommand command = new SqlCommand(DeleteQuery, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }
    }
}
