using Fridge.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Fridge.Shared.Entities.Fridge> Fridges { get; set; }

        public DbSet<FridgeModel> FridgeModels { get; set; }

        public DbSet<FridgeProduct> FridgeProducts { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
