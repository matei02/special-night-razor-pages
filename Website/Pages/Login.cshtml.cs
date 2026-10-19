using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Website.Pages
{

    public class LoginModel : PageModel
    {
        public AccountManager AccountManager { get; set; }
        public IAccountDAL IAccountDAL { get; set; }

        [BindProperty]
        public string? Message { get; set; }

        [StringLength(50)]
        //[Required]
        [BindProperty]
        public string? Name { get; set; }
        
        [StringLength(50)]
        //[Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [BindProperty]
        public string? Email { get; set; }

        [StringLength(50)]
        //[Required]
        [BindProperty]
        public string? Password { get; set; }

        [StringLength(50)]
        //[Required]
        [Compare("Password")]
        [BindProperty]
        public string? ConfirmPassword { get; set; }

        [StringLength(50)]
        //[Required]
        [BindProperty]
        public string? Address { get; set; }

        [StringLength(14)]
        //[Required]
        [BindProperty]
        public string? PhoneNumber { get; set; }


        [BindProperty]
        [Range(16, 100, ErrorMessage = "The age must be at least 16.")]
        public int Age { get; set; }

        [BindProperty]
        public string Gender { get; set; }

        [StringLength(50)]
        //[Required]
        [BindProperty]
        public string? LogPassword { get; set; }

        public Gender EnumGender { get; set; }

        [StringLength(50)]
        //[Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [BindProperty]
        public string? LogEmail { get; set; }

        public void OnGet()
        {
            if (ModelState.IsValid)
            {
                Message = "";
                Email = "";
                Name = "";
                Password = "";
                ConfirmPassword = "";
                Address = "";
                PhoneNumber = null;
                LogEmail = "";
                LogPassword = "";
                Age = 0;
                Gender = "";
            }
        }

        public async Task<IActionResult> OnPostSignUpAsync()
        {
            IAccountDAL = new AccountDAL();
            AccountManager = new AccountManager(IAccountDAL);
            Message = "";
            
            LogEmail = "";
            LogPassword = "";

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(Name))
                {
                    ModelState.AddModelError("Name", "Name is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(Email))
                {
                    ModelState.AddModelError("Email", "Email is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    ModelState.AddModelError("Password", "Password is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(ConfirmPassword))
                {
                    ModelState.AddModelError("Confirmpassword", "Confirm password is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(Address))
                {
                    ModelState.AddModelError("Address", "Address is a required field.");
                    return Page();
                }
                else if (string.IsNullOrEmpty(PhoneNumber))
                {
                    ModelState.AddModelError("Phonenumber", "Phone Number is a required field.");
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
                    ModelState.AddModelError("Gender", "Gender is a required field.");
                    return Page();
                }
                TempData["SuccessMessage"] = "Sign up successful!";

                if (AccountManager.DoesAccountExist(Email))
                {
                    Message = "Account already exists! Log in.";
                    return Page();
                }

                if (Gender.ToLower().Equals("male"))
                {
                    EnumGender = DomainsLayer.Gender.male;
                }
                else if (Gender.ToLower().Equals("female"))
                {
                    EnumGender = DomainsLayer.Gender.female;
                }

                if (AccountManager.AddCustomerAccount(Name, Password, Email, Address, PhoneNumber, Age, EnumGender))
                {
                    /*List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, $"{db.GetCustomer(Email, Password).Name}"));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, db.GetCustomer(Email, Password).Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity)); //HttpContext.Session.SetId()*/

                    HttpContext.Session.SetString("Name", Name);
                    HttpContext.Session.SetInt32("id", AccountManager.GetCustomer(Email, Password).Id);

                    return RedirectToPage("/Index");
                }
                else
                {
                    Message = "Sign up failed!";
                    return this.Page();
                }
                    
            }
            else
            {
                Message = "Error.";
                return this.Page();
            }

        }

        

        public async Task<IActionResult> OnPostLogin()
        {
            IAccountDAL = new AccountDAL();
            AccountManager = new AccountManager(IAccountDAL);

            if (ModelState.GetFieldValidationState("LogEmail") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            {
                if (ModelState.GetFieldValidationState("LogPassword") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
                    if (!string.IsNullOrEmpty(LogEmail) && !string.IsNullOrEmpty(LogPassword))
                    {
                        if (AccountManager.DoesAccountExist(LogEmail))
                        {
                            if (AccountManager.GetCustomer(LogEmail, LogPassword) != null)
                            {
                                /*List<Claim> claims = new List<Claim>();
                                claims.Add(new Claim(ClaimTypes.Name, $"{db.GetCustomer(LogEmail, LogPassword).Name}"));
                                claims.Add(new Claim(ClaimTypes.NameIdentifier, db.GetCustomer(LogEmail, LogPassword).Id.ToString()));

                                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));*/

                                HttpContext.Session.SetInt32("id", AccountManager.GetCustomer(LogEmail, LogPassword).Id);
                                HttpContext.Session.SetString("Name", AccountManager.GetCustomer(LogEmail, LogPassword).Name);

                                return RedirectToPage("Home");

                            }
                            else
                            {
                                Message = "Invalid credentials.";
                                return this.Page();
                            }
                        }
                        Message = "There is no account created with this email.";
                        return this.Page();
                    }
                    else
                    {
                        Message = "Fields cannot be empty.";
                        return this.Page();
                    }
                else
                {
                    Message = "Error.";
                    return this.Page();
                }
            }
            else
            {
                Message = "Make sure to input all fields!";
                return this.Page();
            }
        }
    }
}