using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient http;

        public CategoryService(HttpClient http)
        {
            this.http = http;
        }
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var response = await this.http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            Categories = response.Data;
        }
    }
}
 