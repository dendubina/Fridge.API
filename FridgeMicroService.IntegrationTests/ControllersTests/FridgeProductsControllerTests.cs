using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using FridgeManager.FridgesMicroService.DTO.FridgeProducts;
using FridgeMicroService.IntegrationTests.Fixtures;
using Xunit;

namespace FridgeMicroService.IntegrationTests.ControllersTests
{
    public class FridgeProductsControllerTests : IClassFixture<FridgeMicroServiceFixture>
    {
        private const string ExistedFridgeId = "501861fe-9b0c-447b-4219-08dab68bd0ac";

        private readonly HttpClient _fridgeServiceClient;
        private readonly Fixture _dataFixture = new();

        public FridgeProductsControllerTests(FridgeMicroServiceFixture fixture)
            => _fridgeServiceClient = fixture.FridgeServiceClient;

        [Fact]
        public async Task GetProductsInFridge_Should_Return_NotFound_When_Fridge_NotFound()
        {
            //Act
            var response = await _fridgeServiceClient.GetAsync(GetRouteToFridgeProducts(Guid.NewGuid().ToString()));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetProductsInFridge_Should_Expected_Content_When_Fridge_Found()
        {
            //Arrange
            var expected = new FridgeProductForReturnDto[]
            {
                new()
                {
                    Id = Guid.Parse("85589ff8-2885-45e0-cbb7-08dab68bd0ba"),
                    FridgeId = Guid.Parse(ExistedFridgeId),
                    ProductId = Guid.Parse("d3ef9d36-026e-4569-8558-25a204f1f13a"),
                    ProductName = "Mashroom",
                    Quantity = 1,
                    ImageSource = "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg",
                }
            };

            //Act
            var response = await _fridgeServiceClient.GetAsync(GetRouteToFridgeProducts(ExistedFridgeId));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<IEnumerable<FridgeProductForReturnDto>>();
            content.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task AddProductsToFridge_Should_Return_NotFound_When_Fridge_NotFound()
        {
            //Arrange
            var product = _dataFixture.Create<FridgeProductForManipulationDto>();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(GetRouteToFridgeProducts(Guid.NewGuid().ToString()), product);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task AddProductsToFridge_Should_Return_BadRequest_When_Product_NotFound()
        {
            //Arrange
            var product = _dataFixture.Create<FridgeProductForManipulationDto>();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(GetRouteToFridgeProducts(ExistedFridgeId), product);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(int.MinValue)]
        public async Task AddProductsToFridge_Should_Return_BadRequest_When_Quantity_Invalid(int quantity)
        {
            //Arrange
            var product = _dataFixture
                .Build<FridgeProductForManipulationDto>()
                .With(x => x.Quantity, quantity)
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(GetRouteToFridgeProducts(ExistedFridgeId), product);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task AddProductsToFridge_Should_Return_Ok_When_Valid_Request()
        {
            //Arrange
            var fridgeIdToUpdate = "859e4d86-bd70-49f5-6927-08dab71f5042";
            var product = new FridgeProductForManipulationDto
            {
                ProductId = Guid.Parse("d3ef9d36-026e-4569-8558-25a204f1f13a"),
                Quantity = 1,
            };

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(GetRouteToFridgeProducts(fridgeIdToUpdate), product);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteProductFromFridge_Should_Return_NoContent()
        {
            //Act
            var response = await _fridgeServiceClient.DeleteAsync($"{GetRouteToFridgeProducts(Guid.NewGuid().ToString())}/{Guid.NewGuid()}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateProductInFridge_Should_Return_NotFound_When_Fridge_NotFound()
        {
            //Arrange
            var product = _dataFixture.Create<FridgeProductForManipulationDto>();

            //Act
            var response = await _fridgeServiceClient.PutAsJsonAsync(GetRouteToFridgeProducts(Guid.NewGuid().ToString()), product);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateProductInFridge_Should_Return_BadRequest_When_Product_NotFound()
        {
            //Arrange
            var product = _dataFixture.Create<FridgeProductForManipulationDto>();

            //Act
            var response = await _fridgeServiceClient.PutAsJsonAsync(GetRouteToFridgeProducts(ExistedFridgeId), product);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateProductInFridge_Should_Return_NoContent_When_Valid_Request()
        {
            //Arrange
            var product = new FridgeProductForManipulationDto
            {
                ProductId = Guid.Parse("d3ef9d36-026e-4569-8558-25a204f1f13a"),
                Quantity = 1,
            };

            //Act
            var response = await _fridgeServiceClient.PutAsJsonAsync(GetRouteToFridgeProducts(ExistedFridgeId), product);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        private static string GetRouteToFridgeProducts(string fridgeId)
            => $"api/fridges/{fridgeId}/products";
    }
}
