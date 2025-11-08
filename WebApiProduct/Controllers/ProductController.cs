using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiProduct.Repository;
using WebApiProduct.ViewModels;

namespace WebApiProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository<Product>   _repository;
        public ProductController(IRepository<Product> repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAll()
        {
           var items=await _repository.GetAllAsycn();
            if(items.Count<=0)
                return NoContent();
            string json = JsonSerializer.Serialize(items);
            return Ok(json);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductView obj)
        {
            if (ModelState.IsValid)
            {
                var product = new Product { Name = obj.Name, Price = obj.Price };
                var result=await _repository.AddAsync(product);
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var itemtoDelete = await _repository.GetByIdAsync(id);
            if (itemtoDelete == null && String.IsNullOrEmpty(itemtoDelete.Name))
                return BadRequest("Something went wrong");
            var result=await _repository.DeleteAsync(itemtoDelete);
            return Ok(result);  
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] ProductView obj)
        {
            if (ModelState.IsValid)
            {
                var modelToUpdate = await _repository.GetByIdAsync(id);
                modelToUpdate.Name = obj.Name;
                modelToUpdate.Price = obj.Price;
                var result = await _repository.UpdateAsync(modelToUpdate);
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }


    }
}
