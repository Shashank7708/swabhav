using Microservice.Play.Catelog;

namespace Microservice.Play.Catelog.Service
{
    public static  class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
        public static Item ItemDtoToItem(this ItemDto itemDto)
        {
            return new Item { Id = itemDto.Id, Name = itemDto.Name, Description = itemDto.Description, Price = itemDto.Price,CreatedDate = itemDto.CreatedDate };
        }
    }
}
