using AddressBookApp.Models;

namespace AddressBookApp.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        void WriteContacts();
    }
}
