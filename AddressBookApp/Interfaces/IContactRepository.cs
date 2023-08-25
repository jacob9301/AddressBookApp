using AddressBookApp.Models;

namespace AddressBookApp.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContacts();
        void WriteContacts(List<Contact> contacts);
    }
}
