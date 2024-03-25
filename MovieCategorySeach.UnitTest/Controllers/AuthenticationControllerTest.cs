using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Application.UseCase.Auth.Dto;
using MovieCategorySearch.Application.UseCase.Auth;
using MovieCategorySearch.Controllers;
using MovieCategorySearch.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MovieCategorySeach.UnitTest.Controllers
{
    public class AuthenticationControllerTest
    {
        private AuthenticationController _controller;
        private Mock<ILogger<AuthenticationController>> _loggerMock;
        private Mock<IAuthService> _authServiceMock;

        public AuthenticationControllerTest()
        {
            _loggerMock = new Mock<ILogger<AuthenticationController>>();
            _authServiceMock = new Mock<IAuthService>();
            _controller = new AuthenticationController(_loggerMock.Object, _authServiceMock.Object);
        }

        [Fact]
        public void Login_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = _controller.Login();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Login_ReturnUrlViewResult()
        {
            // Arrange
            string ReturnUrl = "/Category/Create";

            // Act
            var result = _controller.Login(ReturnUrl);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<LoginViewModel>(viewResult.Model);

            Assert.Null(model.LoginId);
            Assert.Null(model.Password);
            Assert.NotNull(model.ReturnUrl);
        }

        [Fact]
        public async Task Login_WithInvalidModel_ReturnsViewResult()
        {
            // Arrange
            var model = new LoginViewModel();
            _controller.ModelState.AddModelError("LoginId", "Required");

            // Act
            var result = await _controller.Login(model);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsViewResult()
        {
            // Arrange
            var model = new LoginViewModel { LoginId = "testuser", Password = "password" };
            var authRequest = new AuthRequest(model.LoginId, model.Password);
            _authServiceMock.Setup(x => x.Auth(authRequest)).Returns(false);

            // Act
            var result = await _controller.Login(model);

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.True(_controller.ModelState.ContainsKey(string.Empty));
        }

        [Fact]
        public async Task Login_WithValidCredentials_RedirectsToMovieIndex()
        {
            // Arrange
            var model = new LoginViewModel { LoginId = "seed01@example.com", Password = "password" };
            var authRequest = new AuthRequest(model.LoginId, model.Password);
            _authServiceMock.Setup(x => x.Auth(authRequest)).Returns(true).Verifiable();

            // Act
            var result = await _controller.Login(model);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Movie", redirectResult.ControllerName);
        }

        [Fact]
        public async Task Logout_RedirectsToHomeIndex()
        {
            // Arrange
            //Cookie認証を設定
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "UnitTest@example.com"),
                new Claim("UserId", "1"),
                new Claim(ClaimTypes.Role, "Administrator"),
            });
            //_controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(claimsIdentity);

            await _controller.ControllerContext.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    // Cookie をブラウザー セッション間で永続化するか？（ブラウザを閉じてもログアウトしないかどうか）
                    IsPersistent = false,
                    //ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                });

            // Act
            var result = await _controller.Logout();

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }
    }
}
