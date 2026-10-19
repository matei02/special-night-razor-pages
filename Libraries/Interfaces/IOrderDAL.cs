using DomainsLayer;
using DomainsLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderDAL
    {
        public int? CreateOrder(int personID);

        /*public bool DeliverOrder(int personID);*/

/*        public bool AddToOrder(Product product);

        public bool RemoveFromOrder(Product product);*/

        public List<Order> GetAllOrders();

        public Order? GetOrderByID(int id);

        public bool DeleteOrder(Order order);

        public List<Order> GetAllOrdersForCustomer(int? id);

        public bool SetOrderStatusFinished(Order order);

	}
}
