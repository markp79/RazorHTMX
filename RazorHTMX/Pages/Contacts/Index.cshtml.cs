using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHTMX.Services;

namespace RazorHTMX.Pages.Contacts
{
    public class ContactsModel(IContactService service) : PageModel
    {
        private readonly IContactService service = service;

        [BindProperty(SupportsGet = true)]
        public string? Query { get; set; }
        public IEnumerable<Contact> Contacts { get; set; } = Array.Empty<Contact>();

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Query))
                Contacts = service.GetContacts();
            else
                Contacts = service.GetContacts().Where(c => c.First?.ToLower().Contains(Query.ToLower()) ?? false);
        }
    }

}
