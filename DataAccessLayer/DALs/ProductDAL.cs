using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace DataAccessLayer.DALs
{
    public class ProductDAL : IProductDAL
    {
        private DataAccessLayer dal = new DataAccessLayer();
        private string query;
        private SqlCommand cmd;
        private SqlConnection conn;

        public List<Necklace> GetNecklacesStock()
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    List<Necklace> necklaces = new List<Necklace>();

                    query = "select * from Product inner join Necklace on Product.productID = Necklace.productID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if ((reader.GetInt32(4) == 0) && (reader.GetInt32(1) >= 1))
                                    necklaces.Add(new Necklace(reader.GetInt32(0), Material.GOLD, reader.GetInt32(2), "Necklace", reader.GetInt32(1)));
                                else if ((reader.GetInt32(4) == 1) && (reader.GetInt32(1) >= 1))
                                    necklaces.Add(new Necklace(reader.GetInt32(0), Material.SILVER, reader.GetInt32(2), "Necklace", reader.GetInt32(1)));
                            }
                        }
                    }
                    return necklaces;
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

        public List<Bracelet> GetBraceletsStock()
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    List<Bracelet> bracelets = new List<Bracelet>();

                    query = "select * from Product inner join Bracelet on Product.productID = Bracelet.productID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if ((reader.GetInt32(4) == 0) && (reader.GetInt32(1) >= 1))
                                    bracelets.Add(new Bracelet(reader.GetInt32(0), Material.GOLD, reader.GetInt32(2), "Bracelet", reader.GetInt32(1)));
                                else if ((reader.GetInt32(4) == 1) && (reader.GetInt32(1) >= 1))
                                    bracelets.Add(new Bracelet(reader.GetInt32(0), Material.SILVER, reader.GetInt32(2), "Bracelet", reader.GetInt32(1)));
                            }
                        }
                    }
                    return bracelets;
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

        public List<Earring> GetEarringsStock()
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    List<Earring> earrings = new List<Earring>();

                    query = "select * from Product inner join Earrings on Product.productID = Earrings.productID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if ((reader.GetInt32(4) == 0) && (reader.GetInt32(1) >= 1))
                                    earrings.Add(new Earring(reader.GetInt32(0), Material.GOLD, reader.GetInt32(2), "Earrings", reader.GetInt32(1)));
                                else if ((reader.GetInt32(4) == 1) && (reader.GetInt32(1) >= 1))
                                    earrings.Add(new Earring(reader.GetInt32(0), Material.SILVER, reader.GetInt32(2), "Earrings", reader.GetInt32(1)));
                            }
                        }
                    }
                    return earrings;
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

        public List<Dress> GetDressesStock()
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    List<Dress> dresses = new List<Dress>();

                    query = "select * from Product inner join Dress on Product.productID = Dress.productID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(1) >= 1)
                                {
                                    if (reader.GetInt32(6) == 0)
                                        dresses.Add(new Dress(reader.GetInt32(0), DressColors.RED, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "red dress", reader.GetInt32(1), reader.GetInt32(2)));
                                    else if (reader.GetInt32(6) == 1)
                                        dresses.Add(new Dress(reader.GetInt32(0), DressColors.BLUE, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "blue dress", reader.GetInt32(1), reader.GetInt32(2)));
                                    else if (reader.GetInt32(6) == 2)
                                        dresses.Add(new Dress(reader.GetInt32(0), DressColors.BLACK, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "black dress", reader.GetInt32(1), reader.GetInt32(2)));
                                }
                            }
                        }
                    }
                    return dresses;
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

        public List<Suit> GetSuitsStock()
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    List<Suit> suits = new List<Suit>();

                    query = "select * from Product inner join Suit on Product.productID = Suit.productID";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(1) >= 1)
                                {
                                    if (reader.GetInt32(6) == 0)
                                        suits.Add(new Suit(reader.GetInt32(0), SuitColors.BLACK, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "black suit", reader.GetInt32(1), reader.GetInt32(2)));
                                    else if (reader.GetInt32(6) == 1)
                                        suits.Add(new Suit(reader.GetInt32(0), SuitColors.NAVY, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "navy suit", reader.GetInt32(1), reader.GetInt32(2)));
                                    else if (reader.GetInt32(6) == 2)
                                        suits.Add(new Suit(reader.GetInt32(0), SuitColors.BROWN, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "brown suit", reader.GetInt32(1), reader.GetInt32(2)));
                                }
                            }
                        }
                    }
                    return suits;
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

        public List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            allProducts.AddRange(GetDressesStock());
            allProducts.AddRange(GetSuitsStock());
            allProducts.AddRange(GetBraceletsStock());
            allProducts.AddRange(GetNecklacesStock());
            allProducts.AddRange(GetEarringsStock());

            //List<Product> productsWithQuantityLessThanOne = allProducts.Where(product => product.Quantity < 1).ToList();

            allProducts = allProducts.Where(product => product.Quantity > 0).ToList();
            
            /*foreach (Product product in productsWithQuantityLessThanOne)
            {
                DeleteProductByID(product.GetID());
            }*/

            return allProducts;
        }

        public Product GetProductByID(int id)
        {
            if (GetDressByID(id) != null)
            {
                return GetDressByID(id);
            }
            else if (GetSuitByID(id) != null)
            {
                return GetSuitByID(id);
            }
            else if (GetEarringByID(id) != null)
            {
                return GetEarringByID(id);
            }
            else if (GetBraceletByID(id) != null)
            {
                return GetBraceletByID(id);
            }
            else if (GetNecklaceByID(id) != null)
            {
                return GetNecklaceByID(id);
            }
            else return null;
        }

        public bool DeleteProductByID(int id)
        {
            if (GetDressByID(id) != null) 
            {
                return DeleteDressFromDatabase(id);
            }
            else if (GetSuitByID(id) != null)
            {
                return DeleteSuitFromDatabase(id);
            }
            else if (GetEarringByID(id) != null)
            {
                return DeleteEarringFromDatabase(id);
            }
            else if (GetBraceletByID(id) != null)
            {
                return DeleteBraceletFromDatabase(id);
            }
            else if (GetNecklaceByID(id) != null)
            {
                return DeleteNecklaceFromDatabase(id);
            }
            return false;
        }

        public void UpdateProductInDatabase(Product product, int id)
        {
            if (GetDressByID(id) != null)
            {
                UpdateDressInDatabase((Dress)product, id);
            }
            else if (GetSuitByID(id) != null)
            {
                UpdateSuitInDatabase((Suit)product, id);
            }
            else if (GetEarringByID(id) != null)
            {
                UpdateEarringsInDatabase((Earring)product, id);
            }
            else if (GetBraceletByID(id) != null)
            {
                UpdateBraceletInDatabase((Bracelet)product, id);
            }
            else if (GetNecklaceByID(id) != null)
            {
                UpdateNecklaceInDatabase((Necklace)product, id);
            }
        }

        public bool AddDressToDatabase(Dress dress)
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    if (dress.GetColor() == DressColors.RED)
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Dress(productID, sizeB, sizeW, sizeH, color) VALUES(@productID, @SizeB, @SizeW, @SizeH, '0')";
                    else if (dress.GetColor() == DressColors.BLUE)
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Dress(productID, sizeB, sizeW, sizeH, color) VALUES(@productID, @SizeB, @SizeW, @SizeH, '1')";
                    else query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Dress(productID, sizeB, sizeW, sizeH, color) VALUES(@productID, @SizeB, @SizeW, @SizeH, '2')";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", dress.Quantity);
                        cmd.Parameters.AddWithValue("@Price", dress.GetPrice());
                        cmd.Parameters.AddWithValue("@SizeB", dress.GetSizeB());
                        cmd.Parameters.AddWithValue("@SizeW", dress.GetSizeW());
                        cmd.Parameters.AddWithValue("@SizeH", dress.GetSizeH());


                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else return false;
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

        public bool AddSuitToDatabase(Suit suit)
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    if (suit.GetColor() == SuitColors.BLACK)
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Suit(productID, sizeB, sizeW, sizeH, color) VALUES(@productID, @SizeB, @SizeW, @SizeH, '0')";
                    else if (suit.GetColor() == SuitColors.NAVY)
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Suit(productID, sizeB, sizeW, sizeH, color) VALUES(@productID, @SizeB, @SizeW, @SizeH, '1')";
                    else 
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Suit(productID, sizeB, sizeW, sizeH, color) VALUES(@productID, @SizeB, @SizeW, @SizeH, '2')";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", suit.Quantity);
                        cmd.Parameters.AddWithValue("@Price", suit.GetPrice());
                        cmd.Parameters.AddWithValue("@SizeB", suit.GetSizeB());
                        cmd.Parameters.AddWithValue("@SizeW", suit.GetSizeW());
                        cmd.Parameters.AddWithValue("@SizeH", suit.GetSizeH());

                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else return false;
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

        public bool AddNecklaceToDatabase(Necklace necklace)
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    if (necklace.GetMaterial() == Material.GOLD)
                    {
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Necklace(productID, material) VALUES(@productID, '0')";
                    }
                    else
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Necklace(productID, material) VALUES(@productID, '1')";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", necklace.Quantity);
                        cmd.Parameters.AddWithValue("@Price", necklace.GetPrice());

                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else return false;
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

        public bool AddBraceletToDatabase(Bracelet bracelet)
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    if (bracelet.GetMaterial() == Material.GOLD)
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Bracelet(productID, material) VALUES(@productID, '0')\r\n";
                    else
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Bracelet(productID, material) VALUES(@productID, '1')";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", bracelet.Quantity);
                        cmd.Parameters.AddWithValue("@Price", bracelet.GetPrice());

                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else return false;
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

        public bool AddEarringsToDatabase(Earring earring)
        {

            try
            {
                conn = dal.GetConnection(); ;
                using (conn)
                {
                    if (earring.GetMaterial() == Material.GOLD)
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Earrings(productID, material) VALUES(@productID, '0')\r\n";
                    else
                        query = $"DECLARE @productID INT; INSERT INTO Product(quantity, price) VALUES(@Quantity, @Price); SET @productID = SCOPE_IDENTITY(); INSERT INTO Earrings(productID, material) VALUES(@productID, '1')";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", earring.Quantity);
                        cmd.Parameters.AddWithValue("@Price", earring.GetPrice());

                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else return false;
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

        /*public Dress? GetDressFromDatabase(int sizeB, int sizeW, int sizeH, DressColors color)
        {
            
            conn = dal.GetConnection();;
            using (conn)
            {
                if (color == DressColors.RED)
                query = $"select * from Dress as d join Product as p on d.productID = p.productID where sizeB = '{sizeB}' and sizeW = '{sizeW}' and sizeH = '{sizeH}' and color = '0'";
                else if (color == DressColors.BLUE)
                    query = $"select * from Dress as d join Product as p on d.productID = p.productID where sizeB = '{sizeB}' and sizeW = '{sizeW}' and sizeH = '{sizeH}' and color = '1'";
                else
                    query = $"select * from Dress as d join Product as p on d.productID = p.productID where sizeB = '{sizeB}' and sizeW = '{sizeW}' and sizeH = '{sizeH}' and color = '2'";
                using (cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader.GetInt32(3) == 0)
                                return new Dress(DressColors.RED, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), "RED dress", reader.GetInt32(6), reader.GetInt32(7));
                            else if (reader.GetInt32(3) == 1)
                                return new Dress(DressColors.BLUE, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), "BLUE dress", reader.GetInt32(6), reader.GetInt32(7));
                            else
                                return new Dress(DressColors.BLACK, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), "BLACK dress", reader.GetInt32(6), reader.GetInt32(7));
                        }

                    }
                }
                return null;
            }
        }*/

        public bool DeleteDressFromDatabase(int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    string query = $"delete from Dress where productID = '{productID}'";
                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"delete from Product where productID = '{productID}'";
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

        public bool DeleteSuitFromDatabase(int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    string query = $"delete from Suit where productID = '{productID}'";
                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"delete from Product where productID = '{productID}'";
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

        public bool DeleteBraceletFromDatabase(int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    string query = $"delete from Bracelet where productID = '{productID}'";
                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"delete from Product where productID = '{productID}'";
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

        public bool DeleteNecklaceFromDatabase(int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    string query = $"delete from Necklace where productID = '{productID}'";
                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"delete from Product where productID = '{productID}'";
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

        public bool DeleteEarringFromDatabase(int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    string query = $"delete from Earrings where productID = '{productID}'";
                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"delete from Product where productID = '{productID}'";
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

        public int GetDressID(Dress dress)
        {

            try
            {
                int productID = -1;
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"SELECT * from Dress where sizeB = '{dress.GetSizeB()}' and sizeW = '{dress.GetSizeW()}' and sizeH = '{dress.GetSizeH()}' and color = '{(int)dress.GetColor()}'";

                    using (cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            productID = reader.GetInt32(4);
                        }
                        reader.Close();
                    }
                }
                return productID;
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

        public int GetSuitID(Suit suit)
        {

            try
            {
                int productID = -1;
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"SELECT * from Suit where sizeB = '{suit.GetSizeB()}' and sizeW = '{suit.GetSizeW()}' and sizeH = '{suit.GetSizeH()}' and color = '{(int)suit.GetColor()}'";

                    using (cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            productID = reader.GetInt32(4);
                        }
                        reader.Close();
                    }
                }
                return productID;
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

        public int GetBraceletID(Bracelet bracelet)
        {

            try
            {
                int productID = -1;
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"SELECT * from Bracelet where material = '{(int)bracelet.GetMaterial()}'";

                    using (cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            productID = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }
                return productID;
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

        public int GetNecklaceID(Necklace necklace)
        {

            try
            {
                int productID = -1;
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"SELECT * from Necklace where material = '{(int)necklace.GetMaterial()}'";

                    using (cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            productID = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }
                return productID;
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

        public int GetEarringsID(Earring earring)
        {

            try
            {
                int productID = -1;
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"SELECT * from Earrings where material = '{(int)earring.GetMaterial()}'";

                    using (cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            productID = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }
                return productID;
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

        public bool UpdateDressInDatabase(Dress dress, int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    query = $"UPDATE Dress set sizeB = '{dress.GetSizeB()}', sizeW = '{dress.GetSizeW()}', sizeH = '{dress.GetSizeH()}', color = '{(int)dress.GetColor()}' where productID = '{productID}'";

                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"UPDATE Product set quantity = '{dress.Quantity}', price = '{dress.GetPrice()}' where productID = '{productID}'";

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

        public bool UpdateSuitInDatabase(Suit suit, int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    query = $"UPDATE Suit set sizeB = '{suit.GetSizeB()}', sizeW = '{suit.GetSizeW()}', sizeH = '{suit.GetSizeH()}', color = '{(int)suit.GetColor()}' where productID = '{productID}'";

                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"UPDATE Product set quantity = '{suit.Quantity}', price = '{suit.GetPrice()}' where productID = '{productID}'";

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

        public bool UpdateBraceletInDatabase(Bracelet bracelet, int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    query = $"UPDATE Bracelet set material = '{(int)bracelet.GetMaterial()}' where productID = '{productID}'";

                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"UPDATE Product set quantity = '{bracelet.Quantity}', price = '{bracelet.GetPrice()}' where productID = '{productID}'";

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

        public bool UpdateNecklaceInDatabase(Necklace necklace, int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    query = $"UPDATE Necklace set material = '{(int)necklace.GetMaterial()}' where productID = '{productID}'";

                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"UPDATE Product set quantity = '{necklace.Quantity}', price = '{necklace.GetPrice()}' where productID = '{productID}'";

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

        public bool UpdateEarringsInDatabase(Earring earring, int productID)
        {

            try
            {
                conn = dal.GetConnection();
                SqlTransaction transaction = conn.BeginTransaction();
                using (conn)
                {
                    query = $"UPDATE Earrings set material = '{(int)earring.GetMaterial()}' where productID = '{productID}'";

                    using (cmd = new SqlCommand(query, conn, transaction))
                    {
                        if (cmd.ExecuteNonQuery() != 1)
                            return false;
                    }

                    query = $"UPDATE Product set quantity = '{earring.Quantity}', price = '{earring.GetPrice()}' where productID = '{productID}'";

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

        public Dress? GetDressByID(int id)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select * from Product as p join Dress as d on d.productID = p.productID where d.productID = '{id}'";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(6) == 0)
                                    return new Dress(reader.GetInt32(0), DressColors.RED, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "RED dress", reader.GetInt32(1), reader.GetInt32(2));
                                else if (reader.GetInt32(6) == 1)
                                    return new Dress(reader.GetInt32(0), DressColors.BLUE, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "BLUE dress", reader.GetInt32(1), reader.GetInt32(2));
                                else if (reader.GetInt32(6) == 2)
                                    return new Dress(reader.GetInt32(0), DressColors.BLACK, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "BLACK dress", reader.GetInt32(1), reader.GetInt32(2));
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

        public Suit? GetSuitByID(int id)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select * from Product as p join Suit as s on p.productID = s.productID where p.productID = '{id}'";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(6) == 0)
                                    return new Suit(reader.GetInt32(0), SuitColors.BLACK, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "BLACK suit", reader.GetInt32(1), reader.GetInt32(2));
                                else if (reader.GetInt32(6) == 1)
                                    return new Suit(reader.GetInt32(0), SuitColors.NAVY, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "NAVY suit", reader.GetInt32(1), reader.GetInt32(2));
                                else if (reader.GetInt32(6) == 2)
                                    return new Suit(reader.GetInt32(0), SuitColors.BROWN, reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), "BROWN suit", reader.GetInt32(1), reader.GetInt32(2));
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

        public Necklace? GetNecklaceByID(int id)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select * from Product as p inner join Necklace as n on p.productID = n.productID where p.productID = '{id}'";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(4) == 0)
                                    return new Necklace(reader.GetInt32(0), Material.GOLD, reader.GetInt32(2), "Necklace", reader.GetInt32(1));
                                else if (reader.GetInt32(4) == 1)
                                    return new Necklace(reader.GetInt32(0), Material.SILVER, reader.GetInt32(2), "Necklace", reader.GetInt32(1));
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

        public Bracelet? GetBraceletByID(int id)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select * from Product as p inner join Bracelet as b on p.productID = b.productID where p.productID = '{id}' \r\n";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(4) == 0)
                                    return new Bracelet(reader.GetInt32(0), Material.GOLD, reader.GetInt32(2), "Bracelet", reader.GetInt32(1));
                                else if (reader.GetInt32(4) == 1)
                                    return new Bracelet(reader.GetInt32(0), Material.SILVER, reader.GetInt32(2), "Bracelet", reader.GetInt32(1));
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

        public Earring? GetEarringByID(int id)
        {

            try
            {
                conn = dal.GetConnection();
                using (conn)
                {
                    query = $"select * from Product as p inner join Earrings as b on p.productID = b.productID where p.productID = '{id}' \r\n";
                    using (cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(4) == 0)
                                    return new Earring(reader.GetInt32(0), Material.GOLD, reader.GetInt32(2), "Earrings", reader.GetInt32(1));
                                else if (reader.GetInt32(4) == 1)
                                    return new Earring(reader.GetInt32(0), Material.SILVER, reader.GetInt32(2), "Earrings", reader.GetInt32(1));
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
    }
}
