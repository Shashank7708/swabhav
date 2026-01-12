namespace Play.Inventory.Service
{
    public record GrantItemDto(Guid UserId, Guid CatelogItemId, int Quantity);
    public record InventoryItemDto(Guid CatelogItemId, string Name,string Description,int Quantity, DateTimeOffset AcquiredDate);

    //Catelog Dtos
    public record CatelogItemDto(Guid Id, string Name, string Description);

}
