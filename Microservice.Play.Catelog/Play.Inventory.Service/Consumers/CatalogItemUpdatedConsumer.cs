using MassTransit;
using Play.Common.Repositories;
using Play.Inventory.Service.Entities;
using static Play.Catalog.Contracts.Contract;

namespace Play.Inventory.Service.Consumers
{
    public class CatalogItemUpdatedConsumer : IConsumer<CatalogItemUpdated>
    {
        public readonly IRepository<CatalogItem> _repository;
        public CatalogItemUpdatedConsumer(IRepository<CatalogItem> repository)
        {
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<CatalogItemUpdated> context)
        {
            var message=context.Message;
            var item =await _repository.GetByIdAsync(message.ItemId);
            if (item == null)
            {
                item=new CatalogItem() { Id=message.ItemId,Name=message.Name,Description=message.Description };
                await _repository.CreateAsync(item);
            }
            else
            {
                item.Name = message.Name;
                item.Description= message.Description;
                await _repository.UpdateAsync(item);
            }
           
        }
    }
}
