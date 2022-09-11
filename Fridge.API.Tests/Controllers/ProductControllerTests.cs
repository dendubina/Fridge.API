using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.Products;
using Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Fridge.API.Controllers;
using Fridge.API.Validators.Products;

namespace Fridge.API.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IImageService> _mockImageService;
        private readonly IMapper _mapper;

        private ProductForManipulationDto _productForManipulationExample = new()
        {
            Name = "SomeName",
            DefaultQuantity = 1,
            Image = null
        };

        public ProductControllerTests()
        {
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MapperProfile.MapperProfile()));

            _mapper = mapperConfig.CreateMapper();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockImageService = new Mock<IImageService>();
        }

        [Fact]
        public async void GetAllProducts_Should_Return_Empty_Collection_When_Data_Not_Found()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.Products.GetAllProductsAsync(It.IsAny<bool>()))
                .ReturnsAsync(new List<Product>());

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper,  null, null);

            //Act
            var response = await controller.GetAllProducts() as OkObjectResult;
            var actual = response?.Value as IEnumerable<ProductForReturnDto>;

            //Assert
            actual.Should().HaveCount(0);
        }

        [Fact]
        public async void GetAllProducts_Should_Return_Expected_Data_When_Data_Exists()
        {
            //Arrange
            var dataSample = GetProductsEntitiesExampleData();
            var expected = _mapper.Map<IEnumerable<ProductForReturnDto>>(dataSample);

            _mockUnitOfWork.Setup(x => x.Products.GetAllProductsAsync(It.IsAny<bool>()))
                .ReturnsAsync(dataSample);

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper, null, null);

            //Act
            var response = await controller.GetAllProducts() as OkObjectResult;
            var actual = response?.Value as IEnumerable<ProductForReturnDto>;

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void GetProduct_Should_Return_NotFound_When_Product_NotFound()
        {
            //Arrange
            Product expected = null;

            _mockUnitOfWork.Setup(x => x.Products.GetProductAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(expected);

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper, null, null);

            //Act
            var response = await controller.GetProduct(Guid.NewGuid());

            //Assert
            response.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public async void GetProduct_Should_Return_Expected_Value_When_Product_Found()
        {
            //Arrange
            var product = GetProductsEntitiesExampleData().First();

            var expected = _mapper.Map<ProductForReturnDto>(product);

            _mockUnitOfWork.Setup(x => x.Products.GetProductAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(product);

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper, null, null);

            //Act
            var response = await controller.GetProduct(Guid.NewGuid()) as OkObjectResult;
            var actual = response?.Value as ProductForReturnDto;

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void CreateProduct_Should_Not_Call_ImageService_When_Image_Not_Specified()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.Products.CreateProduct(It.IsAny<Product>()));

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper, new ProductForManipulationDtoValidator(), _mockImageService.Object);

            //Act
            await controller.CreateProduct(_productForManipulationExample);

            //Assert
            _mockImageService.Verify(x => x.AddImageGetPath(It.IsAny<IFormFile>()), Times.Never);
        }

        [Fact]
        public async void CreateProduct_Should_Return_CreatedAtRoute_Result_When_Valid_Parameter()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.Products.CreateProduct(It.IsAny<Product>()));

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper, new ProductForManipulationDtoValidator(), _mockImageService.Object);

            //Act
            var actual = await controller.CreateProduct(_productForManipulationExample);

            //Assert
            actual.Should().BeOfType(typeof(CreatedAtRouteResult));
        }

        [Fact]
        public async void DeleteProduct_Should_Return_NoContent()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.Products.DeleteProduct(It.IsAny<Product>()));
            var controller = new ProductsController(_mockUnitOfWork.Object, null, null, null);

            //Act
            var actual = await controller.DeleteProduct(Guid.NewGuid());

            //Assert
            actual.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public async void DeleteProduct_Should_Not_Call_Delete_When_Product_Not_Found()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.Products.DeleteProduct(It.IsAny<Product>()));
            var controller = new ProductsController(_mockUnitOfWork.Object, null, null, null);

            //Act
            await controller.DeleteProduct(Guid.NewGuid());

            //Assert
            _mockUnitOfWork.Verify(x => x.Products.DeleteProduct(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async void UpdateProduct_Should_Return_NoContent_When_Valid_Parameters()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.Products.GetProductAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(new Product());

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper, new ProductForManipulationDtoValidator(), _mockImageService.Object);

            //Act
            var actual = await controller.UpdateProduct(Guid.NewGuid(), _productForManipulationExample);

            //Assert
            actual.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public async void UpdateProduct_Should_Return_NotFound_When_Product_NotFound()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.Products.GetProductAsync(It.IsAny<Guid>(), It.IsAny<bool>()));

            var controller = new ProductsController(_mockUnitOfWork.Object, _mapper, new ProductForManipulationDtoValidator(), _mockImageService.Object);

            //Act
            var actual = await controller.UpdateProduct(Guid.NewGuid(), _productForManipulationExample);

            //Assert
            actual.Should().BeOfType(typeof(NotFoundResult));
        }

        private static IEnumerable<Product> GetProductsEntitiesExampleData()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Name1",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Name2",
                    DefaultQuantity = 2
                },
            };
        }
    }
}
