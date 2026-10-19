using System.Data.SqlClient;
using System.Data.SqlTypes;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer.DALs
{
    public class ReviewDAL : IReviewDAL
    {
        private DataAccessLayer dal = new DataAccessLayer();
        private AccountDAL accdal = new AccountDAL();
        private SqlCommand cmd;
        private SqlConnection conn;

        public Dictionary<int, List<string>>? GetReviewsFromDatabase()
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    Dictionary<int, List<string>> reviews = new Dictionary<int, List<string>>();


                    Customer? account;

                    string query = "select * from [dbo].[Review]";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                account = accdal.GetCustomerByID(id);
                                if (account != null)
                                    if (reviews.ContainsKey(id))
                                    {
                                        reviews[id].Add(reader.GetString(1));
                                    }
                                    else
                                    {
                                        reviews.Add(id, new List<string>() { reader.GetString(1) });
                                    }
                            }
                        }
                    }
                    return reviews;
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

        public bool AddReviewToDatabase(int? id, string text)
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    string query = $"INSERT into [dbo].[Review](personID,description) VALUES('{id}', '{text}')";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        try
                        {
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

        public bool DeleteReviewFromDatabase(int? id)
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    string query = $"delete from [dbo].Review where personID = {id}";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        try
                        {
                            if (cmd.ExecuteNonQuery() >= 1)
                                return true;
                        }
                        catch (SqlException e)
                        {
                            return false;
                        }
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
    }
}
