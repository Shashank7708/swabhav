using System.Collections.ObjectModel;

namespace Play.Inventory.Service.Clients
{
    public class CatalogClient
    {
        private readonly HttpClient _httpClient;
        public CatalogClient(HttpClient httpClient)
        {   
            this._httpClient=httpClient;

        }
        //Synchronous Communication
        public async Task<IReadOnlyCollection<CatelogItemDto>> GetCatelogItemsAsync()
        {
            var items=await _httpClient.GetFromJsonAsync<IReadOnlyCollection<CatelogItemDto>>("/api/Items");
            return items;
        }

    }
}
