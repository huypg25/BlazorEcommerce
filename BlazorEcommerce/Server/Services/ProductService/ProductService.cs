using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService   
    {
        private readonly DataContext context;

        public ProductService(DataContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var products = await this.context.Products.ToListAsync();
            var response = new ServiceResponse<List<Product>>
            {
                Data = products,
                Message = "OK"
            };
            return response;
        }
    }
}
