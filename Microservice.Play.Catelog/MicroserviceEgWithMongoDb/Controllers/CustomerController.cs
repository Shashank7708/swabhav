using MicroserviceEgWithMongoDb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Security.Cryptography.X509Certificates;

namespace MicroserviceEgWithMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<Customer> _customerCollection;
        public CustomerController(IConfiguration config)
        {
            _config = config;
            var temp = _config.GetConnectionString("DbConn");
            var connString = temp.Replace("demo", "customer");
            var mongUrl=MongoUrl.Create(connString);
            var mongClient = new MongoClient(mongUrl);
            var database = mongClient.GetDatabase(mongUrl.DatabaseName);
            _customerCollection = database.GetCollection<Customer>("customer");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetALl()
        {
            FilterDefinition<Customer> filterDefination = Builders<Customer>.Filter.Empty;
            var customers = await _customerCollection.Find(filterDefination).ToListAsync();
            return customers;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            FilterDefinition<Customer> filterDefination=Builders<Customer>.Filter.Eq(x=>x.id,id);
            var customer = await _customerCollection.Find(filterDefination).SingleOrDefaultAsync();
            return Ok(customer);

        }
        [HttpPost]
        public async Task<ActionResult> Post(Customer customer)
        {
             await _customerCollection.InsertOneAsync(customer);
            return Ok(true);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Customer customer)
        {

            var filterDefination = Builders<Customer>.Filter.Eq(x => x.id, customer.id);
            await _customerCollection.ReplaceOneAsync(filterDefination, customer);
            return Ok(true);    
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (string id)
        {
            var filterDefination = Builders<Customer>.Filter.Eq(x => x.id, id);
            await _customerCollection.DeleteOneAsync(filterDefination);
            return Ok(true);    
        }



    }
}
