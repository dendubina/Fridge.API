using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fridge.ProductsService.Contracts;
using Fridge.ProductsService.EF;
using Fridge.ProductsService.EF.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Fridge.ProductsService.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsContext _dbContext;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductService(ProductsContext dbContext, IPublishEndpoint publishEndpoint)
        {
            _dbContext = dbContext;
            _publishEndpoint = publishEndpoint;
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

            await _dbContext.Products.AddAsync(product);
            await _publishEndpoint.Publish(product);
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
