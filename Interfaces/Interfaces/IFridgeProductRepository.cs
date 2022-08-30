using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProduct>> GetFridgeProducts(Guid fridgeId, bool trackChanges);

        Task<FridgeProduct> GetFridgeProduct(Guid fridgeId, Guid productId, bool trackChanges);

        Task AddProductToFridge(Guid fridgeId, FridgeProduct fridgeProduct);

        void DeleteProductFromFridge(FridgeProduct fridgeProduct);
    }
}
