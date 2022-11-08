using FridgeManager.FridgesMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.FridgesMicroService.EF
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
    }
}
