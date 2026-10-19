using DomainsLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IShoppingCart
    {
        public bool AddToShoppingCart(int? personID, int productID);

        public List<Product> GetAllShoppingCartProducts(int? personID);

        public int GetTotal(int? personID);

        public bool RemoveFromShoppingCart(int? personID, int productID);

        public bool IncreaseQuantityInCart(int? personID, int productID);

        public bool DecreaseQuantityInCart(int? personID, int productID);

        public bool ClearShoppingCart(int? personID);

        public int GetItemQuantity(int ID, int? personID);

    }
}
