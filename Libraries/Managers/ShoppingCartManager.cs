using DataAccessLayer.Interfaces;
using DomainsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ShoppingCartManager
	{
		private IShoppingCart IShoppingCart;

		public ShoppingCartManager(IShoppingCart Ishoppingcart)
		{
			IShoppingCart = Ishoppingcart;
		}

		public bool AddToShoppingCart(int? personID, int productID)
		{
			return IShoppingCart.AddToShoppingCart(personID, productID);
		}

		public List<Product> GetAllShoppingCartProducts(int? personID)
		{
			return IShoppingCart.GetAllShoppingCartProducts(personID);
		}

		public int GetTotal(int? personID)
		{
			return IShoppingCart.GetTotal(personID);
		}

        public bool RemoveFromShoppingCart(int? personID, int productID)
		{
			return IShoppingCart.RemoveFromShoppingCart(personID, productID);
		}

        public bool IncreaseQuantityInCart(int? personID, int productID)
		{
			return IShoppingCart.IncreaseQuantityInCart(personID, productID);
		}

        public bool DecreaseQuantityInCart(int? personID, int productID)
		{
			return IShoppingCart.DecreaseQuantityInCart(personID, productID);
		}

		public bool ClearShoppingCart(int? personID)
		{
			return IShoppingCart.ClearShoppingCart(personID);
		}

		public int GetItemQuantity(int ID, int? personID)
		{
			return IShoppingCart.GetItemQuantity(ID, personID);
		}

    }
}
