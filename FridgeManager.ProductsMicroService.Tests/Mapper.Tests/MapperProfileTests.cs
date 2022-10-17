using AutoMapper;
using FridgeManager.ProductsMicroService.Mapper;
using Xunit;

namespace FridgeManager.ProductsMicroService.Tests.Mapper.Tests
{
    public class MapperProfileTests
    {
        [Fact]
        public void MapperProfile_Should_Be_Valid()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile(typeof(MapperProfile)));

            //Act and Assert
            config.AssertConfigurationIsValid();
        }
    }
}
