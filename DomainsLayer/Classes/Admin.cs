using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsLayer
{
    public class Admin
    {
        private int id;
        private string name;
        private string password;
        private string email;
        private string address;
        private string phoneNumber;

        public Admin(int id, string name, string password, string email, string address, string phone)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.email = email;
            this.address = address;
            this.phoneNumber = phone;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }


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
                $"Phone Number: {phoneNumber}";
        }
    }
}
