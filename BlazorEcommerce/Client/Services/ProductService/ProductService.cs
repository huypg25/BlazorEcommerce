using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient http;

        public ProductService(HttpClient http)
        {
            this.http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();  

        public async Task GetProducts()
        {
            var result = await this.http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
            Products = result.Data;
        }
    }
}
