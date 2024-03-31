using Merino.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.UseCase.Categories;
using MovieCategorySearch.Controllers;
using MovieCategorySearch.ViewModels;
using System.Security.Claims;

namespace MovieCategorySeach.UnitTest.Controllers
{
    /// <summary>
    /// テスト用のCategoryControllerクラスです。
    /// </summary>
    public class CategoryControllerTest : MerinoUnitTest
    {
        private CategoryController _controller;

        private Mock<ILogger<CategoryController>> _mockILogger;

        private Mock<ICategoryService> _mockICategoryService;

        /// <summary>
        /// CategoryControllerTestクラスの新しいインスタンスを初期化します。
        /// </summary>
        public CategoryControllerTest()
        {
            //Arrange
            _mockILogger = new Mock<ILogger<CategoryController>>();

            _mockICategoryService = new Mock<ICategoryService>();
            _mockICategoryService.Setup(mock => mock.Find(1))
                .ReturnsAsync(new CategoryDetailsDto(1, "カテゴリ１", "説明１"));

            _mockICategoryService.Setup(mock => mock.FindAll())
                .Returns(new List<CategoryDetailsDto>()
                {
                        new CategoryDetailsDto(1, "カテゴリ１", "説明１"),
                        new CategoryDetailsDto(2, "カテゴリ２", "説明２")
                });

            _mockICategoryService.Setup(mock => mock.Create(new CreateCategoryCommand(
                "カテゴリ３",
                "説明３",
                1
                )))
                .Returns(1)
                .Verifiable();

            _controller = new CategoryController(_mockILogger.Object, _mockICategoryService.Object);
        }

        /// <summary>
        /// Indexメソッドをテストします。
        /// </summary>
        [Fact]
        public async void Index_Open()
        {

            //Act
            var result = _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// Detailsメソッドをテストします。
        /// </summary>
        [Fact]
        public async void Details_ReturnsViewWithCategoryViewModel()
        {
            //Act
            var result = _controller.Details(1);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CategoryViewModel>(viewResult.Model);

            Assert.Equal(1, model.Id);
            Assert.Equal("カテゴリ１", model.CategoryName);
            Assert.Equal("説明１", model.Description);
        }

        /// <summary>
        /// Createメソッドをテストします。
        /// </summary>
        [Fact]
        public async void Create_Open()
        {

            //Act
            var result = _controller.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// CreateメソッドのPOSTリクエストをテストします。
        /// </summary>
        [Fact]
        public async void CreatePost_ReturnsViewWithCategoryViewModel_WhenModelStateIsInvalid()
        {
            //Arrange
            var viewModel = new CategoryViewModel
            {
                CategoryName = "テスト１",
                Description = "テスト２"
            };
            _controller.ModelState.AddModelError("CategoryName", "カテゴリ名は必須です。"); //ModelStateを無効にする

            //Act
            var result = _controller.Create(viewModel);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CategoryViewModel>(viewResult.Model);
            Assert.Equal("テスト１", model.CategoryName);
            Assert.Equal("テスト２", model.Description);
        }

        /// <summary>
        /// CreateメソッドのPOSTリクエストをテストします。
        /// </summary>
        [Fact]
        public async void CreatePost_ReturnsARedirect_WhenModelStateIsValid()
        {
            //Arrange
            var mockICategoryService = new Mock<ICategoryService>();
            mockICategoryService.Setup(mock => mock.Create(
                It.IsAny< CreateCategoryCommand>()))
                .Returns(1);

            var controller = new CategoryController(
                new Mock<ILogger<CategoryController>>().Object,
                mockICategoryService.Object
                );

            var viewModel = new CategoryViewModel
            {
                CategoryName = "テスト１",
                Description = "テスト２"
            };

            //Cookie認証を設定
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, "UnitTest@example.com"),
                    new Claim("UserId", "1"),
                    new Claim(ClaimTypes.Role, "Administrator"),
            }));

            //Act
            var result = controller.Create(viewModel);

            //Assert

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal("id", redirectToActionResult.RouteValues.Keys.First());
            Assert.Equal(1, redirectToActionResult.RouteValues["id"]);

        }
    }
}
