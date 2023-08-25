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

        [Fact]
        public async void ContactController_CreateContact_ReturnOK()
        {
            //Arrange
            var contacts = A.Fake<List<Contact>>();
            A.CallTo(() => _contactRepository.GetContacts()).Returns(Task.FromResult(contacts));
            var controller = new ContactController(_contactRepository);
            var contact = A.Fake<Contact>();

            //Act
            var result = await controller.CreateContact(contact);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void ContactController_CreateContact_ReturnJustNewContact()
        {
            //Arrange
            var contacts = new List<Contact>
            {
                new Contact() { Id = 1, FirstName="David", LastName="Platt"},
                new Contact() { Id = 2, FirstName="Jason", LastName="Grimshaw"},
                new Contact() { Id = 3, FirstName="Ken", LastName="Barlow"},
            };
            A.CallTo(() => _contactRepository.GetContacts()).Returns(Task.FromResult(contacts));
            var controller = new ContactController(_contactRepository);
            var contact = new Contact() { Id = 4, FirstName = "Rita", LastName = "Sullivan" };

            //Act
            var result = await controller.CreateContact(contact);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
            var expectedContacts = new List<Contact>
            {
                new Contact() { Id = 1, FirstName="David", LastName="Platt"},
                new Contact() { Id = 2, FirstName="Jason", LastName="Grimshaw"},
                new Contact() { Id = 3, FirstName="Ken", LastName="Barlow"},
                contact
            };
            OkObjectResult objectResult = (OkObjectResult)result;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeEquivalentTo(expectedContacts);
        }

        [Fact]
        public async void ContactController_CreateContact_ReturnAllWithNewContact()
        {
            //Arrange
            var contacts = new List<Contact>();
            A.CallTo(() => _contactRepository.GetContacts()).Returns(Task.FromResult(contacts));
            var controller = new ContactController(_contactRepository);
            var contact = new Contact() { Id = 1, FirstName = "David", LastName = "Platt" };

            //Act
            var result = await controller.CreateContact(contact);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
            var expectedContacts = new List<Contact> { contact };
            OkObjectResult objectResult = (OkObjectResult)result;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeEquivalentTo(expectedContacts);
        }

        [Fact]
        public async void ContactController_GetContactById_ReturnOK()
        {
            //Arrange
            var contacts = A.Fake<List<Contact>>();
            A.CallTo(() => _contactRepository.GetContacts()).Returns(Task.FromResult(contacts));
            var controller = new ContactController(_contactRepository);

            //Act
            var result = await controller.GetContactById(0);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void ContactController_GetContactById_ReturnCorrectContact()
        {
            //Arrange
            var expectedContact = new Contact() { Id = 3, FirstName = "Ken", LastName = "Barlow" };
            var contacts = new List<Contact>
            {
                new Contact() { Id = 1, FirstName="David", LastName="Platt"},
                new Contact() { Id = 2, FirstName="Jason", LastName="Grimshaw"},
                expectedContact
            };
            A.CallTo(() => _contactRepository.GetContacts()).Returns(Task.FromResult(contacts));
            var controller = new ContactController(_contactRepository);

            //Act
            var result = await controller.GetContactById(3);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
            OkObjectResult objectResult = (OkObjectResult)result;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeEquivalentTo(expectedContact);
        }
    }
}
