using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.FridgesMicroService.Services
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                        .ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid productId, bool trackChanges)
        {
            return await FindByCondition(x => x.Id.Equals(productId), trackChanges)
                        .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> FindByIdsAsync(IEnumerable<Guid> productIds)
        {
            return await FindByCondition(x => productIds.Contains(x.Id), trackChanges: false).ToListAsync();
        }

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Delete(product);
    }
}
