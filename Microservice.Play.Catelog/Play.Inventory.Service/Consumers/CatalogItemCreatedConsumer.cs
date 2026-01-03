using MassTransit;
using Play.Common.Repositories;
using Play.Inventory.Service.Entities;
using static Play.Catalog.Contracts.Contract;

namespace Play.Inventory.Service.Consumers
{
    public class CatalogItemCreatedConsumer : IConsumer<CatalogItemCreated>
    {
        private readonly IRepository<CatalogItem> _repository;

        public CatalogItemCreatedConsumer(IRepository<CatalogItem> repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<CatalogItemCreated> context)
        {
            var message = context.Message;
            var item=await _repository.GetByIdAsync(message.ItemId);
            if (item!=null)
            {
                return;
            }
            item=new CatalogItem { Id=message.ItemId,Name=message.Name,Description=item.Description };
            await _repository.CreateAsync(item);
        }
    }
}
