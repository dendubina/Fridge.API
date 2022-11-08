using System.Threading.Tasks;
using FridgeManager.ProductsMicroService.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FridgeManager.ProductsMicroService.Tests.Fixtures
{
    public class DatabaseFixture : IAsyncLifetime
    {
        public ProductsContext DbContext;

        public async Task InitializeAsync()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ProductsTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            DbContext = new ProductsContext(options);
            await DbContext.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await DbContext.Database.EnsureDeletedAsync();
            await DbContext.DisposeAsync();
        }
    }
}
