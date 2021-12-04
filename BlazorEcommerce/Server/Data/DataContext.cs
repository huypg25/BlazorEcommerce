using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "loremasdasdasdasd",
                        Decription = "aaaaaaaaaaaaa",
                        ImageUrl = "https://static.wikia.nocookie.net/tomandjerry/images/1/14/Tom_Cat_2.png/revision/latest?cb=20200412163656",
                        Price = 99.9m
                    });
        }
        public DbSet<Product> Products{get;set;}
    }
}
