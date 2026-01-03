using MongoDB.Bson.Serialization.Attributes;
using Play.Common.Entities;

namespace Play.Inventory.Service.Entities
{
    public class InventoryItem : IEntity
    {
        [BsonId,BsonElement("_id")]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset AcquiredDate { get; set; }
    }
}
