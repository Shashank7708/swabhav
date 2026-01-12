using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MicroserviceEgWithMongoDb.Models
{
    [Serializable,BsonIgnoreExtraElements]
    public class Customer
    {
        [BsonId,BsonElement("_id"),BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("name"),BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; }
        [BsonElement("email"),BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; }
        [BsonElement("phone_no"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [Required]
        [StringLength(10,MinimumLength =10)]
        public string Phone { get; set; }
    }
}
