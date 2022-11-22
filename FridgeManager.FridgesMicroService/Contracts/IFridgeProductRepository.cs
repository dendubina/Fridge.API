using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.EF.Entities;


namespace FridgeManager.FridgesMicroService.Contracts
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProduct>> GetFridgeProductsAsync(Guid fridgeId, bool trackChanges);

        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeId, Guid productId, bool trackChanges);

        Task AddProductToFridgeAsync(Guid fridgeId, FridgeProduct fridgeProduct);

        void DeleteProductFromFridge(FridgeProduct fridgeProduct);
    }
}
