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
   public class AddressControllerTest
    {
        private AddressController _addressController;
    
        private Mock<IEfRespository<Contact>> _contactRepo;
        private Mock<IEfRespository<Address>> _addressRepo;

        public AddressControllerTest()
        {
            _contactRepo = new Mock<IEfRespository<Contact>>();
            _addressRepo = new Mock<IEfRespository<Address>>();
            _addressController= new AddressController(_contactRepo.Object,_addressRepo.Object);
        }

        [Fact]
        public async Task AddAddress_ShouldReturnOK()
        {
            var dtoaddress = new DtoAddress();
            var address = new Address();
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var contactid = Guid.NewGuid();
            var contact = new Contact();
            
            _contactRepo.Setup(x => x.FirstOrDefault(y => y.Id == contactid &&
                                                          y.User.Id == userid &&
                                                          y.User.Tenent.Id == tenentid)).ReturnsAsync(contact);
            _addressRepo.Setup(x => x.Add(address));

            var result = await _addressController.PostAddress(dtoaddress,tenentid,userid,contactid);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }

        [Fact]
        public async Task DeleteAddress_ShouldReturnOk()
        {
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var contactid = Guid.NewGuid();
            var addressid = Guid.NewGuid();
            var address = new Address();
            _addressRepo.Setup(x => x.FirstOrDefault(y => y.Id == addressid && y.Contact.Id == contactid
                                                                          && y.Contact.User.Id == userid && y.Contact.User.Tenent.Id == tenentid)).ReturnsAsync(address);
            _addressRepo.Setup(x => x.Remove(address));

            var result = await _addressController.DeleteAddress(addressid, tenentid, contactid, userid);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }

        [Fact]
        public async Task UpdateAddress_shouldReturnok()
        {
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var contactid = Guid.NewGuid();
            var addressid = Guid.NewGuid();
            var address = new Address();
            var dtoaddress = new DtoAddress();
            _addressRepo.Setup(y => y.FirstOrDefault(x => x.Id == addressid && x.Contact.Id == contactid
                                                                         && x.Contact.User.Id == userid && x.Contact.User.Tenent.Id == tenentid)).ReturnsAsync(address);
            _addressRepo.Setup(x => x.update(address));

            var result = await _addressController.PutAddress(addressid, tenentid, contactid, userid, dtoaddress);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }


        [Fact]
        public async Task GetAddressOfContact_ShouldReturnAddressList()
        {

            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var contactid = Guid.NewGuid();
           
            var contact = new Contact();
            List<Address> addresses = new List<Address>();
            _contactRepo.Setup(y => y.FirstOrDefault(x => x.Id == contactid && x.User.Id == userid && x.User.Tenent.Id == tenentid)).ReturnsAsync(contact);
            _addressRepo.Setup(y => y.GetListBasedOnCondition(x => x.Contact.Id == contactid && x.Contact.User.Id == userid
                                                                                          && x.Contact.User.Tenent.Id == tenentid)).ReturnsAsync(addresses);

            var result = await _addressController.GetAddress(tenentid, userid, contactid);

            Assert.Equal(addresses, result.Value);

        }



    }
}
