using DomainsLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsLayer
{
    public enum Gender
    {
        male,
        female
    }

    public class Customer
    {
        private int id;
        private string name;
        private string password;
        private string email;
        private string address;
        private string phoneNumber;
        private int age;
        private Gender gender;
        List<Order> orders;

        public Customer()
        {

        }

        public Customer(int id, string name, string password, string email, string address, string phone, int age, Gender gender)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.email = email;
            this.address = address;
            this.phoneNumber = phone;
            this.age = age;
            this.gender = gender;
            orders = new List<Order>();
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Address { get { return address; } set { address = value; } }  
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public Gender Gender { get { return gender; } set { gender = value; } }
        public int Age { get { return age; } set { age = value; } }

        public override string ToString()
        {
            return $"ID: {id} \n" +
                $"  Name: {name}\n";
        }

        public string GetInfo()
        {
            return $"ID: {id} \n" +
                $"Name: {name}\n" +
                $"Email: {email}\n" +
                $"Address: {address}\n" +
                $"Phone Number: {phoneNumber}\n" +
                $"Age: {age}\n" +
                $"Gender: {gender.ToString()}";
        }

        public void AddOrderToList(Order order)
        {
            orders.Add(order);
        }

        public void RemoveOrderFromList(Order order)
        {
            orders.Remove(order);
        }

        public Order[] GetOrders()
        {
            return orders.ToArray();
        }
    }
}
