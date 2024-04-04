using Merino.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Application.UseCase.Categories;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Controllers;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySeach.UnitTest.Controllers
{
    /// <summary>
    /// テスト用のMovieControllerクラス
    /// </summary>
    public class MovieControllerTest : MerinoUnitTest
    {
        private MovieController _controller;
        private Mock<ILogger<MovieController>> _loggerMock;
        private Mock<IMovieService> _movieServiceMock;
        private Mock<IMovieQueryService> _movieQueryServiceMock;
        private Mock<ICategoryService> _categoryService;

        /// <summary>
        /// MovieControllerTestクラスのコンストラクタ
        /// </summary>
        public MovieControllerTest()
        {
            // Arrange
            _loggerMock = new Mock<ILogger<MovieController>>();
            _movieServiceMock = new Mock<IMovieService>();
            _movieQueryServiceMock = new Mock<IMovieQueryService>();
            _categoryService = new Mock<ICategoryService>();

            _controller = new MovieController(
                _loggerMock.Object,
                _movieServiceMock.Object,
                _movieQueryServiceMock.Object
                ,_categoryService.Object
            );
        }

        /// <summary>
        /// Indexメソッドのテスト
        /// </summary>
        [Fact]
        public async Task Index_ReturnsViewWithMovieList()
        {
            // Arrange
            var movieList = new List<MovieResult>
                    {
                        new MovieResult { TmdbMovieId = 1, Title = "Movie 1", Overview = "Overview 1" },
                        new MovieResult { TmdbMovieId = 2, Title = "Movie 2", Overview = "Overview 2" }
                    };

            _movieServiceMock.Setup(x => x.GetMovieList()).ReturnsAsync(movieList);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<MovieListViewModel>(viewResult.Model);
            Assert.Equal(2, model.MovieList.Count);
            Assert.Equal(1, model.MovieList[0].TmdbMovieId);
            Assert.Equal("Movie 1", model.MovieList[0].Title);
            Assert.Equal("Overview 1", model.MovieList[0].Overview);
            Assert.Equal(2, model.MovieList[1].TmdbMovieId);
            Assert.Equal("Movie 2", model.MovieList[1].Title);
            Assert.Equal("Overview 2", model.MovieList[1].Overview);
        }

        /// <summary>
        /// Searchメソッドのテスト
        /// </summary>
        [Fact]
        public async Task Search_ReturnsViewWithMovieList()
        {
            // Arrange
            var movieList = new List<MovieResult>
                    {
                        new MovieResult { TmdbMovieId = 1, Title = "Movie 1", Overview = "Overview 1" },
                        new MovieResult { TmdbMovieId = 2, Title = "Movie 2", Overview = "Overview 2" }
                    };
            string title = "Action";

            _movieServiceMock.Setup(x => x.Search(title)).ReturnsAsync(movieList);

            // Act
            var result = await _controller.Search(title);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<MovieListViewModel>(viewResult.Model);
            Assert.Equal(2, model.MovieList.Count);
            Assert.Equal(1, model.MovieList[0].TmdbMovieId);
            Assert.Equal("Movie 1", model.MovieList[0].Title);
            Assert.Equal("Overview 1", model.MovieList[0].Overview);
            Assert.Equal(2, model.MovieList[1].TmdbMovieId);
            Assert.Equal("Movie 2", model.MovieList[1].Title);
            Assert.Equal("Overview 2", model.MovieList[1].Overview);
        }
    }
}
