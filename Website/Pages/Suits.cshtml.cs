using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{

    public class SuitsModel : PageModel
    {
        IProductDAL productDAL;
        ProductManager manager;

        public void OnGet()
        {
            productDAL = new ProductDAL();
            manager = new ProductManager(productDAL);
        }

        public List<Suit> GetAllSuits
        {
            get { return manager.GetSuitsStock(); }
        }

        public ProductManager GetManager
        {
            get { return manager; }
        }
    }
}
