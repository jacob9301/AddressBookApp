using AddressBookApp.Interfaces;
using AddressBookApp.Models;
using Newtonsoft.Json;

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

                if (String.IsNullOrEmpty(jsonString)) { return new List<Contact>(); }

                List<Contact>? contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonString);

                if (contacts == null) { return new List<Contact>(); }

                return contacts;
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
