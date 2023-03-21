using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgesService.EF.Entities;

namespace FridgesService.Contracts
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProduct>> GetFridgeProductsAsync(Guid fridgeId, bool trackChanges);

        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeId, Guid productId, bool trackChanges);

        Task AddProductToFridgeAsync(Guid fridgeId, FridgeProduct fridgeProduct);

        void DeleteProductFromFridge(FridgeProduct fridgeProduct);
    }
}
