using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace DataAccessLayer.DALs
{
    public class ShoppingCartDAL : IShoppingCart
    {
        private DataAccessLayer dal = new DataAccessLayer();
        private string query;
        private SqlCommand cmd;
        private SqlConnection conn;
        private ProductDAL productDAL;

        public bool AddToShoppingCart(int? personID, int productID)
        {
            try
            {
                List<Product> products = GetAllShoppingCartProducts(personID);
                if (products.Count > 0)
                {
                    foreach (Product product in products)
                    {
                        //Verify if product is already in cart, and increment.
                        if (product.GetID() == productID)
                        {
                            conn = dal.GetConnection();
                            SqlTransaction transaction1 = conn.BeginTransaction();
                            using (conn)
                            {
                                query = $"UPDATE ShoppingCart set quantity=quantity+1 where productID = '{productID}' and personID = '{personID}'";
                                using (cmd = new SqlCommand(query, conn, transaction1))
                                {
                                    if (cmd.ExecuteNonQuery() != 1)
                                    {
                                        transaction1.Rollback();
                                        return false;
                                    }
                                    else
                                    {
                                        transaction1.Commit();
                                        return true;
                                    }
                                }
                            }

                        }
                    }
                }

                //Add to cart
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    query = $"INSERT INTO ShoppingCart(personID, productID, quantity) VALUES('{personID}', '{productID}', '1')";
                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }
                    transaction.Commit();
                    return true;
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

        public List<Product> GetAllShoppingCartProducts(int? personID)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    productDAL = new ProductDAL();
                    List<Product> products = new List<Product>();

                    query = $"select * from ShoppingCart where personID = @personID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@personID", personID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (productDAL.GetDressByID(reader.GetInt32("productID")) != null)
                                {
                                    Dress dress = productDAL.GetDressByID(reader.GetInt32("productID"));
                                    dress.Quantity = reader.GetInt32("quantity");
                                    products.Add(dress);

                                }
                                else if (productDAL.GetSuitByID(reader.GetInt32("productID")) != null)
                                {
                                    Suit suit = productDAL.GetSuitByID(reader.GetInt32("productID"));
                                    suit.Quantity = reader.GetInt32("quantity");
                                    products.Add(suit);
                                }
                                else if (productDAL.GetBraceletByID(reader.GetInt32("productID")) != null)
                                {
                                    Bracelet bracelet = productDAL.GetBraceletByID(reader.GetInt32("productID"));
                                    bracelet.Quantity = reader.GetInt32("quantity");
                                    products.Add(bracelet);
                                }
                                else if (productDAL.GetNecklaceByID(reader.GetInt32("productID")) != null)
                                {
                                    Necklace necklace = productDAL.GetNecklaceByID(reader.GetInt32("productID"));
                                    necklace.Quantity = reader.GetInt32("quantity");
                                    products.Add(necklace);
                                }
                                else if (productDAL.GetEarringByID(reader.GetInt32("productID")) != null)
                                {
                                    Earring earring = productDAL.GetEarringByID(reader.GetInt32("productID"));
                                    earring.Quantity = reader.GetInt32("quantity");
                                    products.Add(earring);
                                }
                            }
                        }
                    }
                    return products;
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

        public int GetTotal(int? personID)
        {
            int total = 0;
            List<Product> products = GetAllShoppingCartProducts(personID);
            foreach (Product product in products)
            {
                total += product.GetPrice() * product.Quantity;
            }
            return total;
        }

        public bool RemoveFromShoppingCart(int? personID, int productID)
        {
            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    string query2 = $"delete from ShoppingCart where productID = @ProductID and personID = @PersonID";
                    using (cmd = new SqlCommand(query2, conn, transaction))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@ProductID", productID);
                            cmd.Parameters.AddWithValue("@PersonID", personID);
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                transaction.Commit();
                                return true;
                            }
                        }
                        catch (SqlException e)
                        {
                            transaction.Rollback();
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

        public bool IncreaseQuantityInCart(int? personID, int productID)
        {
            conn = dal.GetConnection();
            SqlTransaction transaction1 = conn.BeginTransaction();
            using (conn)
            {
                query = $"UPDATE ShoppingCart set quantity=quantity+1 where productID = '{productID}' and personID = '{personID}'";
                using (cmd = new SqlCommand(query, conn, transaction1))
                {
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        transaction1.Rollback();
                        return false;
                    }
                    else
                    {
                        transaction1.Commit();
                        return true;
                    }
                }
            }
        }

        public bool DecreaseQuantityInCart(int? personID, int productID)
        {
            conn = dal.GetConnection();
            SqlTransaction transaction1 = conn.BeginTransaction();
            using (conn)
            {
                query = $"UPDATE ShoppingCart set quantity=quantity-1 where productID = '{productID}' and personID = '{personID}'";
                using (cmd = new SqlCommand(query, conn, transaction1))
                {
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        transaction1.Rollback();
                        return false;
                    }
                    else
                    {
                        transaction1.Commit();
                        return true;
                    }
                }
            }
        }

        public bool ClearShoppingCart(int? personID)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM ShoppingCart WHERE personID = @PersonID";

                        cmd.Parameters.AddWithValue("@PersonID", personID);

                        if (cmd.ExecuteNonQuery() >= 1)
                        { return true; }    
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

        public int GetItemQuantity(int ID, int? personID)
        {
            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    string query2 = $"select quantity from ShoppingCart where productID = @ProductID and personID = @PersonID";
                    using (cmd = new SqlCommand(query2, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", ID);
                        cmd.Parameters.AddWithValue("@PersonID", personID);
						using (var reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								int quantity = reader.GetInt32("quantity");
								reader.Close();
								transaction.Commit();
								return quantity;
							}
							else
							{
								reader.Close();
								transaction.Rollback();
								return 0;
							}
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
