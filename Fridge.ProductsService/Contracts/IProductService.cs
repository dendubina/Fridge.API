using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.ProductsMicroService.EF.Entities;

namespace FridgeManager.ProductsMicroService.Contracts
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
