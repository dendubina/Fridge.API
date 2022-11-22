using System;
using System.Collections.Generic;
using FridgeManager.FridgesMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeManager.FridgesMicroService.EF.Configuration
{
    public class ProductsConfig : IEntityTypeConfiguration<Product>
    {
        private static readonly List<Product> Products = new()
        {
            new Product
            {
                Id = Guid.Parse("08361c51-e528-4b91-96c6-d0e100e2da32"),
                Name = "Bread",
                DefaultQuantity = 5,
                ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg",
            },
            new Product
            {
                Id = Guid.Parse("69f75297-6ea9-41b0-b59b-97788e75d291"),
                Name = "Apple",
                DefaultQuantity = 10,
                ImageSource = "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg",
            },
            new Product
            {
                Id = Guid.Parse("027e90e0-1bae-47a1-a9e2-5e77d433a2a7"),
                Name = "Cheese",
                DefaultQuantity = 15,
                ImageSource = "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg",
            },
            new Product
            {
                Id = Guid.Parse("96895abc-efd8-4741-9d59-d62620a6d573"),
                Name = "Mashroom",
                DefaultQuantity = 11,
                ImageSource = "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg",
            },
            new Product
            {
                Id = Guid.Parse("99c007af-d4c8-4db0-9b7a-0b5f1149c113"),
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
