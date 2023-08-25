using FakeItEasy;
using AddressBookApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookApp.Models;
using AddressBookApp.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookApp.Test.Controllers
{
    public class ContactControllerTest
    {
        private readonly IContactRepository _contactRepository;
        public ContactControllerTest()
        {
            _contactRepository = A.Fake<IContactRepository>();
        }

        [Fact]
        public async void ContactController_GetAllContacts_ReturnOK()
        {
            //Arrange
            var contacts = A.Fake<List<Contact>>();
            A.CallTo(() => _contactRepository.GetContacts()).Returns(Task.FromResult(contacts));
            var controller = new ContactController(_contactRepository);

            //Act
            var result = await controller.GetAllContacts();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void ContactController_GetAllContacts_ReturnAllContacts()
        {
            //Arrange
            List<Contact> expectedContacts = new List<Contact>
            {
                new Contact() { Id = 1, FirstName="David", LastName="Platt"},
                new Contact() { Id = 2, FirstName="Jason", LastName="Grimshaw"},
                new Contact() { Id = 3, FirstName="Ken", LastName="Barlow"},
            };

            A.CallTo(() => _contactRepository.GetContacts()).Returns(Task.FromResult(expectedContacts));
            var controller = new ContactController(_contactRepository);

            //Act
            var result = await controller.GetAllContacts();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
            OkObjectResult objectResult = (OkObjectResult)result;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeEquivalentTo(expectedContacts);
        }
    }
}
