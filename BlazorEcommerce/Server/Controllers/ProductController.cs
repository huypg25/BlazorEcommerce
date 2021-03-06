using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Services.ProductService;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController( IProductService productService)
        {

            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var response = await this.productService.GetProducts();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductById(int id)
        {
            var result = await this.productService.GetProductById(id);
            return Ok(result);
        }
        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await this.productService.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }
        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText)
        {
            var result = await this.productService.SearchProducts(searchText);
            return Ok(result);
        }
        [HttpGet("SearchSuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await this.productService.GetProductSearchSuggestions(searchText);
            return Ok(result);
        }
    }
}
