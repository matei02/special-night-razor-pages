using DataAccessLayer.Interfaces;
using DomainsLayer;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Cryptography;
using BCrypt.Net;


namespace LogicLayer
{
    public static class PasswordHasing
    {
        public static string GetSalt()
        {
            var salt = new byte[30];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public static string GetHash(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password + salt);
        }

        public static bool ValidatePassword(string password, string salt, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, passwordHash);
        }
        /*const int keySize = 64;
        const int iterations = 350000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public static string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }*/
    }

    public class AccountManager
    {
        private IAccountDAL IAccountDAL;

        public AccountManager(IAccountDAL accountDAL) 
        {
            IAccountDAL = accountDAL;
        }

        public List<string> GetAllCustomerEmails()
        {
            return IAccountDAL.GetAllCustomerEmails();
        }

        public bool AddCustomerAccount(string name, string password, string email, string address, string phoneNumber, int age, Gender gender)
        {
            return IAccountDAL.AddCustomerAccount(name, password, email, address, phoneNumber, age, gender);
        }

        public bool AddAdminAccount(string name, string password, string email, string address, string phoneNumber)
        {
            return IAccountDAL.AddAdminAccount(name, password, email, address, phoneNumber);
        }

        public List<Customer> GetAllCustomers()
        {
            return IAccountDAL.GetAllCustomers();
        }

        public List<Admin> GetAllAdmins()
        {
            return IAccountDAL.GetAllAdmins();
        }

        public Customer GetCustomer(string email, string password)
        {
            return IAccountDAL.GetCustomer(email, password);
        }

        public Admin GetAdmin(string email, string password)
        {
            return IAccountDAL.GetAdmin(email, password);
        }

        public Customer? GetCustomerByID(int? ID)
        {
            return IAccountDAL.GetCustomerByID(ID);
        }

        public Admin GetAdminByID(int ID)
        {
            return IAccountDAL.GetAdminByID(ID);
        }

        public bool DoesAccountExist(string email)
        {
            return IAccountDAL.DoesAccountExist(email);
        }

        public bool DeleteCustomer(int? ID)
        {
            return IAccountDAL.DeleteCustomer(ID);
        }

        public bool DeleteAdmin(int ID)
        {
            return IAccountDAL.DeleteAdmin(ID);
        }

        public bool UpdateAdmin(string name, string password, string email, string address, string phoneNumber, int ID)
        {
            return IAccountDAL.UpdateAdmin(name, password, email, address, phoneNumber, ID);
        }

        public bool UpdateCustomer(string name, string password, string email, string address, string phoneNumber, int? ID, int age, Gender gender)
        {
            return IAccountDAL.UpdateCustomer(name, password, email, address, phoneNumber, ID, age, gender);
        }

        public bool SetOrderID(int? ID, int orderID)
        {
            return IAccountDAL.SetOrderID(ID, orderID);
        }

        public int GetOrderID(int? ID) 
        {
            return IAccountDAL.GetOrderID(ID);
        }

        public bool EndRental(int? ID)
        {
            return IAccountDAL.EndRental(ID);
        }

        public List<Customer> GetCustomersSameGenderAndAgeRange(int? ID)
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = GetCustomerByID(ID);
            int customerAge = customer.Age;
            Gender customerGender = customer.Gender;
            if (16 <= customerAge && customerAge <= 25)
            {
                foreach (Customer c in GetAllCustomers())
                {
                    if (c.Id != customer.Id)
                    {
                        if (16 <= c.Age && c.Age <= 25 && c.Gender == customerGender)
                        {
                            customers.Add(c);
                        }
                    }
                    
                }
            }
            else if (26 <= customerAge && customerAge <= 50)
            {
                foreach (Customer c in GetAllCustomers())
                {
                    if (c.Id != customer.Id)
                    {
                        if (26 <= c.Age && c.Age <= 50 && c.Gender == customerGender)
                        {
                            customers.Add(c);
                        }
                    }
                }
            }
            else if (customerAge >= 51)
            {
                foreach (Customer c in GetAllCustomers())
                {
                    if (c.Id != customer.Id)
                    {
                        if (c.Age >= 51 && c.Gender == customerGender)
                        {
                            customers.Add(c);
                        }
                    }
                }
            }
            return customers;
        }

    }
}
