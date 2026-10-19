using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.DALs
{
    public class OrderDAL : IOrderDAL
    {
        private DataAccessLayer dal = new DataAccessLayer();
        private ProductDAL productDAL = new ProductDAL();
        private ShoppingCartDAL shoppingCartDAL = new ShoppingCartDAL();
        private string query;
        private SqlCommand cmd;
        private SqlConnection conn;
        private int orderID;
        private int personID;

        public int? CreateOrder(int personID)
        {

            try
            {
                List<Product> products = shoppingCartDAL.GetAllShoppingCartProducts(personID);
                conn = dal.GetConnection();
                using (conn)
                {
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        int orderId = 0;
                        // Insert into Orders table
                        using (SqlCommand command = conn.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "INSERT INTO Orders (total_price, personID, status) VALUES (@TotalPrice, @PersonID, @Status); SELECT SCOPE_IDENTITY();";

                            command.Parameters.AddWithValue("@TotalPrice", shoppingCartDAL.GetTotal(personID));
                            command.Parameters.AddWithValue("@PersonID", personID);
                            command.Parameters.AddWithValue("@Status", 0);

                            orderId = Convert.ToInt32(command.ExecuteScalar());

                            foreach (Product product in products)
                            {
                                // Insert into OrderLine table
                                using (SqlCommand orderLineCommand = conn.CreateCommand())
                                {
                                    orderLineCommand.Transaction = transaction;
                                    orderLineCommand.CommandText = "INSERT INTO OrderLine (orderID, productID, quantity, price) VALUES (@OrderID, @ProductID, @Quantity, @Price);";

                                    orderLineCommand.Parameters.AddWithValue("@OrderID", orderId);
                                    orderLineCommand.Parameters.AddWithValue("@ProductID", product.GetID());
                                    orderLineCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
                                    orderLineCommand.Parameters.AddWithValue("@Price", product.GetPrice());

                                    orderLineCommand.ExecuteNonQuery();

                                    Product actual_product = productDAL.GetProductByID(product.GetID());
                                    actual_product.Quantity = actual_product.Quantity - product.Quantity;
                                    productDAL.UpdateProductInDatabase(actual_product, actual_product.GetID());
                                }
                            }
                        }
                        //productDAL.(product.GetID());  
                        transaction.Commit();
                        return orderId;
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

        /*public bool DeliverOrder(int personID)
        {
            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"insert into Orders(total_price, personID, status) values('0', '@personID', '0')";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@personID", personID);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            orderID = (int)cmd.ExecuteScalar();
                            this.personID = personID;
                            return true;
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
        }*/

        /*public bool AddToOrder(Product product)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"insert into OrderProducts()";
                    using (cmd = new SqlCommand(query, conn))
                    {

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
        } //NOT FINISHED

        public bool RemoveFromOrder(Product product)
        {
            try
            {
                conn = dal.GetConnection();
                return true;
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
        }*/ //NOT FINISHED

        public List<Order> GetAllOrders()
        {
            try
            {

                conn = dal.GetConnection();
                using (conn)
                {
                    List<Order> allorders = new List<Order>();

                    query = "select * from Orders as o join OrderLine as ol on o.orderID = ol.orderID join Product as p on p.productID = ol.productID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Order crt_order = new Order(0);
                            while (reader.Read())
                            {
                                if (crt_order.GetOrderID() != 0)
                                {
                                    if (crt_order.GetOrderID() != reader.GetInt32("orderID"))
                                    {
                                        allorders.Add(crt_order);
                                        crt_order = new Order(0);
                                    }
                                }
                                crt_order.SetOrderID(reader.GetInt32("orderID"));
                                crt_order.SetStatus(reader.GetInt32("status"));
                                crt_order.SetCustomerID(reader.GetInt32("personID"));
                                if (productDAL.GetDressByID(reader.GetInt32("productID")) != null)
                                {
                                    Dress dress = productDAL.GetDressByID(reader.GetInt32("productID"));
                                    dress.Quantity = reader.GetInt32(6);
                                    dress.SetPrice(reader.GetInt32(7));
                                    crt_order.AddToOrder(dress);
                                }
                                else if (productDAL.GetSuitByID(reader.GetInt32("productID")) != null)
                                {
                                    Suit suit = productDAL.GetSuitByID(reader.GetInt32("productID"));
									suit.Quantity = reader.GetInt32(6);
									suit.SetPrice(reader.GetInt32(7));
									crt_order.AddToOrder(suit);
                                }
                                else if (productDAL.GetBraceletByID(reader.GetInt32("productID")) != null)
                                {
                                    Bracelet bracelet = productDAL.GetBraceletByID(reader.GetInt32("productID"));
									bracelet.Quantity = reader.GetInt32(6);
									bracelet.SetPrice(reader.GetInt32(7));
									crt_order.AddToOrder(bracelet);
                                }
                                else if (productDAL.GetNecklaceByID(reader.GetInt32("productID")) != null)
                                {
                                    Necklace necklace = productDAL.GetNecklaceByID(reader.GetInt32("productID"));
									necklace.Quantity = reader.GetInt32(6);
									necklace.SetPrice(reader.GetInt32(7));
									crt_order.AddToOrder(necklace);
                                }
                                else if (productDAL.GetEarringByID(reader.GetInt32("productID")) != null)
                                {
                                    Earring earring = productDAL.GetEarringByID(reader.GetInt32("productID"));
									earring.Quantity = reader.GetInt32(6);
									earring.SetPrice(reader.GetInt32(7));
									crt_order.AddToOrder(earring);

                                    /*if (ProductDAL.GetDressByID(reader.GetInt32("productID")) != null)
                                    {
                                        allorders.Add(new Dress());
                                    }
                                    else if (ProductDAL.GetSuitByID(reader.GetInt32("productID")) != null)
                                    {
                                        allorders.Add(new Suit());
                                    }
                                    else if (ProductDAL.GetBraceletByID(reader.GetInt32("productID")) != null)
                                    {
                                        allorders.Add(new Bracelet());
                                    }
                                    else if (ProductDAL.GetNecklaceByID(reader.GetInt32("productID")) != null)
                                    {
                                        allorders.Add(new Necklace());
                                    }
                                    else if (ProductDAL.GetEarringByID(reader.GetInt32("productID")) != null)
                                    {
                                        allorders.Add(new Earring());
                                    }*/
                                }
                            }
                            if (crt_order.GetOrderID() != 0)
                            {
                                allorders.Add(crt_order);
                            }

                        }
                        return allorders;
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

        public Order GetOrderByID(int id)
        {
            foreach (Order ord in GetAllOrders())
            {
                if (ord.GetOrderID() == id)
                {
                    return ord;
                }
            }
            return null;
        }

        public bool DeleteOrder(Order order)
        {
            conn = dal.GetConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            using (conn)
            {
                query = $"delete from OrderLine where orderID = @OrderID";
                using (cmd = new SqlCommand(query, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@OrderID", order.GetOrderID());

                    if (cmd.ExecuteNonQuery() < 0)
                        return false;
                }

                query = $"delete from Orders where orderID = @OrderID";
                using (cmd = new SqlCommand(query, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@OrderID", order.GetOrderID());

                    if (cmd.ExecuteNonQuery() < 0)
                        return false;
                }

                transaction.Commit();
                return true;
            }
        }

        public bool SetOrderStatusFinished(Order order)
        {
			try
			{
				conn = dal.GetConnection();
				using (conn)
				{
					query = $"update Orders set status = @status where orderID = @OrderID";
					using (cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@status", 1);
						cmd.Parameters.AddWithValue("@OrderID", order.GetOrderID());
						if (cmd.ExecuteNonQuery() == 1)
						{
							return true;
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

        public List<Order> GetAllOrdersForCustomer(int? id)
        {
            List<Order> orders = new List<Order>();
            try
            {

                conn = dal.GetConnection();
                using (conn)
                {
                    List<Order> allorders = new List<Order>();

                    query = "select * from Orders as o join OrderLine as ol on o.orderID = ol.orderID join Product as p on p.productID = ol.productID where personID = @PersonID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Order crt_order = new Order(0);
                            while (reader.Read())
                            {
                                if (crt_order.GetOrderID() != 0)
                                {
                                    if (crt_order.GetOrderID() != reader.GetInt32("orderID"))
                                    {
                                        allorders.Add(crt_order);
                                        crt_order = new Order(0);
                                    }
                                }
                                crt_order.SetOrderID(reader.GetInt32("orderID"));
                                if (productDAL.GetDressByID(reader.GetInt32("productID")) != null)
                                {
                                    Dress dress = productDAL.GetDressByID(reader.GetInt32("productID"));
                                    crt_order.AddToOrder(dress);
                                }
                                else if (productDAL.GetSuitByID(reader.GetInt32("productID")) != null)
                                {
                                    Suit suit = productDAL.GetSuitByID(reader.GetInt32("productID"));
                                    crt_order.AddToOrder(suit);
                                }
                                else if (productDAL.GetBraceletByID(reader.GetInt32("productID")) != null)
                                {
                                    Bracelet bracelet = productDAL.GetBraceletByID(reader.GetInt32("productID"));
                                    crt_order.AddToOrder(bracelet);
                                }
                                else if (productDAL.GetNecklaceByID(reader.GetInt32("productID")) != null)
                                {
                                    Necklace necklace = productDAL.GetNecklaceByID(reader.GetInt32("productID"));
                                    crt_order.AddToOrder(necklace);
                                }
                                else if (productDAL.GetEarringByID(reader.GetInt32("productID")) != null)
                                {
                                    Earring earring = productDAL.GetEarringByID(reader.GetInt32("productID"));
                                    crt_order.AddToOrder(earring);
                                }
                            }
                            if (crt_order.GetOrderID() != 0)
                            {
                                allorders.Add(crt_order);
                            }

                        }
                        return allorders;
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