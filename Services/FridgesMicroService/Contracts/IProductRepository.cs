using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgesService.EF.Entities;

namespace FridgesService.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(Guid productId, bool trackChanges);

        Task<IEnumerable<Product>> FindByIdsAsync(IEnumerable<Guid> productIds);

        void CreateProduct(Product product);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);
    }
}
