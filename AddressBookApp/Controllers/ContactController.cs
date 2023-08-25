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
        public async Task<IActionResult> CreateContact()
        {
            throw new NotImplementedException();
        }

        [HttpGet("get-all-contacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        [HttpPost("get-contact-by-id")]
        public async Task<IActionResult> GetContactById()
        {
            throw new NotImplementedException();
        }

        [HttpPost("update-contact")]
        public async Task<IActionResult> UpdateContact()
        {
            throw new NotImplementedException();
        }

        [HttpPost("delete-contact-by-id")]
        public async Task<IActionResult> DeleteContactById()
        {
            throw new NotImplementedException();
        }


    }
}
