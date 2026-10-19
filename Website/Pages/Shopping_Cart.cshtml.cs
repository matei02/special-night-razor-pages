using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Utilities;
using System.Net.Mail;
using System.Net;

namespace Website.Pages
{

    public class Shopping_CartModel : PageModel
    {
        public IShoppingCart IShoppingCart { get; set; }
        [BindProperty]
        public int ProductID { get; set; }

        [BindProperty]
        public string? Message { get; set; }

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public Shopping_CartModel()
        {
            /*_apiKey = "change-me-to-a-long-random-secret-of-at-least-32-bytes"; // Replace with your actual API key
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.elasticemail.com/v2/");*/
        }

        public void OnGet()
        {
            /*IShoppingCart = new ShoppingCartDAL();
            ShoppingCartManager = new ShoppingCartManager(IShoppingCart);*/
        }

        public AccountManager AccountManager { get {
                IAccountDAL account = new AccountDAL();
                return new AccountManager(account);
            } }

        public ShoppingCartManager ShoppingCartManager
        {
            get {
                IShoppingCart = new ShoppingCartDAL();
                return new ShoppingCartManager(IShoppingCart);
            }
        }

        public ProductManager productManager
        {
            get
            {
                IProductDAL productDAL = new ProductDAL();
                return new ProductManager(productDAL);
            }
        }

        public OrderManager orderManager
        {
            get
            {
                IOrderDAL orderDAL = new OrderDAL();
                return new OrderManager(orderDAL);
            }
        }

        public async Task<IActionResult> OnPostPlaceOrder()
        {
            if (ShoppingCartManager.GetAllShoppingCartProducts(HttpContext.Session.GetInt32("id")).Count >= 1)
            {

                int? orderid = orderManager.CreateOrder((int)HttpContext.Session.GetInt32("id"));
                if (orderid.HasValue)
                {
                    /*var body = string.Join("\n", ShoppingCartManager.GetAllShoppingCartProducts((int)HttpContext.Session.GetInt32("id")));

                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("apikey", _apiKey),
                        new KeyValuePair<string, string>("from", "user2@example.com"),
                        new KeyValuePair<string, string>("to", AccountManager.GetCustomerByID((int)HttpContext.Session.GetInt32("id")).Email),
                        new KeyValuePair<string, string>("subject", "Test Email"),
                        new KeyValuePair<string, string>("bodyHtml", body)
                    });
                    var response = await _httpClient.PostAsync("email/send", content);
                    response.EnsureSuccessStatusCode();

                    MailMessage message = new MailMessage("user2@example.com", AccountManager.GetCustomerByID((int)HttpContext.Session.GetInt32("id")).Email);
                    message.To.Add(AccountManager.GetCustomerByID((int)HttpContext.Session.GetInt32("id")).Email);
                    message.Subject = $"Order #{orderid} has been confirmed!";
                    message.Body = "You have ordered:";
                    message.Body += "\n";
                    foreach (Product product in ShoppingCartManager.GetAllShoppingCartProducts((int)HttpContext.Session.GetInt32("id")))
                    {
                        message.Body += "1x " + product.GetInfo();
                        message.Body += "\n";
                    }

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        UseDefaultCredentials = false,
                        Port = 587,
                        Credentials = new NetworkCredential("user2@example.com", "yjsaebckcwwedrko"),
                        EnableSsl = true,
                    };
                    smtpClient.Send(message);*/

                    //orderManager.SendOrderEmail(AccountManager.GetCustomerByID((int)HttpContext.Session.GetInt32("id")).Email, ShoppingCartManager.GetAllShoppingCartProducts((int)HttpContext.Session.GetInt32("id")), (int)orderid);
                    AccountManager.SetOrderID(HttpContext.Session.GetInt32("id"), (int)orderid);
                    ShoppingCartManager.ClearShoppingCart((int)HttpContext.Session.GetInt32("id"));
                    HttpContext.Session.SetInt32("orderID", (int)orderid);
                    return RedirectToPage("OrderConfirmed");
                }
                else
                {
                    Message = "There was an error.";
                    return Page();
                }
            }
            else
            {
                Message = "Shopping cart is empty.";
                return Page();
            }
        }

        public IActionResult OnPostRemoveFromCart(int productID)
        {
            /*IShoppingCart = new ShoppingCartDAL();
            ShoppingCartManager = new ShoppingCartManager(IShoppingCart);*/
            if (ShoppingCartManager.RemoveFromShoppingCart(HttpContext.Session.GetInt32("id"),productID))
            {
                return RedirectToPage("Shopping_Cart");
            }
            else
            {
                return this.Page();
            }
        }

        public IActionResult OnPostIncreaseQuantity(int productID)
        {
            /*IShoppingCart = new ShoppingCartDAL();
            ShoppingCartManager = new ShoppingCartManager(IShoppingCart);*/
            if (ShoppingCartManager.IncreaseQuantityInCart(HttpContext.Session.GetInt32("id"), productID))
            {
                return RedirectToPage("Shopping_Cart");
            }
            else
            {
                return this.Page();
            }
        }

        public IActionResult OnPostDecreaseQuantity(int productID) 
        {
            /*IShoppingCart = new ShoppingCartDAL();
            ShoppingCartManager = new ShoppingCartManager(IShoppingCart);*/
            if (ShoppingCartManager.DecreaseQuantityInCart(HttpContext.Session.GetInt32("id"), productID))
            {
                return RedirectToPage("Shopping_Cart");
            }
            else
            {
                return this.Page();
            }
        }

        public IActionResult OnPostGoToLogin()
        {
            return RedirectToPage("Login");
        }
    }
}
