using System;
using System.Linq;
using System.Threading;
using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using FridgeManager.Shared.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProductsService.Contracts;
using ProductsService.EF;
using ProductsService.EF.Entities;
using ProductsService.Mapper;
using ProductsService.Services;
using ProductsService.Tests.Fixtures;
using Xunit;

namespace ProductsService.Tests.Services.Tests
{

    public class ProductsServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly Fixture _fixture = new();
        private readonly IProductService _productsService;
        private readonly ProductsContext _dbContext;
        private readonly Mock<IPublishEndpoint> _publishEndpointMock;
        private readonly MapperConfiguration _mapperConfig = new(x => x.AddProfile(typeof(MapperProfile)));

        public ProductsServiceTests(DatabaseFixture dbFixture)
        {
            _publishEndpointMock = new Mock<IPublishEndpoint>();
            _publishEndpointMock.Setup(x => x.Publish(It.IsAny<SharedProduct>(), It.IsAny<CancellationToken>()));

            _dbContext = dbFixture.DbContext;

            _productsService = new ProductService(dbFixture.DbContext, _publishEndpointMock.Object, _mapperConfig.CreateMapper());
        }

        [Fact]
        public async void GetAllProductsAsync_Should_Return_All_Products_In_Database()
        {
            //Arrange
            var productsInDb = await _dbContext.Products.ToListAsync();

            //Act
            var actualCount = await _productsService.GetAllProductsAsync();

            //Assert
            actualCount.Count().Should().Be(productsInDb.Count);
        }

        [Fact]
        public async void GetProductAsync_Should_Return_Null_When_Product_NotFound()
        {
            //Act
            var actual = await _productsService.GetProductAsync(Guid.NewGuid());

            //Assert
            actual.Should().BeNull();
        }

        [Fact]
        public async void GetProductAsync_Should_Return_Expected_Product_When_Product_Found()
        {
            //Arrange
            var id = Guid.NewGuid();
            var product = _fixture.Build<Product>()
                .With(x => x.Id, id)
                .Create();
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            //Act
            var actual = await _productsService.GetProductAsync(id);

            //Assert
            actual.Should().BeEquivalentTo(product);
        }

        [Theory, AutoData]
        public async void UpdateProductAsync_Should_Update_Product(string newName, int newQuantity, string newImageSource)
        {
            //Arrange
            var productToUpdate = await _dbContext.Products.FirstAsync();
            productToUpdate.Name = newName;
            productToUpdate.DefaultQuantity = newQuantity;
            productToUpdate.ImageSource = newImageSource;

            //Act
            await _productsService.UpdateProductAsync(productToUpdate);

            //Assert
            var actualProduct = await _dbContext.Products.FirstAsync();

            actualProduct.Id.Should().Be(productToUpdate.Id);
            actualProduct.Name.Should().Be(newName);
            actualProduct.DefaultQuantity.Should().Be(newQuantity);
            actualProduct.ImageSource.Should().Be(newImageSource);
        }

        [Fact]
        public async void UpdateProductAsync_Should_Call_IPublishEndpoint()
        {
            //Arrange
            var product = await _dbContext.Products.FirstAsync();

            //Act
            await _productsService.UpdateProductAsync(product);

            //Assert
            _publishEndpointMock.Verify(x => x.Publish(It.IsAny<SharedProduct>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void CreateProductAsync_Should_Add_Product_To_Database()
        {
            //Arrange
            var productsCountBeforeCreating = await _dbContext.Products.CountAsync();
            var product = _fixture.Create<Product>();

            //Act
            await _productsService.CreateProductAsync(product);

            //Assert
            var actualCount = await _dbContext.Products.CountAsync();
            actualCount.Should().Be(productsCountBeforeCreating + 1);
        }

        [Fact]
        public async void CreateProductAsync_Should_Call_IPublishEndpoint()
        {
            //Act
            await _productsService.CreateProductAsync(_fixture.Create<Product>());

            //Assert
            _publishEndpointMock.Verify(x => x.Publish(It.IsAny<SharedProduct>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void DeleteProductAsync_Should_Remove_Product_From_Database()
        {
            //Arrange
            var productToDelete = await _dbContext.Products.FirstAsync();

            //Act
            await _productsService.DeleteProductAsync(productToDelete);

            //Assert
            var actualProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id.Equals(productToDelete.Id));

            actualProduct.Should().BeNull();
        }

        [Fact]
        public async void DeleteProductAsync_Should_Call_IPublishEndpoint()
        {
            //Arrange
            var productToDelete = await _dbContext.Products.FirstAsync();

            //Act
            await _productsService.DeleteProductAsync(productToDelete);

            //Assert
            _publishEndpointMock.Verify(x => x.Publish(It.IsAny<SharedProduct>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
