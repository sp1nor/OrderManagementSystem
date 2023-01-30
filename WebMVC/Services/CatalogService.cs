using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Extensions;
using WebMVC.Model;

namespace WebMVC.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client, ILogger<CatalogService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetCatalog()
        {
            var response = await _client.GetAsync($"/gateway/product");
            return await response.ReadContentAs<List<ProductModel>>();
        }
    }
}
