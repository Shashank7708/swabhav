using GenericRepo.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Repository.Repository;
using System.Linq.Expressions;

namespace GenericRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> _repository)
        {
            this._repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
           var result=await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetProductBasedOnId(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("No Such Product FOund");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductVieModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product p=new Product { Name=productViewModel.Name,Description=productViewModel.Description,Price=productViewModel.price };
                var createdproduct =await _repository.AddAsync(p);
                return Ok(createdproduct);
            }
            return BadRequest("Something went wrong");
        }
        [HttpPut,Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductVieModel productVieModel)
        {
            if (ModelState.IsValid)
            {
                var product=await _repository.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound("No Such Product FOund");
                }
                product.Name = productVieModel.Name;
                product.Description = productVieModel.Description;
                product.Price = productVieModel.price;
                var result=await _repository.UpdateAsync(product);
                return Ok(result);
            }
            return NotFound();
        }
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound("No Such Product Found");
                }
                
                 await _repository.DeleteAsync(product);
                return Ok("Deleted Successfully");
            }
            return NotFound();
        }
    }
}
