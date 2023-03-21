using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsService.EF.Entities;

namespace ProductsService.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductAsync(Guid productId);

        Task UpdateProductAsync(Product product);

        Task CreateProductAsync(Product product);

        Task DeleteProductAsync(Product product);
    }
}
