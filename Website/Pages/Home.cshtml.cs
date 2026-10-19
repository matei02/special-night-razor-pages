using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.DALs;
using LogicLayer;
using DomainsLayer;

namespace Website.Pages
{
    public class HomeModel : PageModel
    {
        IProductDAL productDAL;
        ProductManager manager;

        public void OnGet()
        {
            productDAL = new ProductDAL();
            manager = new ProductManager(productDAL);
        }

        public List<Product> GetAllProducts
        {
            get { return manager.GetAllProductsFromDatabase(); }
        }

        public ProductManager GetManager
        {
            get { return manager; }
        }
    }
}
