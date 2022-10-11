using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.EF.Entities;

namespace FridgeManager.FridgesMicroService.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);

        Task<Product> GetProductAsync(Guid productId, bool trackChanges);

        Task<IEnumerable<Product>> FindByIdsAsync(IEnumerable<Guid> productIds);

        void CreateProduct(Product product);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);
    }
}
