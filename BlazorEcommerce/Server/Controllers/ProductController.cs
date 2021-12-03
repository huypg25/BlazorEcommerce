using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            new Product{
                Id = 1,
                Title = "loremasdasdasdasd",
                Decription = "aaaaaaaaaaaaa",
                ImageUrl = "https://static.wikia.nocookie.net/tomandjerry/images/1/14/Tom_Cat_2.png/revision/latest?cb=20200412163656",
                Price = 99.9m
            }
        };
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            return Ok(Products);
        }
    }
}
