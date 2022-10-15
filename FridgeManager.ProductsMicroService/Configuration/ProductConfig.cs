using System;
using System.Collections.Generic;
using FridgeManager.ProductsMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeManager.ProductsMicroService.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        private static readonly List<Product> Products = new()
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Bread",
                DefaultQuantity = 5,
                ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg",
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                DefaultQuantity = 10,
                ImageSource = "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg",
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Cheese",
                DefaultQuantity = 15,
                ImageSource = "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg",
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Mashroom",
                DefaultQuantity = 11,
                ImageSource = "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg",
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Fish",
                DefaultQuantity = 3,
                ImageSource = "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg",
            },
        };

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(Products);
        }
    }
}
