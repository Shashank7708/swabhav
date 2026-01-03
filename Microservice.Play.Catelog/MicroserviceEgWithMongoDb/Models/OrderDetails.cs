using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MicroserviceEgWithMongoDb.Models
{
    [Serializable,BsonIgnoreExtraElements]
    public class OrderDetails
    {
        [BsonId,BsonElement("_id"),BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int ProductId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Quantity { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal UnitPrice { get; set; }
    }
}
