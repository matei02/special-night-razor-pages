using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsLayer.Classes
{
    public class Order
    {
        private int id;
        private int total;
        private List<Product> allproducts;
        private int status;
        private int customerID;

        public Order(int id)
        {
            allproducts = new List<Product>();
            this.id = id;
        }

        public Product Product
        {
            get => default;
            set
            {
            }
        }

        public void AddToOrder(Product product)
        {
            allproducts.Add(product);
        }

        public void RemoveFromOrder(Product product)
        {
            allproducts.Remove(product);
        }

        public int GetTotal()
        {
            total = 0;
            foreach (Product product in allproducts)
            {
                total += product.GetPrice();
            }
            return total;
        }

        public int GetOrderID()
        {
            return id;
        }

        public int GetStatus()
        { return status; }

        public void SetStatus(int status)
        { this.status = status; }

        public void SetOrderID(int ID)
        {
            id = ID;
        }

        public int GetCustomerID()
        { return customerID; }

        public void SetCustomerID(int customerID)
        {
            this.customerID = customerID;
        }

        public List<Product> GetProducts()
        {
            return allproducts;
        }

        public override string ToString()
        {
            string s = string.Empty;
            if (status == 0)
            {
                s = $"Order #{id} - IN PROGRESS - Customer: #{customerID}";
            }
            else if (status == 1)
            {
				s = $"Order #{id} - FINISHED - Customer: #{customerID}";
			}
            /* contains:\n";
            foreach (Product product in allproducts)
            {
                s += product.GetInfo() + ",wow! " + '\n';
            }
            */
            return s;
        }

    }
}
