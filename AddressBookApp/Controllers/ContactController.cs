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
            throw new NotImplementedException();
        }

        [HttpPost("update-contact")]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        [HttpPost("delete-contact-by-id")]
        public async Task<IActionResult> DeleteContactById(int id)
        {
            throw new NotImplementedException();
        }


    }
}
