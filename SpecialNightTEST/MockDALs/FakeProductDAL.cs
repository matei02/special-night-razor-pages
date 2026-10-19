using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNightTEST.MockDALs
{
    public class FakeProductDAL : IProductDAL
    {
        List<Product> products;
        public FakeProductDAL() 
        { 
            products = new List<Product>();
        }
        
        public bool AddBraceletToDatabase(Bracelet bracelet)
        {
            if (bracelet!=null)
            {
                products.Add(bracelet);
                return true;
            }
            return false;
        }
        
        public bool AddDressToDatabase(Dress dress)
        {
            if (dress != null)
            {
                products.Add(dress);
                return true;
            }
            return false;
        }
        
        public bool AddEarringsToDatabase(Earring earring)
        {
            if (earring != null)
            {
                products.Add(earring);
                return true;
            }
            return false;
        }
        
        public bool AddNecklaceToDatabase(Necklace necklace)
        {
            if (necklace != null)
            {
                products.Add(necklace);
                return true;
            }
            return false;
        }
        
        public bool AddSuitToDatabase(Suit suit)
        {
            if (suit != null)
            {
                products.Add(suit);
                return true;
            }
            return false;
        }
        
        public bool DeleteBraceletFromDatabase(int productID)
        {
            foreach (Product bracelet in GetAllProducts()) 
            {
                if (bracelet.GetID() == productID)
                {
                    products.Remove(bracelet);
                    return true;
                }    
            }
            return false;
        }
        
        public bool DeleteDressFromDatabase(int productID)
        {
            foreach (Product dress in GetAllProducts())
            {
                if (dress.GetID() == productID)
                {
                    products.Remove(dress);
                    return true;
                }
            }
            return false;
        }
        
        public bool DeleteEarringFromDatabase(int productID)
        {
            foreach (Product earring in GetAllProducts())
            {
                if (earring.GetID() == productID)
                {
                    products.Remove(earring);
                    return true;
                }
            }
            return false;
        }
        
        public bool DeleteNecklaceFromDatabase(int productID)
        {
            foreach (Product necklace in GetAllProducts())
            {
                if (necklace.GetID() == productID)
                {
                    products.Remove(necklace);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteProductByID(int id)
        {
            if (id != null)
            {
                Product product = new Bracelet(id, Material.GOLD, 20, "fake", 200);
                foreach (Product p in GetAllProducts())
                {
                    if (p.GetID() == id)
                    {
                        product = p;
                    }
                }
                if (products.Remove(product))
                    return true;
                return false;
            }
            return false;
        }

        public bool DeleteSuitFromDatabase(int productID)
        {
            foreach (Product suit in GetAllProducts())
            {
                if (suit.GetID() == productID)
                {
                    products.Remove(suit);
                    return true;
                }
            }
            return false;
        }
        
        public List<Product> GetAllProducts()
        {
            return products;
        }
        
        public Bracelet? GetBraceletByID(int id)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.GetID() == id)
                    return (Bracelet?)p;
            }
            return null;
        }
        
        public int GetBraceletID(Bracelet bracelet)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals(bracelet))
                    return p.GetID();
            }
            return 0;
        }
        
        public List<Bracelet> GetBraceletsStock()
        {
            List<Bracelet> bracelets = new List<Bracelet>();
            foreach (Bracelet p in GetAllProducts())
            {
                bracelets.Add(p);
            }
            return bracelets;
        }
        
        public Dress? GetDressByID(int id)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.GetID() == id)
                    return (Dress?)p;
            }
            return null;
        }
        
        public List<Dress> GetDressesStock()
        {
            List<Dress> dresses = new List<Dress>();
            foreach (Dress p in GetAllProducts())
            {
                dresses.Add(p);
            }
            return dresses;
        }
        
        public int GetDressID(Dress dress)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals(dress))
                    return p.GetID();
            }
            return 0;
        }
        
        public Earring? GetEarringByID(int id)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.GetID() == id)
                    return (Earring?)p;
            }
            return null;
        }
        
        public int GetEarringsID(Earring earring)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals(earring))
                    return p.GetID();
            }
            return 0;
        }
        
        public List<Earring> GetEarringsStock()
        {
            List<Earring> earrings = new List<Earring>();
            foreach (Earring p in GetAllProducts())
            {
                earrings.Add(p);
            }
            return earrings;
        }
        
        public Necklace? GetNecklaceByID(int id)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.GetID() == id)
                    return (Necklace?)p;
            }
            return null;
        }
        
        public int GetNecklaceID(Necklace necklace)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals(necklace))
                    return p.GetID();
            }
            return 0;
        }
        
        public List<Necklace> GetNecklacesStock()
        {
            List<Necklace> necklaces = new List<Necklace>();
            foreach (Necklace p in GetAllProducts())
            {
                necklaces.Add(p);
            }
            return necklaces;
        }

        public Product GetProductByID(int id)
        {
            foreach (Product p in GetAllProducts())
            {
                if (id == p.GetID())
                {
                    return p;
                }
            }
            return null;
        }

        public Suit? GetSuitByID(int id)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.GetID() == id)
                    return (Suit?)p;
            }
            return null;
        }
        
        public int GetSuitID(Suit suit)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals(suit))
                    return p.GetID();
            }
            return 0;
        }
        
        public List<Suit> GetSuitsStock()
        {
            List<Suit> suits = new List<Suit>();
            foreach (Suit p in GetAllProducts())
            {
                suits.Add(p);
            }
            return suits;
        }
        
        public bool UpdateBraceletInDatabase(Bracelet bracelet, int productID)
        {
            foreach(Product p in GetAllProducts())
            {
                if (p.Equals((Bracelet)bracelet) && bracelet.GetID()==productID)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool UpdateDressInDatabase(Dress dress, int productID)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals((Dress)dress) && dress.GetID() == productID)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool UpdateEarringsInDatabase(Earring earring, int productID)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals((Earring)earring) && earring.GetID() == productID)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool UpdateNecklaceInDatabase(Necklace necklace, int productID)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals((Necklace)necklace) && necklace.GetID() == productID)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateProductInDatabase(Product product, int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSuitInDatabase(Suit suit, int productID)
        {
            foreach (Product p in GetAllProducts())
            {
                if (p.Equals((Suit)suit) && suit.GetID() == productID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
