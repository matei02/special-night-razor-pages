using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAccountDAL
    {
        List<string> GetAllCustomerEmails();

        List<Customer> GetAllCustomers();

        List<Admin> GetAllAdmins();

        public string GetCustomerSalt(string email);

        public string GetAdminSalt(string email);

        public string GetCustomerPassword(string email);

        public string GetAdminPassword(string email);

        Customer GetCustomer(string email, string password);

        Admin GetAdmin(string email, string password);

        Customer GetCustomerByID(int? ID);

        Admin GetAdminByID(int ID);

        public string GetAdminPasswordByEmail(string email);

        bool DoesAccountExist(string email);

        bool AddCustomerAccount(string name, string password, string email, string address, string phoneNumber, int age, Gender gender);

        bool AddAdminAccount(string name, string password, string email, string address, string phoneNumber);

        bool DeleteCustomer(int? ID);

        bool DeleteAdmin(int ID);

        bool UpdateAdmin(string name, string password, string email, string address, string phoneNumber, int ID);

        bool UpdateCustomer(string name, string password, string email, string address, string phoneNumber, int? ID, int age, Gender gender);

        public bool SetOrderID(int? ID, int orderID);

        public int GetOrderID(int? ID);

        public bool EndRental(int? ID);



    }
}
