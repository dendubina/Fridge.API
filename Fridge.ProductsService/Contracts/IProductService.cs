using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fridge.Shared.Entities;

namespace Fridge.ProductsService.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductAsync(Guid productId);

        Task UpdateProduct(Product product);

        Task CreateProduct(Product product);

        Task DeleteProduct(Product product);
    }
}
