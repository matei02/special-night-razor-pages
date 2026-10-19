using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Security.Claims;

namespace Website.Pages
{

    public class ProfileModel : PageModel
    {
        public AccountManager AccountManager { get; set; }
        public IAccountDAL IAccountDAL { get; set; }

        [StringLength(50)]
        [Required]
        [BindProperty]
        public string? Name { get; set; }

        [StringLength(50)]
        [Required]
        [BindProperty]
        public string? Email { get; set; }

        [StringLength(50)]
        [Required]
        [BindProperty]
        public string? Password { get; set; }

        [StringLength(50)]
        //[Required]
        [Compare("Password")]
        [BindProperty]
        public string? ConfirmPassword { get; set; }

        [StringLength(50)]
        [Required]
        [BindProperty]
        public string? Address { get; set; }


        [BindProperty]
        [Required]
        [Range(16, 100, ErrorMessage = "The age must be at least 16.")]
        public int Age { get; set; }

        [StringLength(50)]
        [Required]
        [BindProperty]
        public string Gender { get; set; }

        [StringLength(13)]
        [Required]
        [BindProperty]
        public string? PhoneNumber { get; set; }

        public Gender EnumGender { get; set; }

        [BindProperty]
        public Customer customer { get; set; }
        public void OnGet()
        {
            customer = new Customer();
            /*var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            int? id = Convert.ToInt32(claims.Find(claim => claim.Type == ClaimTypes.NameIdentifier).Value);*/
            int? id = HttpContext.Session.GetInt32("id");
            IAccountDAL = new AccountDAL();
            AccountManager = new AccountManager(IAccountDAL);
            customer = AccountManager.GetCustomerByID(id);

        }

        public IActionResult OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(Name))
                {
                    ModelState.AddModelError("Name", "This field is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(Email))
                {
                    ModelState.AddModelError("Email", "This field is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    ModelState.AddModelError("Password", "This field is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(ConfirmPassword))
                {
                    ModelState.AddModelError("ConfirmPassword", "This field is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(Address))
                {
                    ModelState.AddModelError("Address", "This field is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "This field is a required field.");
                    return Page();
                }
                else if (Age < 16)
                {
                    ModelState.AddModelError("Age", "Age cannot be lower than 16.");
                    return Page();
                }
                else if (Age > 100)
                {
                    ModelState.AddModelError("Age", "Age cannot be over 100.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(Gender))
                {
                    ModelState.AddModelError("Gender", "This field is a required field.");
                    return Page();
                }
                if (Password.Equals(ConfirmPassword))
                {
                    if (Gender.ToLower().Equals("male"))
                    {
                        EnumGender = DomainsLayer.Gender.male;
                    }
                    else if (Gender.ToLower().Equals("female"))
                    {
                        EnumGender = DomainsLayer.Gender.female;
                    }

                    /*var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    int? id = Convert.ToInt32(claims.Find(claim => claim.Type == ClaimTypes.NameIdentifier).Value);*/
                    int? id = HttpContext.Session.GetInt32("id");
                    IAccountDAL = new AccountDAL();
                    AccountManager = new AccountManager(IAccountDAL);
                    if (AccountManager.UpdateCustomer(Name, Password, Email, Address, PhoneNumber, id, Age, EnumGender))
                    {
                        HttpContext.Session.SetString("Name", Name);
                        return RedirectToPage("Home");
                    }
                    else return RedirectToPage("Profile");
                }
                else return Page();
            }
            else return Page();
        }

        public IActionResult OnPostDelete()
        {
            if (ModelState.IsValid)
            {
                IAccountDAL = new AccountDAL();
                AccountManager = new AccountManager(IAccountDAL);
                int? id = HttpContext.Session.GetInt32("id");
                try
                {
                    if(AccountManager.DeleteCustomer(id))
                    {
                        HttpContext.Session.Clear();
                        return RedirectToPage("Login");
                    }
                    return RedirectToPage("Login");
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (Gender.ToLower().Equals("male"))
                        {
                            EnumGender = DomainsLayer.Gender.male;
                        }
                        else if (Gender.ToLower().Equals("female"))
                        {
                            EnumGender = DomainsLayer.Gender.female;
                        }

                        AccountManager.UpdateCustomer(Name, Password, "deleted account", Address, PhoneNumber, id, Age, EnumGender);
                        HttpContext.Session.Clear();
                        return RedirectToPage("Login");
                    }
                    catch (Exception updateEx)
                    {
                        // Handle the exception when updating the customer
                        TempData["text"] = "Error updating customer: " + updateEx.Message;
                        return Page();
                    }
                }
            }
            TempData["text"] = "Error.";
            return Page();
        }
      
    }
}
