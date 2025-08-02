using DotNetCorePart.Model;
using DotNetCorePart.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCorePart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository productRepository)
        {
            this._repository= productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var list = await _repository.GetProducts();
            if (list != null && list.Count > 0)
                return Ok(list);
            return BadRequest("Something Went Wrong");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProducts(int id)
        {
            var product=await _repository.GetProductOnId(id);
            if (product != null)
                return Ok(product);
            return BadRequest("Something went wrong");
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                return Ok( await _repository.AddProduct(p));
            }
            return BadRequest("Something went Wrong");
        }
    }
}
