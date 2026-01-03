using Play.Inventory.Service.Entities;
using System.Runtime.CompilerServices;

namespace Play.Inventory.Service
{
    public static class Extension
    {
        public static InventoryItemDto AsDto(this InventoryItem invItem, string name,string description) 
        {
            return new InventoryItemDto(invItem.CatalogItemId,name,description, invItem.Quantity, invItem.AcquiredDate);
        }
    }
}
