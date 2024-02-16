using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHTMX.Services;
namespace RazorHTMX.Pages.Contacts
{
    public class EditModel(IContactService service) : PageModel
    {
        private readonly IContactService service = service;

        [BindProperty]
        public Contact Contact { get; set; } = new Contact();
        public Dictionary<string, string> Errors { get; set; } = [];

        public void OnGet(int id)
        {
            var contact = service.GetContacts().FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                //Redirect to not found
            }
            else
            {
                Contact = contact;
            }
        }

        public IActionResult OnPost()
        {
            if (service.Update(Contact))
            {
                return Redirect("/contacts");
            }
            else
            {
                Errors.Add("email", "must be unique");

                return Page();
            }
        }

        public IActionResult OnPostDelete()
        {
            service.Remove(Contact);

            return Redirect("/contacts");
        }
    }
}
