using Fridge.ProductsService.Configuration;
using Fridge.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fridge.ProductsService.EF
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
