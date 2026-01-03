using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MicroserviceEgWithMongoDb.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId,BsonElement("_id"),BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string OrderId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int CustomerId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime OrderedOn { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
