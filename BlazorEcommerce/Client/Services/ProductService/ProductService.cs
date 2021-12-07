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
        public string Message { get; set; } = "Loading ...";

        public event Action ProductChanged;

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var result = await this.http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
            return result;
        }

        public async Task GetProducts(string categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await this.http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
                await this.http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/Category/{categoryUrl}");
            Products = result.Data;
            ProductChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await this.http
               .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await this.http
                .GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            Products = result.Data;
            if(Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductChanged.Invoke();
        }
    }
}
