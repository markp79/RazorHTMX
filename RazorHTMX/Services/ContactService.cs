using RazorHTMX.Pages.Contacts;
using System.Collections;

namespace RazorHTMX.Services
{
    public class ContactService : IContactService
    {
        private List<Contact> _contacts =
        [
            new Contact() { Id=1, First="Bob", Last="Smith", Email="bob@test.com", Phone="123-456-7890"  },
            new Contact() { Id=2, First="Alice", Last="Jones", Email="alice@test.com", Phone="123-456-7891"  },
        ];

        public IEnumerable<Contact> GetContacts() { return _contacts; }

        public void Remove(Contact contact)
        {
            _contacts = _contacts.Where(c => c.Id != contact.Id).ToList();
        }

        public bool Save(Contact contact)
        {
            if(_contacts.Any(c => c.Email == contact.Email))
                {  return false; }

            contact.Id = _contacts.Max(c => c.Id) + 1;

            _contacts = [.. _contacts, contact];

            return true;
        }

        public bool Update(Contact contact)
        {
            int index = _contacts.FindIndex(c => c.Id == contact.Id);

            if (index != -1)
            {
                _contacts[index] = contact;
                return true;
            }

            return false;
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string? First { get; set; }
        public string? Last { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}
