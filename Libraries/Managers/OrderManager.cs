using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using System.Diagnostics;
/*using Octokit;
using ElasticEmail.Api;
using ElasticEmail.Client;
using ElasticEmail.Model;*//*
using ElasticEmail.Api;
using ElasticEmail.Model;*/
using System.Collections.Generic;
using Octokit;

namespace LogicLayer
{
    public class OrderManager
    {
        private IOrderDAL orderDAL;

        private AccountManager accountManager;

        private ProductManager productManager;

        public OrderManager(IOrderDAL orderDAL)
        {
            this.orderDAL = orderDAL;
        }

        /*public bool DeliverOrder(int personID)
        {
            return orderDAL.DeliverOrder(personID);
        }*/

        public List<Order> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public int? CreateOrder(int personID)
        {
            return orderDAL.CreateOrder(personID);
        }

        /*public bool AddToOrder(Product product)
        {
            return orderDAL.AddToOrder(product);
        }

        public bool RemoveFromOrder(Product product)
        {
            return orderDAL.RemoveFromOrder(product);
        }*/

        public Order GetOrderByID(int id)
        {
            return orderDAL.GetOrderByID(id);
        }

        public bool DeleteOrder(Order order)
        {
            return orderDAL.DeleteOrder(order);
        }

        public List<Order> GetAllOrdersForCustomer(int id)
        {
            return orderDAL.GetAllOrdersForCustomer(id);
        }

        public bool SetOrderStatusFinished(Order order)
        {
            return orderDAL.SetOrderStatusFinished(order);
        }

        public void SendOrderEmail(string email, List<Product> products, int orderID)
        {
            /*Configuration config = new Configuration();
            config.BasePath = "https://api.elasticemail.com/v4";
            config.AddApiKey("X-ElasticEmail-ApiKey", "change-me-to-a-long-random-secret-of-at-least-32-bytes");

            var apiInstance = new EmailsApi(config);
            var emailTransactionalMessageData = new EmailTransactionalMessageData
            {
                Subject = $"Order #{orderID} has been confirmed!",
                From = new EmailAddress { Email = "user2@example.com" },
                To = new List<EmailAddress> { new EmailAddress { Email = email } },
                Body = "You have ordered:\n"
            };

            foreach (Product product in products)
            {
                emailTransactionalMessageData.Body += $"1x {product.GetInfo()}\n";
            }

            try
            {
                // Send Transactional Email
                EmailSendResponse result = apiInstance.EmailsTransactionalPost(emailTransactionalMessageData);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling EmailsApi.EmailsTransactionalPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }*/


            /*MailMessage message = new MailMessage("user2@example.com", email);
            message.To.Add(email);
            message.Subject = $"Order #{orderID} has been confirmed!";
            message.Body = "You have ordered:";
            message.Body += "\n";
            foreach (Product product in products)
            {
                message.Body += "1x " + product.GetInfo();
                message.Body += "\n";
            }

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("user2@example.com", "yswqadcltyzwwfad"),
                EnableSsl = true,
            };
            smtpClient.Send(message);*/
        }

        public List<Product> GetRecommendedProductsForUser(int? userId, AccountManager accountManager1, ProductManager productManager1) 
        {

            accountManager = accountManager1;
            productManager = productManager1;

            List<Product> recommendedProducts = new List<Product>();
            List<Customer> similarCustomers = accountManager.GetCustomersSameGenderAndAgeRange(userId);
            foreach (Customer customer in similarCustomers)
            {
                List<Order> orders = orderDAL.GetAllOrdersForCustomer(customer.Id);
                foreach (Order order in orders)
                {
                    foreach(Product product in order.GetProducts())
                    {
                        Product p = productManager.GetProductByID(product.GetID());
                        if (p.Quantity > 0)
                        {
                            recommendedProducts.Add(p);
                        }
                    }
                }
            }
            Customer client = accountManager.GetCustomerByID(userId);
            List<Product> orderedProducts = new List<Product>();

            foreach (Product p in  recommendedProducts)
            {
                if (client.Gender == Gender.male)
                {
                    if (p is Suit)
                    {
                        orderedProducts.Add(p);
                    }
                }
                else if (client.Gender == Gender.female)
                {
                    if (p is Dress)
                    {
                        orderedProducts.Add(p);
                    }
                    else if (p is Bracelet)
                    {
                        orderedProducts.Add(p);
                    }
                    else if (p is Necklace)
                    {
                        orderedProducts.Add(p);
                    }
                    else if (p is Earring)
                    {
                        orderedProducts.Add(p);
                    }
                }
            }
            foreach (Product p in recommendedProducts )
            {
                if (!orderedProducts.Contains(p)) 
                { 
                    orderedProducts.Add(p);
                }
            }
            return orderedProducts;
        }

    }
}
