using System;
using System.IO;
using AutoFixture;
using AutoFixture.Dsl;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Moq;
using ProductsService.Models;
using ProductsService.Validators;
using Xunit;

namespace ProductsService.Tests.Validators.Tests
{
    public class ProductForManipulationValidatorTests
    {
        private readonly IPostprocessComposer<ProductForManipulation> _modelBuilder;
        private readonly IFixture _fixture = new Fixture();
        private readonly ProductForManipulationValidator _validator = new();

        public ProductForManipulationValidatorTests()
        {
            _modelBuilder =_fixture.Build<ProductForManipulation>()
                .Without(x => x.Image);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Should_Have_Error_When_Name_Null_Or_Empty(string name)
        {
            //Arrange
            var model =  _modelBuilder
                .With(x => x.Name, name)
                .Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Specified()
        {
            //Arrange
            var model = _modelBuilder.Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(int.MinValue)]
        public void Should_Have_Error_When_DefaultQuantity_Less_Than_0(int value)
        {
            //Arrange
            var model = _modelBuilder
                .With(x => x.DefaultQuantity, value)
                .Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.DefaultQuantity);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(int.MaxValue)]
        public void Should_Not_Have_Error_When_DefaultQuantity_Greater_Than_0(int value)
        {
            //Arrange
            var model = _modelBuilder
                .With(x => x.DefaultQuantity, value)
                .Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.DefaultQuantity);
        }

        [Theory]
        [InlineData(".doc")]
        [InlineData(".exe")]
        [InlineData(".cs")]
        [InlineData(".mkv")]
        [InlineData(".something")]
        public void Should_Have_Error_When_Invalid_File_Extension(string extension)
        {
            //Arrange
            using var signature = new MemoryStream(CreateRandomFileSignature());
            var mock = CreateFormFileMock(fileName: $"{DateTime.Now.Ticks}{extension}", signature);
            var model = _fixture
                .Build<ProductForManipulation>()
                .With(x => x.Image, mock.Object)
                .Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Image)
                .WithErrorMessage("Wrong image extension");
        }

        [Theory]
        [InlineData(".jpg")]
        [InlineData(".png")]
        [InlineData(".bmp")]
        [InlineData(".jpeg")]
        public void Should_HaveError_When_Invalid_File_Signature(string extension)
        {
            //Arrange
            using var signature = new MemoryStream(CreateRandomFileSignature());
            var mock = CreateFormFileMock(fileName: $"{DateTime.Now.Ticks}{extension}", signature);

            var model = _fixture
                .Build<ProductForManipulation>()
                .With(x => x.Image, mock.Object)
                .Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Image)
                .WithErrorMessage("Wrong image extension");
        }

        [Fact]
        public void Should_Have_Error_When_File_Size_Greater_Than_1Mb()
        {
            //Arrange
            using var signature = new MemoryStream(CreateRandomFileSignature());
            var mock = CreateFormFileMock("image.jpg", signature, long.MaxValue);

            var model = _fixture
                .Build<ProductForManipulation>()
                .With(x => x.Image, mock.Object)
                .Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Image)
                .WithErrorMessage("Image size must be less than 1MB");
        }

        [Theory]
        [InlineData(".png", new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A })]
        [InlineData(".bmp", new byte[] { 0x42, 0x4D })]
        [InlineData(".jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 })]
        [InlineData(".jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 })]
        [InlineData(".jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 })]
        [InlineData(".jpeg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 })]
        [InlineData(".jpeg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 })]
        [InlineData(".jpeg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 })]
        public void Should_Not_Have_Error_When_Valid_Parameters(string extension, byte[] signature)
        {
            //Arrange
            using var validSignature = new MemoryStream(signature);
            var mock = CreateFormFileMock($"image{extension}", validSignature);

            var model = _modelBuilder
                .With(x => x.Image, mock.Object)
                .Create();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        private static Mock<IFormFile> CreateFormFileMock(string fileName, Stream signature, long fileLength = 1)
        {
            var mock = new Mock<IFormFile>();

            mock.Setup(x => x.FileName).Returns(fileName);
            mock.Setup(x => x.OpenReadStream()).Returns(signature);
            mock.Setup(x => x.Length).Returns(fileLength);

            return mock;
        }

        private static byte[] CreateRandomFileSignature()
        {
            var rnd = new Random();
            var signature = new byte[rnd.Next(5, 10)];

            for (int i = 0; i < signature.Length; i++)
            {
                signature[i] = (byte)rnd.Next(byte.MinValue, byte.MaxValue);
            }

            return signature;
        }
    }
}
