using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsService.Contracts;
using ProductsService.Controllers;
using ProductsService.EF.Entities;
using ProductsService.Mapper;
using ProductsService.Models;
using Xunit;

namespace ProductsService.Tests.Controllers.Tests
{
    public class ProductsControllerTests
    {
        private readonly IFixture _fixture;
        private readonly ProductsController _controller;
        private readonly Mock<IProductService> _mockProductService = new();
        private readonly Mock<IImageService> _mockImageService = new();
        private readonly IMapper _mapper;

        public ProductsControllerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            var mapperConfig = new MapperConfiguration(x => x.AddProfile(typeof(MapperProfile)));
            _mapper = mapperConfig.CreateMapper();

            _controller = new ProductsController(_mockProductService.Object, _mapper, _mockImageService.Object);
        }

        [Fact]
        public async void GetAllProducts_Should_Return_Empty_Collection_When_Data_Not_Found()
        {
            //Arrange
            _mockProductService.Setup(x => x.GetAllProductsAsync())
                .ReturnsAsync(new List<Product>());

            //Act
            var response = await _controller.GetAllProducts() as OkObjectResult;
            var actual = response?.Value as IEnumerable<ProductForReturn>;

            //Assert
            actual.Should().HaveCount(0);
        }

        [Fact]
        public async void GetAllProducts_Should_Return_Expected_Data_When_Data_Exists()
        {
            //Arrange
            var dataSample = _fixture.CreateMany<Product>();
            var expected = _mapper.Map<IEnumerable<ProductForReturn>>(dataSample);

            _mockProductService.Setup(x => x.GetAllProductsAsync())
                .ReturnsAsync(dataSample);

            //Act
            var response = await _controller.GetAllProducts() as OkObjectResult;
            var actual = response?.Value as IEnumerable<ProductForReturn>;

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void GetProduct_Should_Return_NotFound_When_Product_NotFound()
        {
            //Arrange
            Product expected = null;

            _mockProductService.Setup(x => x.GetProductAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expected);

            //Act
            var response = await _controller.GetProduct(Guid.NewGuid());

            //Assert
            response.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public async void GetProduct_Should_Return_Expected_Value_When_Product_Found()
        {
            //Arrange
            var product = _fixture.Create<Product>();
            _mockProductService.Setup(x => x.GetProductAsync(It.IsAny<Guid>()))
                .ReturnsAsync(product);

            var expected = _mapper.Map<ProductForReturn>(product);

            //Act
            var response = await _controller.GetProduct(Guid.NewGuid()) as OkObjectResult;
            var actual = response?.Value as ProductForReturn;

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void CreateProduct_Should_Not_Call_ImageService_When_Image_Not_Specified()
        {
            //Arrange
            var model = _fixture
                .Build<ProductForManipulation>()
                .Without(x => x.Image)
                .Create();

            _mockProductService.Setup(x => x.CreateProductAsync(It.IsAny<Product>()));

            //Act
            await _controller.CreateProduct(model);

            //Assert
            _mockImageService.Verify(x => x.AddImageGetPath(It.IsAny<IFormFile>()), Times.Never);
        }

        [Fact]
        public async void CreateProduct_Should_Call_ImageService_When_Image_Specified()
        {
            //Arrange
            var model = _fixture.Create<ProductForManipulation>();
            _mockProductService.Setup(x => x.CreateProductAsync(It.IsAny<Product>()));

            //Act
            await _controller.CreateProduct(model);

            //Assert
            _mockImageService.Verify(x => x.AddImageGetPath(It.IsAny<IFormFile>()), Times.Once);
        }

        [Fact]
        public async void CreateProduct_Should_Return_CreatedAtRoute_Result_When_Valid_Parameter()
        {
            //Arrange
            _mockProductService.Setup(x => x.CreateProductAsync(It.IsAny<Product>()));

            //Act
            var actual = await _controller.CreateProduct(_fixture.Create<ProductForManipulation>());

            //Assert
            actual.Should().BeOfType(typeof(CreatedAtRouteResult));
        }

        [Fact]
        public async void DeleteProduct_Should_Return_NoContent()
        {
            //Arrange
            _mockProductService.Setup(x => x.DeleteProductAsync(It.IsAny<Product>()));

            //Act
            var actual = await _controller.DeleteProduct(Guid.NewGuid());

            //Assert
            actual.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public async void DeleteProduct_Should_Not_Call_Delete_When_Product_Not_Found()
        {
            //Arrange
            _mockProductService.Setup(x => x.DeleteProductAsync(It.IsAny<Product>()));

            //Act
            await _controller.DeleteProduct(Guid.NewGuid());

            //Assert
            _mockProductService.Verify(x => x.DeleteProductAsync(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async void DeleteProduct_Should_Call_Delete_When_Product_Found()
        {
            //Arrange
            _mockProductService.Setup(x => x.GetProductAsync(It.IsAny<Guid>()))
                .ReturnsAsync(_fixture.Create<Product>());

            //Act
            await _controller.DeleteProduct(Guid.NewGuid());

            //Assert
            _mockProductService.Verify(x => x.DeleteProductAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async void UpdateProduct_Should_Return_NoContent_When_Valid_Parameters()
        {
            //Arrange
            _mockProductService.Setup(x => x.GetProductAsync(It.IsAny<Guid>()))
                .ReturnsAsync(_fixture.Create<Product>());

            //Act
            var actual = await _controller.UpdateProduct(Guid.NewGuid(), _fixture.Create<ProductForManipulation>());

            //Assert
            actual.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public async void UpdateProduct_Should_Return_NotFound_When_Product_NotFound()
        {
            //Arrange
            _mockProductService.Setup(x => x.GetProductAsync(It.IsAny<Guid>()));

            //Act
            var actual = await _controller.UpdateProduct(Guid.NewGuid(), _fixture.Create<ProductForManipulation>());

            //Assert
            actual.Should().BeOfType(typeof(NotFoundResult));
        }
    }
}
