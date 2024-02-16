
namespace RazorHTMX.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
        void Remove(Contact contact);
        bool Save(Contact contact);
        bool Update(Contact contact);
    }
}