
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Play.Common.Repositories;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;
using static Play.Catalog.Contracts.Contract;

namespace Microservice.Play.Catelog.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        /*private static readonly List<ItemDto> items = new List<ItemDto>
        {
            new ItemDto(Guid.NewGuid(),"Potion","Restorvdsv sdv",5,DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"Antidote","Cures Potion",5,DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"Bronze Sword","Deals a small amount of damage",5,DateTimeOffset.UtcNow)
        };
        */


        private readonly IRepository<Item> _itemRepository;
        //private static int _requestCounter;

        private readonly IPublishEndpoint _publishEndpoint;

        public ItemsController(IRepository<Item> itemRepository, IPublishEndpoint publishEndpoint)
        {
            this._itemRepository= itemRepository;
            this._publishEndpoint= publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAsync()
        {
            /* To Check Policy timeout at Inventory.Service Project
            _requestCounter++;
            Console.WriteLine($"Request No {_requestCounter} Started:");
            if (_requestCounter <= 2)
            {
                Console.WriteLine($"Reqeest No {_requestCounter} Delayinng ....");
                await Task.Delay(10000);
            }
            else if (_requestCounter <= 4)
            {
                Console.WriteLine($"Reqeest No {_requestCounter}: 500 (Internal Server Error)....");
                return StatusCode(500);
            }
            */
            var items=(await _itemRepository.GetAllAsync());
            var itemDtos = items.Select(x => x.AsDto());

           // Console.WriteLine($"Request No {_requestCounter} Ended: 200 (OK)");
            return Ok(itemDtos);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<ItemDto>> GetById(Guid id)
        {
            var item = await _itemRepository.GetByIdAsync(id);

            if (item==null)
                return NotFound();

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> Post(CreateItemDto CreateitemObj)
        {
            if (ModelState.IsValid)
            {
                var itemObj = (new ItemDto(Guid.NewGuid(), CreateitemObj.Name, CreateitemObj.Description, CreateitemObj.Price, DateTime.UtcNow)).ItemDtoToItem();
                await _itemRepository.CreateAsync(itemObj);

                //Publish
                await _publishEndpoint.Publish(new CatalogItemCreated(itemObj.Id, itemObj.Name, itemObj.Description));

                return CreatedAtAction("GetById", new { id = itemObj.Id }, itemObj.AsDto() with { Id=Guid.Empty});
            }
            return new JsonResult(new { succes = false, message = "Invalid Data" });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateItemDto obj)
        {
            var item=await _itemRepository.GetByIdAsync(id);
            if (item == null)
                return BadRequest("Something went wrong");

            var updatedItem = item.AsDto() with
                {
                    Name = obj.Name,
                    Description = obj.Description,
                    Price = obj.Price
                };
             await _itemRepository.UpdateAsync(updatedItem.ItemDtoToItem());

            await _publishEndpoint.Publish(new CatalogItemUpdated(updatedItem.Id,updatedItem.Name,updatedItem.Description));  
               // var index=items.FindIndex(x => x.Id == updatedItem.Id);
               // items[index]=updatedItem;
             return CreatedAtAction($"GetById",new {id=updatedItem.Id}, updatedItem with { Id=Guid.Empty});
            
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return BadRequest();

            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            await _itemRepository.RemoveAsync(item.Id);
            
            await _publishEndpoint.Publish(new CatalogItemDeleted(id));
            /*var index=items.FindIndex(x=>x.Id==id);
            if (index >=0)
            {
                items.RemoveAt(index);
                return NoContent();
            }
            */
            return Ok();
        }
    }
}
