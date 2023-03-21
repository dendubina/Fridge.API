using FridgesService.EF.Configuration;
using FridgesService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgesService.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Fridge> Fridges { get; set; }

        public DbSet<FridgeModel> FridgeModels { get; set; }

        public DbSet<FridgeProduct> FridgeProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductsConfig());
        }
    }
}
