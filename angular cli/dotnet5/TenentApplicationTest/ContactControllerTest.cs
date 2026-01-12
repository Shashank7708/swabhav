using System;
using Xunit;
using ContactAndAddressWebAPi.Controllers;
using ContactAndAddressApp_data.Repository;
using ContactAddressCore.Model;
using Microsoft.Extensions.DependencyInjection;
using ContactAndAddressWebAPi.DtoModel;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ContactAndAddressWebAPi.AuthentictionFlder;

namespace TenentApplicationTest
{
    public class ContactControllerTest
    {
        private ContactController _contactController;
        private Mock<IEfRespository<User>> _userRepo;
        private Mock<IEfRespository<Tenent>> _tenentRepo;
        private Mock<IEfRespository<Contact>> _contactRepo;

        public ContactControllerTest()
        {
            _userRepo = new Mock<IEfRespository<User>>();
            _tenentRepo = new Mock<IEfRespository<Tenent>>();
            _contactRepo = new Mock<IEfRespository<Contact>>();
            _contactController= new ContactController(_tenentRepo.Object, _userRepo.Object,_contactRepo.Object);
        }

        [Fact]
        public async Task AddContact()
        {
            var tenentid = Guid.NewGuid();
            var tenent = new Tenent();
            var userid = Guid.NewGuid();
            var user = new User();
            var contact = new Contact();
            var dtocontact = new DtoContact();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _userRepo.Setup(x => x.GetById(userid)).ReturnsAsync(user);
            _userRepo.Setup(x => x.FirstOrDefault(x => x.Tenent.Id == tenentid && x.Id==userid)).ReturnsAsync(user);
            _contactRepo.Setup(x => x.Add(contact));

            var result = await _contactController.PostContact(dtocontact, tenentid, userid);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }

        [Fact]
        public async Task DeleteContact()
        {
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var contactid = Guid.NewGuid();
            var contact = new Contact();
            _contactRepo.Setup(x => x.FirstOrDefault(y=> y.Id == contactid && y.User.Id == userid)).ReturnsAsync(contact);
            _contactRepo.Setup(x => x.Remove(contact));

            var result = await _contactController.DeleteContact(tenentid, userid, contactid);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }

        [Fact]
        public async Task PutContact_ShouldReturnOk()
        {
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var contactid = Guid.NewGuid();
            var tenent = new Tenent();
            var user = new User();
            var contact = new Contact();
            var dtocontact = new DtoContact();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _userRepo.Setup(x => x.GetById(userid)).ReturnsAsync(user);
            _contactRepo.Setup(x => x.GetById(contactid)).ReturnsAsync(contact);
            _contactRepo.Setup(x => x.FirstOrDefault(y => y.Id == contactid && y.User.Id == userid)).ReturnsAsync(contact);
            _contactRepo.Setup(x => x.update(contact));

            var result = await _contactController.UpdateContact(tenentid, userid, contactid, dtocontact);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);

        }

        [Fact]
        public async Task GetContactOfUser_ShouldReturnContactList()
        {
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var contactid = Guid.NewGuid();
            var tenent = new Tenent();
            var user = new User();
            var contact = new Contact();
            var dtocontact = new DtoContact();
            List<Contact> contacts = new List<Contact>();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _userRepo.Setup(x => x.GetById(userid)).ReturnsAsync(user);
            _contactRepo.Setup(x => x.GetListBasedOnCondition(y =>
                                                                  y.User.Tenent.Id == tenentid &&
                                                                  y.User.Id == userid)).ReturnsAsync(contacts);

            var result = await _contactController.GetAllContact(tenentid, userid);

            Assert.Equal(contacts, result.Value);

        }

    }
}
