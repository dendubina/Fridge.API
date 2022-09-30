using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FridgeManager.ProductsMicroService.Contracts;
using FridgeManager.ProductsMicroService.EF;
using FridgeManager.ProductsMicroService.EF.Entities;
using FridgeManager.Shared.Models;
using FridgeManager.Shared.Models.Constants;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.ProductsMicroService.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsContext _dbContext;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public ProductService(ProductsContext dbContext, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _dbContext = dbContext;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
            => await _dbContext.Products.AsNoTracking().ToListAsync();

        public async Task<Product> GetProductAsync(Guid productId)
            => await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == productId);

        public async Task UpdateProduct(Product product)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            _dbContext.Products.Update(product);
            await _publishEndpoint.Publish(MapSharedProduct(product, ActionType.Update));
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            await _dbContext.Products.AddAsync(product);
            await _publishEndpoint.Publish(MapSharedProduct(product, ActionType.Create));
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            _dbContext.Products.Remove(product);
            await _publishEndpoint.Publish(MapSharedProduct(product, ActionType.Delete));
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        private SharedProduct MapSharedProduct(Product product, ActionType operation)
        {
            return _mapper.Map<Product, SharedProduct>(product,
                options => options.Items[nameof(ActionType)] = operation);
        }
    }
}
