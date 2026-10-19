using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using SpecialNightTEST.MockDALs;
using System.Collections.Generic;

namespace DataAccessLayer.DALs
{
    public class FakeShoppingCartDAL : IShoppingCart
    {
        private Dictionary<int, List<Product>> shoppingCart;
        private FakeProductDAL fakeProductDAL;

        public FakeShoppingCartDAL()
        {
            shoppingCart = new Dictionary<int, List<Product>>();
            fakeProductDAL = new FakeProductDAL();

            shoppingCart.Add(1, new List<Product>());
            shoppingCart.Add(2, new List<Product>());
            fakeProductDAL.AddBraceletToDatabase(new Bracelet(1, Material.GOLD, 20, "bracelet", 2));
            fakeProductDAL.AddBraceletToDatabase(new Bracelet(2, Material.GOLD, 20, "bracelet", 2));

        }

        public bool AddToShoppingCart(int? personID, int productID)
        {
            if (personID.HasValue && productID > 0)
            {
                if (shoppingCart.ContainsKey(personID.Value))
                {
                    if (!shoppingCart[personID.Value].Contains(fakeProductDAL.GetProductByID(productID)))
                    {
                        Product product = fakeProductDAL.GetProductByID(productID);
                        product.Quantity = 1;
                        shoppingCart[personID.Value].Add(fakeProductDAL.GetProductByID(productID));
                    }
                }
                else
                {
                    Product product = fakeProductDAL.GetProductByID(productID);
                    product.Quantity = 1;
                    shoppingCart.Add(personID.Value, new List<Product> { product });
                }

                return true;
            }

            return false;
        }

        public List<Product> GetAllShoppingCartProducts(int? personID)
        {
            List<Product> products = new List<Product>();
            foreach (int ID in shoppingCart.Keys) 
            {
                if (personID == ID)
                {
                    foreach (Product p in shoppingCart[ID])
                    {
                        Product product = fakeProductDAL.GetProductByID(p.GetID());
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public int GetTotal(int? personID)
        {
            int total = 0;
            foreach (int ID in shoppingCart.Keys)
            {
                if (personID == ID)
                {
                    foreach (Product p in shoppingCart[ID])
                    {
                        Product product = fakeProductDAL.GetProductByID(p.GetID());
                        total += product.GetPrice();
                    }
                }
            }
            return total;
        }

        public bool RemoveFromShoppingCart(int? personID, int productID)
        {
            if (personID.HasValue && productID > 0)
            {
                if (shoppingCart.ContainsKey(personID.Value))
                {
                    shoppingCart[personID.Value].Remove(fakeProductDAL.GetProductByID(productID));
                    return true;
                }
            }

            return false;
        }

        public bool IncreaseQuantityInCart(int? personID, int productID)
        {
            if (personID.HasValue && personID.Value > 0 && productID > 0)
            {
                if (shoppingCart.ContainsKey(personID.Value))
                {
                    List<Product> products = shoppingCart[personID.Value];
                    Product product = products.Find(p => p.GetID() == productID);

                    if (product != null)
                    {
                        product.Quantity++;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DecreaseQuantityInCart(int? personID, int productID)
        {
            if (personID.HasValue && productID > 0)
            {
                if (shoppingCart.ContainsKey(personID.Value))
                {
                    List<Product> products = shoppingCart[personID.Value];
                    Product product = products.Find(p => p.GetID() == productID);

                    if (product != null && product.Quantity >= 1)
                    {
                        product.Quantity--;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool ClearShoppingCart(int? personID)
        {
            if (personID.HasValue)
            {
                shoppingCart[(int)personID].Clear();
                return true;
            }
            return false;
        }

        public int GetItemQuantity(int ID, int? personID)
        {
            if (personID.HasValue && shoppingCart.ContainsKey(personID.Value))
            {
                List<Product> products = shoppingCart[personID.Value];
                Product product = products.Find(p => p.GetID() == ID);

                if (product != null)
                {
                    return product.Quantity;
                }
            }
            return 0;
        }
    }
}
