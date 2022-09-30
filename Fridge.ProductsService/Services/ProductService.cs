using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FridgeManager.ProductsMicroService.Contracts;
using FridgeManager.ProductsMicroService.EF;
using FridgeManager.ProductsMicroService.EF.Entities;
using FridgeManager.Shared.Models;
using FridgeManager.Shared.Models.Constants;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.ProductsMicroService.Services
{
    public class ProductService : IProductService
    {
        public Task CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
