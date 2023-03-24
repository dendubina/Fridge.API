using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using FridgeService.IntegrationTests.Fixtures;
using FridgesService.DTO.FridgeProducts;
using FridgesService.DTO.Fridges;
using Xunit;

namespace FridgeService.IntegrationTests.ControllersTests
{
    public class FridgeControllerTests : IClassFixture<FridgeMicroServiceFixture>
    {
        private const string FridgeControllerRoute = "api/fridges";

        private readonly HttpClient _fridgeServiceClient;
        private readonly FridgeMicroServiceFixture _fridgeMicroServiceFixture;
        private readonly Fixture _dataFixture = new();

        public FridgeControllerTests(FridgeMicroServiceFixture fixture)
        {
            _fridgeMicroServiceFixture = fixture;
            _fridgeServiceClient = fixture.FridgeServiceClient;
        }

        [Fact]
        public async Task GetAllFridges_Should_Return_Expected_Response()
        {
            //Act
            var response = await _fridgeServiceClient.GetAsync(FridgeControllerRoute);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var fridges = await response.Content.ReadFromJsonAsync<IEnumerable<FridgeForReturnDto>>();
            fridges.Should().NotBeEmpty().And.ContainItemsAssignableTo<FridgeForReturnDto>();
        }

        [Fact]
        public async Task GetById_Should_Return_Expected_Fridge_When_Fridge_Found()
        {
            //Arrange
            var fridgeId = Guid.Parse("501861fe-9b0c-447b-4219-08dab68bd0ac");
            var expected = new FridgeForReturnDto
            {
                Id = fridgeId,
                Name = "MyFridge",
                ModelName = "ModelName",
                ModelYear = 2000,
                FridgeProducts = new[]
                {
                    new FridgeProductForReturnDto()
                    {
                        Id = Guid.Parse("85589ff8-2885-45e0-cbb7-08dab68bd0ba"),
                        FridgeId = fridgeId,
                        ProductId = Guid.Parse("d3ef9d36-026e-4569-8558-25a204f1f13a"),
                        ProductName = "Mashroom",
                        ImageSource = "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg",
                        Quantity = 1
                    }
                }
            };

            //Act
            var response = await _fridgeServiceClient.GetAsync($"{FridgeControllerRoute}/{fridgeId}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var actualFridge = await response.Content.ReadFromJsonAsync<FridgeForReturnDto>();
            actualFridge.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetById_Should_Return_NotFound_When_Fridge_Not_Found()
        {
            //Act
            var response = await _fridgeServiceClient.GetAsync($"{FridgeControllerRoute}/{Guid.NewGuid()}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [MemberData(nameof(BasicInvalidStrings))]
        public async Task CreateFridge_Should_Return_BadRequest_When_FridgeName_Invalid(string fridgeName)
        {
            //Arrange
            var fridge = _dataFixture
                .Build<FridgeForCreateDto>()
                .With(x => x.Name, fridgeName)
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(FridgeControllerRoute, fridge);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [MemberData(nameof(BasicInvalidStrings))]
        public async Task CreateFridge_Should_Return_BadRequest_When_OwnerName_Invalid(string ownerName)
        {
            //Arrange
            var fridge = _dataFixture
                .Build<FridgeForCreateDto>()
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(FridgeControllerRoute, fridge);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [MemberData(nameof(BasicInvalidStrings))]
        public async Task CreateFridge_Should_Return_BadRequest_When_ModelName_Invalid(string modelName)
        {
            //Arrange
            var fridge = _dataFixture
                .Build<FridgeForCreateDto>()
                .With(x => x.ModelName, modelName)
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(FridgeControllerRoute, fridge);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [MemberData(nameof(BasicInvalidIntegers))]
        public async Task CreateFridge_Should_Return_BadRequest_When_ModelYear_Invalid(int modelYear)
        {
            //Arrange
            var fridge = _dataFixture
                .Build<FridgeForCreateDto>()
                .With(x => x.ModelYear, modelYear)
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(FridgeControllerRoute, fridge);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [MemberData(nameof(BasicInvalidIntegers))]
        public async Task CreateFridge_Should_Return_BadRequest_When_ProductQuantity_Invalid(int quantity)
        {
            //Arrange
            var products = _dataFixture
                .Build<FridgeProductForManipulationDto>()
                .With(x => x.Quantity, quantity)
                .CreateMany(count: 1);

            var fridge = _dataFixture
                .Build<FridgeForCreateDto>()
                .With(x => x.FridgeProducts, products)
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(FridgeControllerRoute, fridge);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateFridge_Should_Return_BadRequest_When_Product_NotFound()
        {
            //Arrange
            var products = _dataFixture
                .CreateMany<FridgeProductForManipulationDto>(count: 1);

            var fridge = _dataFixture
                .Build<FridgeForCreateDto>()
                .With(x => x.FridgeProducts, products)
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(FridgeControllerRoute, fridge);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateFridge_Should_Return_Created_When_Valid_Parameters()
        {
            //Arrange
            var existedProductId = Guid.Parse("d3ef9d36-026e-4569-8558-25a204f1f13a");

            var products = _dataFixture
                .Build<FridgeProductForManipulationDto>()
                .With(x => x.ProductId, existedProductId)
                .CreateMany(count: 1);

            var fridge = _dataFixture
                .Build<FridgeForCreateDto>()
                .With(x => x.FridgeProducts, products)
                .With(x => x.Name, "TestFridge")
                .Create();

            //Act
            var response = await _fridgeServiceClient.PostAsJsonAsync(FridgeControllerRoute, fridge);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task DeleteFridge_Should_Return_NoContent()
        {
            //Act
            var response = await _fridgeServiceClient.DeleteAsync($"{FridgeControllerRoute}/{Guid.NewGuid()}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateFridge_Should_Return_NoContent_When_Fridge_Found()
        {
            //Arrange
            var model = _dataFixture.Create<FridgeForUpdateDto>();

            //Act
            var response = await _fridgeServiceClient.PutAsJsonAsync($"{FridgeControllerRoute}/{_fridgeMicroServiceFixture.FridgeToUpdateId}", model);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateFridge_Should_Return_NotFound_When_Fridge_NotFound()
        {
            //Arrange
            var model = _dataFixture.Create<FridgeForUpdateDto>();

            //Act
            var response = await _fridgeServiceClient.PutAsJsonAsync($"{FridgeControllerRoute}/{Guid.NewGuid()}", model);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        public static IEnumerable<object[]> BasicInvalidStrings
            => new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { "   " }
            };

        public static IEnumerable<object[]> BasicInvalidIntegers
            => new List<object[]>
            {
                new object[] { 0 },
                new object[] { -1 },
                new object[] {-100 },
                new object[] { int.MinValue },
            };
    }
}
