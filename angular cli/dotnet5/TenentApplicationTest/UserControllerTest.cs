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
   public class UserControllerTest
    {
        private UserController _userController;
        private Mock<IEfRespository<User>> _userRepo;
        private Mock<IEfRespository<Tenent>> _tenentRepo;
        private Mock<ICustomTokenManager> _tokenMananger;

        public UserControllerTest()
        {
            _userRepo = new Mock<IEfRespository<User>>();
            _tenentRepo = new Mock<IEfRespository<Tenent>>();
            _tokenMananger = new Mock<ICustomTokenManager>();
            _userController = new UserController(_tokenMananger.Object,_tenentRepo.Object, _userRepo.Object);
        }

        [Fact]
        public async Task AddUser()
        {   //Arrange
            var tenentid = Guid.NewGuid();
            var tenent = new Tenent();
            var dtouser = new DtoUser();
            var user = new User();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _userRepo.Setup(x => x.Add(user));

            //Act
            var result = await _userController.AddUser(dtouser,tenentid);
            var okresult = result as OkObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }


        [Fact]
        public async Task DeleteUser_ShouldReturnOK()
        {
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var user = new User();
            var tenent = new Tenent();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _userRepo.Setup(x => x.GetById(userid)).ReturnsAsync(user);
            _userRepo.Setup(x => x.Remove(user));

            var result = await _userController.DeleteUser(tenentid, userid);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }

        [Fact]
        public async Task PutUser_ShouldReturnOK()
        {
            var tenentid = Guid.NewGuid();
            var userid = Guid.NewGuid();
            var user = new User();
            var dtouser = new DtoUser();
            var tenent = new Tenent();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _userRepo.Setup(x => x.GetById(userid)).ReturnsAsync(user);
            _userRepo.Setup(x => x.FirstOrDefault(x=>x.Id==userid && x.Tenent.Id==tenentid)).ReturnsAsync(user);
            _userRepo.Setup(x => x.update(user));


            var result = await _userController.UpdateUser(tenentid, userid,dtouser);
            var okresult = result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okresult.StatusCode);
        }

        [Fact]
        public async Task GetUserOfTenent_ShouldReturnListOfUser()
        {
            var tenetid = Guid.NewGuid();
            var tenent=new Tenent();
            List<User> users = new List<User>();

            _tenentRepo.Setup(x => x.GetById(tenetid)).ReturnsAsync(tenent);
            _userRepo.Setup(x => x.GetListBasedOnCondition(y => y.Tenent.Id == tenetid)).ReturnsAsync(users);

            var result = await _userController.GetUsersOfATenent(tenetid);

            Assert.Equal(users, result.Value);
        }

    }
}
