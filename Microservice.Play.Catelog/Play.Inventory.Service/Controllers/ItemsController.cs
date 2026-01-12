using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Play.Common.Repositories;
using Play.Inventory.Service.Clients;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<InventoryItem> _itemRepository;
        private readonly IRepository<CatalogItem> _catalogRepository;
        private readonly CatalogClient _catalogClient;
        public ItemsController(IRepository<InventoryItem> itemRepository, CatalogClient catalogclient, IRepository<CatalogItem> catalogRepository)
        {
            _itemRepository = itemRepository;
            _catalogClient = catalogclient;
            _catalogRepository = catalogRepository;
        }
        [HttpGet]
        [Route("GetAllAsync/{userId}")]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAllAsync(Guid userId)
        {
            if(userId == null || userId == Guid.Empty)
                return BadRequest();
            var items=await _itemRepository.GetAllAsync(x=>x.UserId==userId);
            if (!items.Any())
                return NotFound();
            //#######################################################
          
            var catalogItem = await _catalogClient.GetCatelogItemsAsync();

            var inventoryItemDtos = items.Select(inventoryItem =>          
            {
                var catalog = catalogItem.Single(x => x.Id == inventoryItem.CatalogItemId);
                if (catalog != null)
                {
                    return inventoryItem.AsDto(catalog.Name, catalog.Description);
                }
                return inventoryItem.AsDto("","");
            });
            return Ok(inventoryItemDtos);
        }

        [HttpGet]
        [Route("GetAllAsyncv2/{userId}")]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAllAsyncV2(Guid userId)
        {
            if (userId == null || userId == Guid.Empty)
                return BadRequest();
            var items = await _itemRepository.GetAllAsync(x => x.UserId == userId);
            if (!items.Any())
                return NotFound();

            //#######################################################
            /*
            var inventoryItemDtos =await Task.WhenAll( items.Select(async invItem =>
            {
                var catalogItem = await  _catalogRepository.GetByIdAsync(invItem.CatalogItemId);
                return invItem.AsDto(catalogItem.Name, catalogItem.Description);
            }));
            */

            var itemIds = items.Select(x => x.CatalogItemId);
            var calalogs = await _catalogRepository.GetAllAsync(x => itemIds.Contains(x.Id));
            var inventoryItemDtos = items.Select(invItem =>
            {
                var catalog = calalogs.Single(x => x.Id == invItem.CatalogItemId);
                return invItem.AsDto(catalog.Name, catalog.Description);
            });
            return Ok(inventoryItemDtos);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(GrantItemDto dto)
        {
            var inventoryItem = await _itemRepository.GetAsync(x => x.UserId == dto.UserId && x.CatalogItemId == dto.CatelogItemId);
            if (inventoryItem == null)
            {
                 inventoryItem = new InventoryItem()
                {
                    Id = Guid.NewGuid(),
                    UserId = dto.UserId,
                    CatalogItemId = dto.CatelogItemId,
                    Quantity = dto.Quantity,
                    AcquiredDate = DateTime.UtcNow
                };
                await _itemRepository.CreateAsync(inventoryItem);
            }
            else
            {
                inventoryItem.Quantity += dto.Quantity;
                await _itemRepository.UpdateAsync(inventoryItem);
            }
                return CreatedAtAction("GetAllAsync", new { userId = inventoryItem.UserId }, inventoryItem.AsDto("",""));
            
        }
    }
}
