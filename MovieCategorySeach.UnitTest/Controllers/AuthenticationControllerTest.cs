using Merino.Test;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Application.UseCase.Auth;
using MovieCategorySearch.Application.UseCase.Auth.Dto;
using MovieCategorySearch.Controllers;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySeach.UnitTest.Controllers
{
    /// <summary>
    /// ユニットテスト用のAuthenticationControllerクラスです。
    /// </summary>
    public class AuthenticationControllerTest : MerinoUnitTest
    {
        private AuthenticationController _controller;
        private Mock<ILogger<AuthenticationController>> _loggerMock;
        private Mock<IAuthService> _authServiceMock;

        /// <summary>
        /// AuthenticationControllerTestクラスの新しいインスタンスを初期化します。
        /// </summary>
        public AuthenticationControllerTest()
        {
            _loggerMock = new Mock<ILogger<AuthenticationController>>();
            _authServiceMock = new Mock<IAuthService>();
            var services = new ServiceCollection();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.LoginPath = "/Authentication/Login";
                    options.AccessDeniedPath = "/Authentication/AccessDenied";
                });
            services.AddLogging();
            services.AddMvc();

            _controller = (AuthenticationController)ArrangeServiceAndController(
                new AuthenticationController(_loggerMock.Object, _authServiceMock.Object)
                );
            //_controller.ControllerContext = new ControllerContext()
            //{
            //    HttpContext = new DefaultHttpContext(),
            //    RouteData = new RouteData(),
            //    ActionDescriptor = new ControllerActionDescriptor(),
            //};
            //_controller.ControllerContext.HttpContext.RequestServices = services.BuildServiceProvider();
        }

        /// <summary>
        /// LoginメソッドがViewResultを返すことをテストします。
        /// </summary>
        [Fact]
        public void Login_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = _controller.Login();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// LoginメソッドがReturnUrlを含むViewResultを返すことをテストします。
        /// </summary>
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

        /// <summary>
        /// 無効なモデルを使用してLoginメソッドがViewResultを返すことをテストします。
        /// </summary>
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

        /// <summary>
        /// 無効な認証情報を使用してLoginメソッドがViewResultを返すことをテストします。
        /// </summary>
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

        /// <summary>
        /// 有効な認証情報を使用してLoginメソッドがMovieIndexにリダイレクトすることをテストします。
        /// </summary>
        [Fact]
        public async Task Login_WithValidCredentials_RedirectsToMovieIndex()
        {
            // Arrange
            var model = new LoginViewModel { LoginId = "seed01@example.com", Password = "password" };
            _authServiceMock.Setup(x => x.Auth(It.IsAny<AuthRequest>())).Returns(true);         

            // Act
            var result = await _controller.Login(model);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Movie", redirectResult.ControllerName);
        }

        /// <summary>
        /// LogoutメソッドがHomeIndexにリダイレクトすることをテストします。
        /// </summary>
        [Fact]
        public async Task Logout_RedirectsToHomeIndex()
        {
            // Arrange            

            // Act
            var result = await _controller.Logout();

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }
    }
}
