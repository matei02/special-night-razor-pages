using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DALs;
using LogicLayer;

namespace Website.Pages
{

    public class ContactModel : PageModel
    {/*
        [BindProperty]
        public string EmailAddress { get; set; }*/

        public IReviewDAL IReviewDAL;
        public ReviewManager ReviewManager;

        [BindProperty]
        [StringLength(100)]
        [Required]
        public string? Review { get; set; }
        public string? Message { get; set; }
        public void OnGet()
        {
            Message = "";
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Review))
                {
                    int ?id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
                    if (id != null)
                    {
                        IReviewDAL IReviewDAL = new ReviewDAL();
                        ReviewManager ReviewManager = new ReviewManager(IReviewDAL);
                        if (ReviewManager.AddReviewToDatabase(id, Review))
                        {
                            Message = "Review submitted succesfully!";
                            Review = "";
                            return RedirectToPage("/Contact");
                        }
                        else
                        {
                            Message = "Couldn't submit review.";
                            return this.Page();
                        }
                    }
                }
                else
                {
                    Message = "Cannot submit empty review!";
                    return this.Page();
                }
            }
            return this.Page();

        }

        public IActionResult OnPostGoToLogin()
        {
            return RedirectToPage("Login");
        }

	}
}
