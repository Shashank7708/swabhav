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

namespace TenentApplicationTest
{
    public class TenentControllerTest
    {
        private readonly Mock<IEfRespository<Tenent>> _tenentRepo;
        private readonly TenentController _tenentcontroller;
        public TenentControllerTest()
        {
            _tenentRepo = new Mock<IEfRespository<Tenent>>();
            _tenentcontroller = new TenentController(_tenentRepo.Object);
        }
        
        [Fact]
        public async void AddTenentTest()
        {
            DtoTenet tenent = new DtoTenet { Name = "demo",TenentStrength=100 };
            Tenent tenent1 = new Tenent { Name = "demo" };
            _tenentRepo.Setup(x => x.Add(tenent1));
            var result = await _tenentcontroller.AddTenet(tenent);
            var okResult = result as OkObjectResult;
            //assert
           Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK,okResult.StatusCode);
        }

        [Fact]
        public async Task DeleteTenent_SHouldReturnOk()
        {
          var tenentid = Guid.NewGuid();
            var tenent = new Tenent();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _tenentRepo.Setup(x => x.Remove(tenent));

            var result = await _tenentcontroller.DeleteTenent(tenentid);

            var okResult = result as OkObjectResult;
            //assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task PutTenent_SHouldReturnOk()
        {
            var tenentid = Guid.NewGuid();
            var tenent = new Tenent();
            var dtotenent = new DtoTenet();
            _tenentRepo.Setup(x => x.GetById(tenentid)).ReturnsAsync(tenent);
            _tenentRepo.Setup(x => x.update(tenent));

            var result = await _tenentcontroller.UpdateTenent(tenentid,dtotenent);

            var okResult = result as OkObjectResult;
            //assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }



        [Fact]
      public async Task GetTenent()
        {
            var tenent = new Tenent();
            var id = Guid.NewGuid();
            _tenentRepo.Setup(x => x.GetById(id)).ReturnsAsync(tenent);

            var result = await _tenentcontroller.GetTenetAsPerId(id);
            //var okresult = result as OkObjectResult;
            Assert.Equal(tenent, result.Value);

        }
       
        [Fact]
         public async Task GetAllTenentIfExist()
        {
            var tenents = new List<Tenent>();
            _tenentRepo.Setup(x => x.GetAll()).ReturnsAsync(tenents);

            //Act
            var result = await _tenentcontroller.GetTenents();

            Assert.Equal(tenents.Count, result.Count);

        }
        
        




    }
}
