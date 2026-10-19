using DomainsLayer;
using DomainsLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IProductDAL
    {
        List<Necklace> GetNecklacesStock();

        List<Bracelet> GetBraceletsStock();

        List<Earring> GetEarringsStock();

        List<Dress> GetDressesStock();

        List<Suit> GetSuitsStock();

        List<Product> GetAllProducts();

        public Product GetProductByID(int id);

        public bool DeleteProductByID(int id);

        public void UpdateProductInDatabase(Product product, int id);

        bool AddDressToDatabase(Dress dress);

        bool AddSuitToDatabase(Suit suit);

        bool AddNecklaceToDatabase(Necklace necklace);

        bool AddBraceletToDatabase(Bracelet bracelet);

        bool AddEarringsToDatabase(Earring earring);

        bool DeleteDressFromDatabase(int productID);

        bool DeleteSuitFromDatabase(int productID);

        bool DeleteBraceletFromDatabase(int productID);

        bool DeleteNecklaceFromDatabase(int productID);

        bool DeleteEarringFromDatabase(int productID);

        int GetDressID(Dress dress);

        int GetSuitID(Suit suit);

        int GetBraceletID(Bracelet bracelet);

        int GetNecklaceID(Necklace necklace);

        int GetEarringsID(Earring earring);

        bool UpdateDressInDatabase(Dress dress, int productID);

        bool UpdateSuitInDatabase(Suit suit, int productID);

        bool UpdateBraceletInDatabase(Bracelet bracelet, int productID);

        bool UpdateNecklaceInDatabase(Necklace necklace, int productID);

        bool UpdateEarringsInDatabase(Earring earring, int productID);

        Dress? GetDressByID(int id);

        Suit? GetSuitByID(int id);

        Necklace? GetNecklaceByID(int id);

        Bracelet? GetBraceletByID(int id);

        Earring? GetEarringByID(int id);
    }
}
