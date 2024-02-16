using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHTMX.Services;

namespace RazorHTMX.Pages.Contacts
{
    public class NewModel(IContactService service) : PageModel
    {
        private readonly IContactService service = service;

        [BindProperty]
        public Contact Contact { get; set; } = new Contact();
        public Dictionary<string, string> Errors { get; set; } = [];

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if(service.Save(Contact))
            {
                return Redirect("/contacts");
            } else 
            {
                Errors.Add("email", "must be unique");

                return Page();
            }
        }
    }
}
