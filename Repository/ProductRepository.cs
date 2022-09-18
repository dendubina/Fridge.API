using Contracts.Interfaces;
using Entities.EF;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
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

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Delete(product);
    }
}
