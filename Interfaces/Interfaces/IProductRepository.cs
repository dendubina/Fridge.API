using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.EF.Entities;

namespace Contracts.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);

        Task<Product> GetProductAsync(Guid productId, bool trackChanges);

        void CreateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
