using MicroserviceEgWithMongoDb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MicroserviceEgWithMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<Order> _ordersCollection;
        public OrderController(IConfiguration configuration) 
        {
            _config = configuration;
            var connString = _config.GetConnectionString("DbConn");
            var mongoUrl=MongoUrl.Create(connString);
            var mongoClient=new MongoClient(mongoUrl);
            var database=mongoClient.GetDatabase( mongoUrl.DatabaseName);
            _ordersCollection = database.GetCollection<Order>("order");

        }
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _ordersCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }
        [HttpGet]
        [Route("{orderId}")]
        public async Task<Order> GetOrderBasedOnId(string orderId)
        {
            var filterDefination = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            return await _ordersCollection.Find(filterDefination).SingleOrDefaultAsync();
        }
        [HttpPost]
        public async Task<bool> Create(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);
            return true;
        }
        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            var filterDefination=Builders<Order>.Filter.Eq(x=>x.OrderId,order.OrderId);
            await _ordersCollection.ReplaceOneAsync(filterDefination, order);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete/{orderId}")]
        public async Task<ActionResult> Delete(string orderId)
        {
            FilterDefinition<Order> filterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            await _ordersCollection.DeleteOneAsync(filterDefinition);
            return Ok();

        }
    }
}
