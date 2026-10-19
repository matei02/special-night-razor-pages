using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{

    public class DressesModel : PageModel
    {
        IProductDAL productDAL;
        ProductManager manager;

        public void OnGet()
        {
            productDAL = new ProductDAL();
            manager = new ProductManager(productDAL);
        }

        public List<Dress> GetAllDresses
        {
            get { return manager.GetDressesStock(); }
        }

        public ProductManager GetManager
        {
            get { return manager; }
        }
    }
}
