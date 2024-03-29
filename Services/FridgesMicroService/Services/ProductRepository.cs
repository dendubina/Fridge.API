﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgesService.Contracts;
using FridgesService.EF;
using FridgesService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgesService.Services
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Product> GetProductAsync(Guid productId, bool trackChanges)
            => await FindByCondition(x => x.Id.Equals(productId), trackChanges)
                    .SingleOrDefaultAsync();

        public async Task<IEnumerable<Product>> FindByIdsAsync(IEnumerable<Guid> productIds)
            => await FindByCondition(x => productIds.Contains(x.Id), trackChanges: false).ToListAsync();

        public void CreateProduct(Product product)
            => Create(product);

        public void DeleteProduct(Product product)
            => Delete(product);

        public void UpdateProduct(Product product)
            => DbContext.Products.Update(product);
    }
}
