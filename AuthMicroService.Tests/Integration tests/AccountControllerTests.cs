using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Threading.Tasks;
using AuthMicroService.Tests.Integration_tests.Fixtures;
using AutoFixture;
using FluentAssertions;
using FridgeManager.AuthMicroService.Models;
using Moq;
using Xunit;

namespace AuthMicroService.Tests.Integration_tests
{
    public class AccountControllerTests : IClassFixture<AuthWebAppFixture>
    {
        private const string SignInUrl = "/SignIn";
        private const string SignUpUrl = "/SignUp";

        private readonly Fixture _dataFixture = new();
        private readonly AuthWebAppFixture _authWebAppFixture;
        private readonly HttpClient _authWebAppClient;

        public AccountControllerTests(AuthWebAppFixture fixture)
        {
            _authWebAppFixture = fixture;
            _authWebAppClient = fixture.AuthAppClient;
        }

        [Fact]
        public async Task SignIn_Should_Return_Expected_Response_When_Request_Data_Valid()
        {
            //Arrange
            var userProfile = _dataFixture.Create<UserProfile>();
            _authWebAppFixture.AuthServiceMock
                .Setup(x => x.SignIn(It.IsAny<SignInModel>()))
                .ReturnsAsync(userProfile);

            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignInUrl, new SignInModel { Email = userProfile.UserName, Password = "somePassword" } );

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            userProfile.Should().BeEquivalentTo(await response.Content.ReadFromJsonAsync<UserProfile>());
        }

        [Fact]
        public async Task SignIn_Should_Return_BadRequest_When_AuthService_Throws_InvalidOperationException()
        {
            //Arrange
            _authWebAppFixture.AuthServiceMock
                .Setup(x => x.SignIn(It.IsAny<SignInModel>()))
                .ThrowsAsync(new InvalidOperationException());

            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignInUrl, new SignInModel { Email = "someName", Password = "somePassword" });

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public async Task SignIn_Should_Return_BadRequest_When_UserName_Invalid(string userName)
        {
            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignInUrl, new SignInModel { Email = userName, Password = "somePassword" });

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public async Task SignIn_Should_Return_BadRequest_When_Password_Invalid(string password)
        {
            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignInUrl, new SignInModel { Email = "userName", Password = password });

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task SignUp_Should_Return_Expected_Response_When_Request_Data_Valid()
        {
            //Arrange
            var model = CreateValidSignUpModel();
            var userProfile = _dataFixture
                .Build<UserProfile>()
                .With(x => x.UserName, model.UserName)
                .With(x => x.Email, model.Email)
                .Create();

            _authWebAppFixture.AuthServiceMock
                .Setup(x => x.SignUp(It.IsAny<SignUpModel>()))
                .ReturnsAsync(userProfile);

            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignUpUrl, model);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            userProfile.Should().BeEquivalentTo(await response.Content.ReadFromJsonAsync<UserProfile>());
        }

        [Fact]
        public async Task SignUp_Should_Return_BadRequest_When_AuthService_Throws_InvalidOperationException()
        {
            //Arrange
            var model = CreateValidSignUpModel();

            _authWebAppFixture.AuthServiceMock
                .Setup(x => x.SignUp(It.IsAny<SignUpModel>()))
                .ThrowsAsync(new InvalidOperationException());

            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignUpUrl, model);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("  ")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("someString")]
        public async Task SignUp_Should_Return_BadRequest_When_Email_Invalid(string email)
        {
            //Arrange
            var model = CreateValidSignUpModel();
            model.Email = email;

            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignUpUrl, model);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task SignUp_Should_Return_BadRequest_When_Password_And_PasswordConfirm_Not_Same()
        {
            //Arrange
            var model = CreateValidSignUpModel();
            model.Password = "somePassword";
            model.PasswordConfirm = "anotherValue";

            //Act
            var response = await _authWebAppClient.PostAsJsonAsync(SignUpUrl, model);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private SignUpModel CreateValidSignUpModel()
            => _dataFixture
                .Build<SignUpModel>()
                .With(x => x.Email, _dataFixture.Create<MailAddress>().Address)
                .With(x => x.Password, "somePassword")
                .With(x => x.PasswordConfirm, "somePassword")
                .Create();
    }
}
