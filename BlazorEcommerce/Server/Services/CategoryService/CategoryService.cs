using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext context;

        public CategoryService(DataContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await this.context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories,
            };
        }
    }
}
