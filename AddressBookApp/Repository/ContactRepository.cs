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

        public async Task<List<Contact>> GetContacts()
        {
            try
            {
                string jsonString = await File.ReadAllTextAsync(_path);
                Console.WriteLine(jsonString);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Contact>();
        }

        public void WriteContacts()
        {
            throw new NotImplementedException();
        }
    }
}
