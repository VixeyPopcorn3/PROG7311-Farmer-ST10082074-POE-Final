using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PROG7311_Farmer_ST10082074.Classes
{
    public class DatabaseHelper
    {
        private string connectionString;
        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AzureSQLConnection"].ConnectionString;
        }

        //Following 3 methods are for login page
        public bool ValidateUser(string email, string password)
        {
            Hashing hash = new Hashing();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Password, Salt FROM Users WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["Password"].ToString();
                            string salt = reader["Salt"].ToString();
                            connection.Close();
                            string hashedPassword = hash.HashPassword(password, salt);
                            return storedPassword == hashedPassword;
                        }
                    }
                }
            }

            return false;
        }
        public bool GetUserType(string email)
        {
            bool userType = false;
            string connectionString = ConfigurationManager.ConnectionStrings["AzureSQLConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UserType FROM Users WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userType = Convert.ToBoolean(reader["UserType"]);
                        }
                    }
                }
            }

            return userType;
        }
        

        public void InsertUser(string email, string password, string salt)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Email, Password, UserType, Salt) VALUES (@Email, @Password, 1, @Salt);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Salt", salt);

                    connection.Open();
                    connection.Close();
                }
            }
        }
        public void InsertFarmer(int userId, string firstName, string surname, string email, int phoneNum, string streetAddress, string city)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Farmers (FName, SName, Email, PhoneNum, StreatAddress, City, LoginID) VALUES (@FName, @SName, @Email, @PhoneNum, @StreetAddress, @City, @userId);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FName", firstName);
                    command.Parameters.AddWithValue("@SName", surname);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNum", phoneNum);
                    command.Parameters.AddWithValue("@StreetAddress", streetAddress);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@userId", userId);

                    
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public int GetUserIdByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id FROM Users WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int userId))
                    {
                        return userId;
                    }
                }
            }

            // Return a default value or throw an exception if necessary
            throw new Exception("User not found with the specified email.");
        }

        //method used in the AllFarmers page
        public DataTable GetAllFarmers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT FName, SName, Email, PhoneNum, StreatAddress, City, LoginID FROM Farmers";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }

                }
            }


        }
        
        //method used in the EmployeeDets page
        public static DataTable GetEmployeeDetails(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AzureSQLConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FName, SName, Email, PhoneNum, LoginID FROM Employee WHERE LoginID = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }
        
        //Folowing 4 methods used in the Products page
        public DataTable GetProductsByFarmerID(int loginID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, [Desc], DateAdded, Quantity FROM Products WHERE FarmerID = @loginID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerID", loginID);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        public DataTable GetDistinctProductTypes(int loginID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Name FROM Products WHERE FarmerID = @loginID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerID", loginID);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        public DataTable GetProductsByDateRange(int loginID, DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, [Desc], DateAdded, Quantity FROM Products WHERE FarmerID = @loginID AND DateAdded >= @startDate AND DateAdded <= @endDate";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerID", loginID);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        public DataTable GetProductsByType(int loginID, string productType)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, [Desc], DateAdded, Quantity FROM Products WHERE FarmerID = @loginID AND Name LIKE '%' + @productType + '%'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerID", loginID);
                    cmd.Parameters.AddWithValue("@productType", productType);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }


        //Method used in AddProduct page
        public bool AddProduct(string name, string description, DateTime dateAdded, int quantity, int farmerId)
                {
                    string query = "INSERT INTO Products (Name, [Desc], DateAdded, Quantity, FarmerID) VALUES (@Name, @Desc, @DateAdded, @Quantity, @FarmerID)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Desc", description);
                        command.Parameters.AddWithValue("@DateAdded", dateAdded);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@FarmerID", farmerId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        return rowsAffected > 0;
                    }
                }

        //Following 2 methods used in the FarmerDets page
        public static DataTable GetFarmerDetails(int loginId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AzureSQLConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FName, SName, Email, PhoneNum, StreatAddress, City, LoginID FROM Farmers WHERE LoginID = @loginId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@loginId", loginId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }
        public static void UpdateFarmerDetails(int loginId, string firstName, string surname, string phone, string address, string city)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AzureSQLConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Farmers SET FName = @FName, SName = @SName, PhoneNum = @PhoneNum, StreatAddress = @Address, City = @City WHERE LoginID = @loginId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FName", firstName);
                    command.Parameters.AddWithValue("@SName", surname);
                    command.Parameters.AddWithValue("@PhoneNum", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@loginId", loginId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        //Method used in FarmerProd page
        public static DataTable GetProducts(int farmerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AzureSQLConnection"].ConnectionString;
            string query = "SELECT ID, Name, [Desc], DateAdded, Quantity FROM Products WHERE FarmerID = @FarmerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FarmerID", farmerId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                return dataTable;
            }
        }

    }
}