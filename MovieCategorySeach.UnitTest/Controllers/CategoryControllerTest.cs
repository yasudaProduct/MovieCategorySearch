using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.UseCase.Categories;
using MovieCategorySearch.Controllers;

namespace MovieCategorySeach.UnitTest.Controllers
{
    public class CategoryControllerTest : IDisposable
    {
        private CategoryController _controller;

        public CategoryControllerTest()
        {
            //Arrange
            Mock<ILogger<CategoryController>> mockILogger = new Mock<ILogger<CategoryController>>();

            Mock<ICategoryService> mockICategoryService = new Mock<ICategoryService>();
            mockICategoryService.Setup(mock => mock.Find(1))
                .Returns(new CategoryDetailsDto(1, "", ""));

            mockICategoryService.Setup(mock => mock.FindAll())
                .Returns(new List<CategoryDetailsDto>()
                {
                    new CategoryDetailsDto(1, "テスト1", "テスト1"),
                    new CategoryDetailsDto(2, "テスト2", "テスト2")
                });

            mockICategoryService.Setup(mock => mock.Create(new CreateCategoryCommand(
                "CategoryName",
                "Description",
                1
                )))
                .Returns(1);

            _controller = new CategoryController(mockILogger.Object, mockICategoryService.Object);
        }

        public void Dispose()
        {
            // 完了後にアンマネージドリソースの処理したり
            Console.WriteLine("disposed");
        }

        [Fact]
        public async void Index_Open()
        {

            //Act
            var result = _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Details_Open()
        {
            //Act
            var result = _controller.Details(1);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Create_Open()
        {
            //Act
            var result = _controller.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

    }
}
