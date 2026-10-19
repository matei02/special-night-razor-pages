using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polly;

namespace Website.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        public Product product;
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Dress dress { get; set; }
        public Suit suit { get; set; }
        public Necklace necklace { get; set; }
        public Bracelet bracelet { get; set; }
        public Earring earring { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

        IProductDAL productDAL;
        ProductManager productManager;


        public void OnGet(int id)//, string name)
        {
            ID = id;
            // Name = name;
            productDAL = new ProductDAL();
            productManager = new ProductManager(productDAL);

            if (productManager.GetDressByID(ID) != null)
            {
                dress = productManager.GetDressByID(ID);
            }
            else if (productManager.GetSuitByID(ID) != null)
            {
                suit = productManager.GetSuitByID(ID);
            }
            else if (productManager.GetBraceletByID(ID) != null)
            {
                bracelet = productManager.GetBraceletByID(ID);
            }
            else if (productManager.GetNecklaceByID(ID) != null)
            {
                necklace = productManager.GetNecklaceByID(ID);
            }
            else if (productManager.GetEarringByID(ID) != null)
            {
                earring = productManager.GetEarringByID(ID);
            }
        }

        public ProductManager GetManager
        {
            get { return productManager; }
        }

        public AccountManager accountManager
        {
            get { 
                IAccountDAL accountDAL = new AccountDAL(); 
                return new AccountManager(accountDAL);
                }
        }

        public bool DoesCustomerHaveRental
        {
            get 
            {
                if (accountManager.GetOrderID(HttpContext.Session.GetInt32("id")) != -1)
                    return true;
                else return false;
            }
        }

        public bool EqualCartAndStock(int id)
        {
			IShoppingCart IShoppingCart = new ShoppingCartDAL();
			ShoppingCartManager ShoppingCartManager = new ShoppingCartManager(IShoppingCart);

			productDAL = new ProductDAL();
			productManager = new ProductManager(productDAL);

			int cart_quantity = ShoppingCartManager.GetItemQuantity(id, HttpContext.Session.GetInt32("id"));
			int product_quantity = productManager.GetProductByID(id).Quantity;

            return (cart_quantity == product_quantity);
		}

        public IActionResult OnPostAddToCart()
        {
            IShoppingCart IShoppingCart = new ShoppingCartDAL();
            ShoppingCartManager ShoppingCartManager = new ShoppingCartManager(IShoppingCart);

            productDAL = new ProductDAL();
            productManager = new ProductManager(productDAL);

            int cart_quantity = ShoppingCartManager.GetItemQuantity(ProductID, HttpContext.Session.GetInt32("id"));
            int product_quantity = productManager.GetProductByID(ProductID).Quantity;

			if (cart_quantity < product_quantity)
            {
                if (ShoppingCartManager.AddToShoppingCart(HttpContext.Session.GetInt32("id"), ProductID))
                {
					return RedirectToPage("Home");
				}
                else
                {
                    ModelState.AddModelError("Message", "Error when adding to cart.");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("Message", "Error regarding quantity.");
                return Page();
            }
        }

        public IActionResult OnPostGoToLogin()
        {
            return RedirectToPage("Login");
        }
    }
}
