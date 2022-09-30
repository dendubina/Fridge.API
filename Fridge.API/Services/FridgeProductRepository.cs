using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.FridgesMicroService.Services
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<FridgeProduct>> GetFridgeProducts(Guid fridgeId, bool trackChanges)
        {
            return await FindByCondition(x => x.FridgeId.Equals(fridgeId), trackChanges)
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<FridgeProduct> GetFridgeProduct(Guid fridgeId, Guid productId, bool trackChanges)
        {
            return await FindByCondition(x => x.FridgeId.Equals(fridgeId) && x.ProductId.Equals(productId), trackChanges)
                .Include(x => x.Product)
                .SingleOrDefaultAsync();
        }

        public async Task AddProductToFridge(Guid fridgeId, FridgeProduct fridgeProduct)
        {
            var productInFridge = await GetFridgeProduct(fridgeId, fridgeProduct.ProductId, trackChanges: true);

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
