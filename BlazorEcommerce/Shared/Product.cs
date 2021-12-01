using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
