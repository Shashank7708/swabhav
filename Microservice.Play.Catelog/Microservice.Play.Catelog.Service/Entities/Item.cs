
using MongoDB.Bson.Serialization.Attributes;
using Play.Common.Entities;

namespace Microservice.Play.Catelog
{
    public class Item : IEntity
    {
        [BsonId, BsonElement("_id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
