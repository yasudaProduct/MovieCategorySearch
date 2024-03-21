using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.UseCase.Categories;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Controllers;
using MovieCategorySearch.ViewModels;
using NuGet.Packaging;
using System.Data;

namespace MovieCategorySeach.UnitTest.Controllers
{
    public class HomeControllerTest : IDisposable
    {
        private HomeController _controller;

        public HomeControllerTest()
        {
            //Arrange
            Mock<ILogger<HomeController>> mockILogger = new Mock<ILogger<HomeController>>();

            Mock<ICategoryService> mockICategoryService = new Mock<ICategoryService>();
            mockICategoryService.Setup(mock => mock.Find(1))
                .Returns(new CategoryDetailsDto(1, "", ""));

            mockICategoryService.Setup(mock => mock.FindAll())
                .Returns(new List<CategoryDetailsDto>()
                {
                    new CategoryDetailsDto(1, "テスト1", "テスト1"),
                    new CategoryDetailsDto(2, "テスト2", "テスト2")
                });

            Mock<IMovieService> mockIMovieService = new Mock<IMovieService>();
            mockIMovieService.Setup(mock => mock.GetMovieList())
                .ReturnsAsync(new List<MovieResult>()
                {
                    new MovieResult(){ TmdbMovieId = 1,Title = "テスト1",Overview = "テスト" ,ReleaseDate = DateTime.Now},
                    new MovieResult(){ TmdbMovieId = 2,Title = "テスト2",Overview = "テスト" ,ReleaseDate = DateTime.Now}
                });

            _controller = new HomeController(mockILogger.Object, mockICategoryService.Object, mockIMovieService.Object);
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
            var result = await _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<HomeViewModel>(viewResult.Model);

            Assert.Equal(viewModel.CategoryModelList.Count(),2);
            Assert.Equal(viewModel.MovieList.Count(), 2);

            Assert.Equal(viewModel.CategoryModelList.ToList()[0].Id, 1);
            Assert.Equal(viewModel.CategoryModelList.ToList()[0].CategoryName, "テスト1");
            Assert.Equal(viewModel.MovieList.ToList()[0].TmdbMovieId, 1);
            Assert.Equal(viewModel.MovieList.ToList()[0].Title, "テスト1");
            Assert.Equal(viewModel.MovieList.ToList()[0].Overview, "テスト");
        }
    }
}
