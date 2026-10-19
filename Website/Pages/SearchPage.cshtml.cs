using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class SearchPageModel : PageModel
    {
        public IActionResult OnGet(string query)
        {
            if ("Dresses".Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("Dresses");
            }
            else if ("Suits".Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("Suits");
            }
            else if ("Jewelry".Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("Jewelry");
            }
            else if ("Contact".Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("Contact");
            }
            else if ("Catalogue".Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("Home");
            }
            else if ("Shopping Cart".Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("Shopping_Cart");
            }
            else return RedirectToPage("Error");
        }
    }
}
