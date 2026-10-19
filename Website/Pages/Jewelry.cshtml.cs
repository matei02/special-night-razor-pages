using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DomainsLayer;
using LogicLayer;

namespace Website.Pages
{

    public class JewelryModel : PageModel
    {
        IProductDAL productDAL;
        ProductManager manager;

        public void OnGet()
        {
            productDAL = new ProductDAL();
            manager = new ProductManager(productDAL);
        }

        public List<Jewelry> GetAllJewelry
        {
            get 
            { 
                List<Jewelry> jewelries = new List<Jewelry>();
                jewelries.AddRange(manager.GetBraceletsStock());
                jewelries.AddRange(manager.GetNecklacesStock());
                jewelries.AddRange(manager.GetEarringsStock());
                return jewelries;
            }
        }

        public ProductManager GetManager
        {
            get { return manager; }
        }
    }
}
