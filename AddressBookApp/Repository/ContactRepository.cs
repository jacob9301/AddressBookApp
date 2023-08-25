using AddressBookApp.Interfaces;
using AddressBookApp.Models;

namespace AddressBookApp.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _path;
        public ContactRepository(string path)
        {
            _path = path;
        }

        public List<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public void WriteContacts()
        {
            throw new NotImplementedException();
        }
    }
}
