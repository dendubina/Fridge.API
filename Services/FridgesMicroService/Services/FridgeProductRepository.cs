using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgesService.Contracts;
using FridgesService.EF;
using FridgesService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgesService.Services
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<FridgeProduct>> GetFridgeProductsAsync(Guid fridgeId, bool trackChanges)
            => await FindByCondition(x => x.FridgeId.Equals(fridgeId), trackChanges)
                    .Include(x => x.Product)
                    .ToListAsync();

        public async Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeId, Guid productId, bool trackChanges)
            => await FindByCondition(x => x.FridgeId.Equals(fridgeId) && x.ProductId.Equals(productId), trackChanges)
                .Include(x => x.Product)
                .FirstOrDefaultAsync();

        public async Task AddProductToFridgeAsync(Guid fridgeId, FridgeProduct fridgeProduct)
        {
            var productInFridge = await GetFridgeProductAsync(fridgeId, fridgeProduct.ProductId, trackChanges: true);

            if (productInFridge is not null)
            {
                productInFridge.Quantity += fridgeProduct.Quantity;
                return;
            }

            fridgeProduct.FridgeId = fridgeId;

            Create(fridgeProduct);
        }

        public void DeleteProductFromFridge(FridgeProduct fridgeProduct)
            => Delete(fridgeProduct);
    }
}
