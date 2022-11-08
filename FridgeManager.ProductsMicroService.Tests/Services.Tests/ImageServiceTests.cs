using System;
using System.IO.Abstractions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using FridgeManager.ProductsMicroService.Contracts;
using FridgeManager.ProductsMicroService.Models.Options;
using FridgeManager.ProductsMicroService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace FridgeManager.ProductsMicroService.Tests.Services.Tests
{
    public class ImageServiceTests
    {
        private const string SomeBasePath = "BasePath";
        private const string SomeFileName = "image.jpg";

        private readonly IOptions<ImageServiceOptions> _options = Options.Create(new ImageServiceOptions { FolderToSave = "Images" });
        private readonly Mock<IFileSystem> _mockFileSystem = new();
        private readonly Mock<IFormFile> _mockFormFile = new();
        private readonly IImageService _imageService;

        public ImageServiceTests()
        {
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment.Setup(x => x.WebRootPath).Returns(SomeBasePath);

            _mockFileSystem.Setup(x => x.File.Create(It.IsAny<string>()));
            _mockFormFile.Setup(x => x.FileName).Returns(SomeFileName);

            _imageService = new ImageService(mockEnvironment.Object, _options, _mockFileSystem.Object);
        }

        [Fact]
        public async void AddImageGetPath_Should_ThrowException_When_Image_Is_Null()
        {
            //Arrange
            IFormFile image = null;

            //Act
            Func<Task> act = () => _imageService.AddImageGetPath(image);

            //Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void AddImageGetPath_Should_Create_File()
        {
            //Act
            await _imageService.AddImageGetPath(_mockFormFile.Object);

            //Assert
            _mockFileSystem.Verify(x => x.File.Create(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async void AddImageGetPath_Should_Return_Expected_Path()
        {
            //Arrange
            var regex = new Regex("[(http(s)?):\\/\\/)a-zA-Z0-9]{2,256}\\.[a-z]{3,4}");

            //Act
            var actual = await _imageService.AddImageGetPath(_mockFormFile.Object);

            //Assert
            actual.Should().MatchRegex(regex);
        }
    }
}
