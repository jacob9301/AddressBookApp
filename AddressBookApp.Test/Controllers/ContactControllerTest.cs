using FakeItEasy;
using AddressBookApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookApp.Test.Controllers
{
    public class ContactControllerTest
    {
        private readonly IContactRepository _contactRepository;
        public ContactControllerTest()
        {
            _contactRepository = A.Fake<IContactRepository>();
        }
    }
}
