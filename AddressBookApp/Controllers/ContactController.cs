using AddressBookApp.Interfaces;
using AddressBookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost("create-contact")]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            List<Contact> contacts = await _contactRepository.GetContacts();

            contacts.Add(contact);

            _contactRepository.WriteContacts(contacts);

            return new OkObjectResult(contacts);
        }

        [HttpGet("get-all-contacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            List<Contact> contacts = await _contactRepository.GetContacts();

            return new OkObjectResult(contacts);
        }

        [HttpPost("get-contact-by-id")]
        public async Task<IActionResult> GetContactById(int id)
        {
            List<Contact> contacts = await _contactRepository.GetContacts();

            foreach (Contact contact in contacts)
            {
                if (contact.Id == id) { return new OkObjectResult(contact); }
            }

            return NotFound();
        }

        [HttpPost("update-contact")]
        public async Task<IActionResult> UpdateContact(Contact newContactInfo)
        {
            List<Contact> contacts = await _contactRepository.GetContacts();

            foreach (Contact contact in contacts)
            {
                if (contact.Id == newContactInfo.Id) 
                {
                    contact.FirstName = newContactInfo.FirstName;
                    contact.LastName = newContactInfo.LastName;
                    contact.Email = newContactInfo.Email;
                    contact.Phone = newContactInfo.Phone;

                    _contactRepository.WriteContacts(contacts);

                    return new OkObjectResult(contacts);
                }
            }

            return NotFound();
        }

        [HttpPost("delete-contact-by-id")]
        public async Task<IActionResult> DeleteContactById(int id)
        {
            List<Contact> contacts = await _contactRepository.GetContacts();

            foreach (Contact contact in contacts)
            {
                if (contact.Id == id)
                {
                    contacts.Remove(contact);

                    _contactRepository.WriteContacts(contacts);

                    return new OkObjectResult(contacts);
                }
            }

            return NotFound();
        }


    }
}
