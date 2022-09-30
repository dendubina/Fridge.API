using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fridge.ProductsService.Contracts;
using Fridge.ProductsService.EF;
using Fridge.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fridge.ProductsService.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsContext _dbContext;

        public ProductService(ProductsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
            => await _dbContext.Products.AsNoTracking().ToListAsync();

        public async Task<Product> GetProductAsync(Guid productId)
            => await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == productId);

        public async Task UpdateProduct(Product product)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }
}
