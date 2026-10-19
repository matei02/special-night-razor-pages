using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using System.Data.SqlClient;

namespace LogicLayer
{
    public class ProductManager
    {
        IProductDAL IProductDAL;

        public ProductManager(IProductDAL iProductDAL)
        {
            IProductDAL = iProductDAL;
        }

        public bool DeleteProductByID(int id)
        {
            return IProductDAL.DeleteProductByID(id);
        }

        public List<Necklace> GetNecklacesStock()
        {
            return IProductDAL.GetNecklacesStock();
        }

        public List<Bracelet> GetBraceletsStock()
        {
            return IProductDAL.GetBraceletsStock();
        }

        public List<Earring> GetEarringsStock()
        {
            return IProductDAL.GetEarringsStock();
        }

        public List<Dress> GetDressesStock()
        {
            return IProductDAL.GetDressesStock();
        }

        public List<Suit> GetSuitsStock()
        {
            return IProductDAL.GetSuitsStock();
        }

        public List<Product> GetAllProductsFromDatabase()
        {
            return IProductDAL.GetAllProducts();
        }

        public bool AddDressToDatabase(Dress dress)
        {
            return IProductDAL.AddDressToDatabase(dress);
        }

        public bool AddSuitToDatabase(Suit suit)
        {
            return IProductDAL.AddSuitToDatabase(suit);
        }

        public bool AddNecklaceToDatabase(Necklace necklace)
        {
            return IProductDAL.AddNecklaceToDatabase(necklace);
        }

        public bool AddBraceletToDatabase(Bracelet bracelet)
        {
            return IProductDAL.AddBraceletToDatabase(bracelet);
        }

        public bool AddEarringsToDatabase(Earring earrings)
        {
            return IProductDAL.AddEarringsToDatabase(earrings);
        }


        public bool RemoveDressFromDatabase(int productID)
        {
            try
            {
                return IProductDAL.DeleteDressFromDatabase(productID);
            }
            catch (Exception ex)
            {
                Dress product = GetDressByID(productID);
                product.Quantity = 0;
                try
                {
                    return IProductDAL.UpdateDressInDatabase(product, productID);
                }
                catch (SqlException innerEx)
                {
                    throw new Exception("An error occurred in the SQL Server database while updating the necklace: " + innerEx.ToString(), innerEx);
                }
            }
        }

        public bool RemoveSuitFromDatabase(int productID)
        {
            try
            {
                return IProductDAL.DeleteSuitFromDatabase(productID);
            }
            catch (Exception ex)
            {
                Suit product = GetSuitByID(productID);
                product.Quantity = 0;
                try
                {
                    return IProductDAL.UpdateSuitInDatabase(product, productID);
                }
                catch (SqlException innerEx)
                {
                    throw new Exception("An error occurred in the SQL Server database while updating the necklace: " + innerEx.ToString(), innerEx);
                }
            }
        }

        public bool RemoveNecklaceFromDatabase(int productID)
        {
            try
            {
                return IProductDAL.DeleteNecklaceFromDatabase(productID);
            }
            catch (Exception ex)
            {
                Necklace product = GetNecklaceByID(productID);
                product.Quantity = 0;
                try
                {
                    return IProductDAL.UpdateNecklaceInDatabase(product, productID);
                }
                catch (SqlException innerEx)
                {
                    throw new Exception("An error occurred in the SQL Server database while updating the necklace: " + innerEx.ToString(), innerEx);
                }
            }
        }

        public bool RemoveBraceletFromDatabase(int productID)
        {
            try
            {
                return IProductDAL.DeleteBraceletFromDatabase(productID);
            }
            catch (Exception ex)
            {
                Bracelet product = GetBraceletByID(productID);
                product.Quantity = 0;
                try
                {
                    return IProductDAL.UpdateBraceletInDatabase(product, productID);
                }
                catch (SqlException innerEx)
                {
                    throw new Exception("An error occurred in the SQL Server database while updating the necklace: " + innerEx.ToString(), innerEx);
                }
            }
        }

        public bool RemoveEarringFromDatabase(int productID)
        {
            try
            {
                return IProductDAL.DeleteEarringFromDatabase(productID);
            }
            catch (Exception ex)
            {
                Earring product = GetEarringByID(productID);
                product.Quantity = 0;
                try
                {
                    return IProductDAL.UpdateEarringsInDatabase(product, productID);
                }
                catch (SqlException innerEx)
                {
                    throw new Exception("An error occurred in the SQL Server database while updating the necklace: " + innerEx.ToString(), innerEx);
                }
            }
        }

        public int GetDressID(Dress dress)
        {
            return IProductDAL.GetDressID(dress);
        }

        public int GetSuitID(Suit suit)
        {
            return IProductDAL.GetSuitID(suit);
        }

        public int GetBraceletID(Bracelet bracelet)
        {
            return IProductDAL.GetBraceletID(bracelet);
        }
        
        public int GetNecklaceID(Necklace necklace)
        {
            return IProductDAL.GetNecklaceID(necklace);
        }

        public int GetEarringsID(Earring earring)
        {
            return IProductDAL.GetEarringsID(earring);
        }

        public bool UpdateDressInDatabase(Dress dress, int ID)
        {
            return IProductDAL.UpdateDressInDatabase(dress, ID);
        }

        public bool UpdateSuitInDatabase(Suit suit, int ID)
        {
            return IProductDAL.UpdateSuitInDatabase(suit, ID);
        }

        public bool UpdateBraceletInDatabase(Bracelet bracelet, int ID)
        {
            return IProductDAL.UpdateBraceletInDatabase(bracelet, ID);
        }

        public bool UpdateNecklaceInDatabase(Necklace necklace, int ID)
        {
            return IProductDAL.UpdateNecklaceInDatabase(necklace, ID);
        }

        public bool UpdateEarringsInDatabase(Earring earring, int ID)
        {
            return IProductDAL.UpdateEarringsInDatabase(earring, ID);
        }

        public Dress? GetDressByID(int id)
        {
            return IProductDAL.GetDressByID(id);
        }

        public Suit? GetSuitByID(int id)
        {
            return IProductDAL.GetSuitByID(id);
        }
         
        public Necklace? GetNecklaceByID(int id)
        {
            return IProductDAL.GetNecklaceByID(id);
        }
         
        public Bracelet? GetBraceletByID(int id)
        {
            return IProductDAL.GetBraceletByID(id);
        }
         
        public Earring? GetEarringByID(int id)
        {
            return IProductDAL.GetEarringByID(id);
        }

        public Product GetProductByID(int id)
        {
            return IProductDAL.GetProductByID(id);
        }

    }
}
