using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;

namespace DataAccessLayer.DALs
{ 
    public class AccountDAL : IAccountDAL
    { 
        private DataAccessLayer dal = new DataAccessLayer();
        private string query;
        private SqlCommand cmd;
        private SqlConnection conn;

        public List<string> GetAllCustomerEmails()
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    List<string> emails = new List<string>();

                    string query = "select Customer.email from [dbo].[Customer]";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                emails.Add((string)reader[0]);
                            }
                        }
                    }
                    return emails;
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    List<Customer> people = new List<Customer>();

                    query = "select * from [dbo].[Customer]";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                people.Add(new Customer(reader.GetInt32("personID"),
                                    reader.GetString("name"),
                                    reader.GetString("password"),
                                    reader.GetString("email"),
                                    reader.GetString("address"),
                                    reader.GetString("phone_number"),
                                    reader.GetInt32("age"),
                                    (Gender)reader.GetInt32("gender")));
                            }
                        }
                    }
                    return people;
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Admin> GetAllAdmins()
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    List<Admin> people = new List<Admin>();

                    query = "select * from [dbo].[Admin]";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                people.Add(new Admin(reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5)));
                            }
                        }
                    }
                    return people;
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string GetCustomerSalt(string email)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select salt from dbo.Customer where email = @Email";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        string salt = cmd.ExecuteScalar() as string;
                        return salt;
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string GetAdminSalt(string email)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select salt from dbo.Admin where email = @Email";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        string salt = cmd.ExecuteScalar() as string;
                        return salt;
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string GetCustomerPassword(string email)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select password from dbo.Customer where email = @Email";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue ("@Email", email);
                        string pass = cmd.ExecuteScalar() as string;
                        return pass;
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string GetAdminPassword(string email)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select password from dbo.Admin where email = @Email";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        string pass = cmd.ExecuteScalar() as string;
                        return pass;
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Customer GetCustomer(string email, string password)
        {

            try
            {
                string salt = GetCustomerSalt(email);
                //string passwordHash = PasswordHasing.GetHash(password,salt);
                string pass = GetCustomerPassword(email);
                if (PasswordHasing.ValidatePassword(password, salt, pass))
                {
                    conn = dal.GetConnection();
                    using (conn)
                    {
                        query = $"select * from dbo.Customer where email = @Email";
                        using (cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new Customer(reader.GetInt32("personID"),
                                    reader.GetString("name"),
                                    reader.GetString("password"),
                                    reader.GetString("email"),
                                    reader.GetString("address"),
                                    reader.GetString("phone_number"),
                                    reader.GetInt32("age"),
                                    (Gender)reader.GetInt32("gender"));
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Admin GetAdmin(string email, string password)
        {

            try
            {
                string salt = GetAdminSalt(email);
                //string passwordHash = PasswordHasing.GetHash(password,salt);
                string pass = GetAdminPassword(email);
                if (PasswordHasing.ValidatePassword(password, salt, pass))
                {
                    conn = dal.GetConnection();
                    using (conn)
                    {
                        query = $"select * from dbo.Admin where email = @Email";
                        using (cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new Admin(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Customer GetCustomerByID(int? ID)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select * from dbo.Customer where personID = @personID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@personID", ID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Customer(reader.GetInt32("personID"),
                                    reader.GetString("name"),
                                    reader.GetString("password"),
                                    reader.GetString("email"),
                                    reader.GetString("address"),
                                    reader.GetString("phone_number"),
                                    reader.GetInt32("age"),
                                    (Gender)reader.GetInt32("gender"));
                        }
                    }
                    return null;
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Admin GetAdminByID(int ID)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select * from dbo.Admin where personID = @personID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@personID", ID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return new Admin(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                        }
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string GetAdminPasswordByEmail(string email)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select password from dbo.Admin where email = @Email";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string storedHash = cmd.ExecuteScalar() as string;
                                return storedHash;
                            }
                        }
                    }
                    return null;
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool DoesAccountExist(string email)
        {
            try
            {
                foreach (Customer acc in GetAllCustomers())
                {
                    if (email == acc.Email)
                        return true;
                }
                foreach (Admin admin in GetAllAdmins())
                {
                    if (email == admin.Email)
                        return true;
                }
                return false;
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool AddCustomerAccount(string name, string password, string email, string address, string phoneNumber, int age, Gender gender)
        {
            string salt = PasswordHasing.GetSalt();
            string passwordHash = PasswordHasing.GetHash(password, salt);
            try
            {
                Customer account = new Customer(555, name, password, email, address, phoneNumber, age, gender);
                foreach (Customer acc in GetAllCustomers())
                {
                    if (account.Address == acc.Address & account.Name == acc.Name & account.Email == acc.Email & account.PhoneNumber == acc.PhoneNumber)
                        return false;
                }
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"insert into [dbo].[Customer](name, password, email, address, phone_number, salt, age, gender)values(@Name,@PasswordHash,@Email,@Address,@PhoneNumber, @Salt, @Age, @Gender)";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        
                        try
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            cmd.Parameters.AddWithValue("@Salt", salt);
                            cmd.Parameters.AddWithValue("@Age", age);
                            cmd.Parameters.AddWithValue("@Gender", (int)gender);

                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        catch (SqlException e)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool AddAdminAccount(string name, string password, string email, string address, string phoneNumber)
        {
            string salt = PasswordHasing.GetSalt();
            string passwordHash = PasswordHasing.GetHash(password, salt);
            try
            {
                Admin account = new Admin(0, name, password, email, address, phoneNumber);
                foreach (Admin acc in GetAllAdmins())
                {
                    if (account.Address == acc.Address & account.Name == acc.Name & account.Email == acc.Email & account.PhoneNumber == acc.PhoneNumber)
                        return false;
                }

                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"insert into [dbo].[Admin](name, password, email, address, phone_number, salt)values(@Name,@PasswordHash,@Email,@Address,@PhoneNumber, @Salt)";
                    using (cmd = new SqlCommand(query, conn))
                    {

                        try
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            cmd.Parameters.AddWithValue("@Salt", salt);

                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        catch (SqlException e)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool DeleteCustomer(int? ID)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    string query = $"delete from [dbo].[Customer] where personID = '{ID}'";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                            return true;
                    }
                }
                return false;
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool DeleteAdmin(int ID)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    string query = $"delete from [dbo].[Admin] where personID = '{ID}'";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                            return true;
                    }
                    return false;
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool UpdateAdmin(string name, string password, string email, string address, string phoneNumber, int ID)
        {
            string salt = PasswordHasing.GetSalt();
            string passwordHash = PasswordHasing.GetHash(password, salt);
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"UPDATE [dbo].[Admin] set name=@Name, password=@PasswordHash, email=@Email, address=@Address, phone_number=@PhoneNumber, salt=@Salt WHERE personID=@ID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            cmd.Parameters.AddWithValue("@Salt", salt);
                            cmd.Parameters.AddWithValue("@ID", ID);

                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        catch (SqlException e)
                        {
                            return false;
                        }

                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool UpdateCustomer(string name, string password, string email, string address, string phoneNumber, int? ID, int age, Gender gender)
        {
            string salt = PasswordHasing.GetSalt();
            string passwordHash = PasswordHasing.GetHash(password, salt);
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"UPDATE [dbo].[Customer] set name=@Name, password=@PasswordHash, email=@Email, address=@Address, phone_number=@PhoneNumber, salt=@Salt, age=@Age, gender=@Gender WHERE personID=@ID";

                    SqlTransaction transaction = conn.BeginTransaction();

                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            cmd.Parameters.AddWithValue("@Salt", salt);
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Age", age);
                            cmd.Parameters.AddWithValue("@Gender", (int)gender);

                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                        catch (SqlException e)
                        {
                            return false;
                        }

                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool SetOrderID(int? ID, int orderID)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"UPDATE [dbo].[Customer] set orderID=@orderID WHERE personID=@ID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@orderID", orderID);
                            cmd.Parameters.AddWithValue("@ID", ID);

                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        catch (SqlException e)
                        {
                            return false;
                        }

                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int GetOrderID(int? ID)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select orderID from Customer where personID = @ID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@ID", ID);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
								if (reader.Read())
								{
									if (!reader.IsDBNull(reader.GetOrdinal("orderID"))) // Check if the column value is not null
									{
										int orderID = reader.GetInt32(reader.GetOrdinal("orderID")); // Assuming orderID is an integer column
										reader.Close();
										return orderID;
									}
								}
							}
                        }
                        catch (SqlException e)
                        {
                            return -1;
                        }

                    }
                }
                return -1;
            }
            catch (SqlNullValueException ex)
            {
                throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool EndRental(int? ID)
        {
			try
			{
				conn = dal.GetConnection();
				using (conn)
				{
					query = $"UPDATE [dbo].[Customer] set orderID = @OrderID WHERE personID=@ID";

					SqlTransaction transaction = conn.BeginTransaction();

					using (cmd = new SqlCommand(query, conn, transaction))
					{
						try
						{
							cmd.Parameters.AddWithValue("@ID", ID);
							cmd.Parameters.AddWithValue("@OrderID", -1);

							if (cmd.ExecuteNonQuery() == 1)
							{
								transaction.Commit();
								return true;
							}
							else
							{
								transaction.Rollback();
								return false;
							}
						}
						catch (SqlException e)
						{
							return false;
						}

					}
				}
			}
			catch (SqlNullValueException ex)
			{
				throw new SqlNullValueException("Error, reading null values. :" + ex.ToString());
			}
			catch (InvalidOperationException ex)
			{
				throw new InvalidOperationException("An operation is attempted that is not valid for the current state of the database connection. :" + ex.ToString());
			}
			catch (TimeoutException ex)
			{
				throw new TimeoutException("Database operation takes too long to complete, and the timeout period is exceeded.  " + ex.ToString());
			}
			catch (SqlException ex)
			{
				throw new Exception("An error occured in the SQL Server database. : " + ex.ToString());
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}


    }
}
