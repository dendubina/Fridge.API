using FridgeManager.ProductsMicroService.Configuration;
using FridgeManager.ProductsMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.ProductsMicroService.EF
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
