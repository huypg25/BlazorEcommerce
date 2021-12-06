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

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var result = await this.http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
            return result;
        }

        public async Task GetProducts()
        {
            var result = await this.http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            Products = result.Data;
        }
    }
}
