using Humanizer;
using Merino.Test;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.Usecase.Movie.Dto;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Domain.Movie;

namespace MovieCategorySearch.UnitTest.UseCase
{

    /// <summary>
    /// テストクラスの説明
    /// </summary>
    public class MovieServiceTest : MerinoUnitTest
    {
        private readonly Mock<ILogger<MovieService>> _loggerMock;
        private readonly Mock<IMovieRepository> _movieRepositoryMock;
        private readonly Mock<IMovieQueryService> _movieQueryServiceMock;
        private readonly Mock<ITmdbApiClient> _tmdbApiClientMock;

        private readonly MovieService _movieService;

        /// <summary>
        /// テストクラスのコンストラクタ
        /// </summary>
        public MovieServiceTest()
        {
            // Arrange
            _loggerMock = new Mock<ILogger<MovieService>>();
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _movieQueryServiceMock = new Mock<IMovieQueryService>();
            _tmdbApiClientMock = new Mock<ITmdbApiClient>();

            _movieService = new MovieService(
                _loggerMock.Object,
                _movieRepositoryMock.Object,
                _movieQueryServiceMock.Object
            );
        }

        /// <summary>
        /// GetMovieListメソッドのテスト
        /// </summary>
        [Fact]
        public async Task GetMovieList_ShouldReturnListOfMovieResults()
        {
            // Arrange
            var movieQueryResult = new List<MovieQueryResult>
            {
                         new MovieQueryResult
                         {
                             TmdbMovieId = 1,
                             Title = "Movie 1",
                             OverView = "Overview 1",
                             PosterPath = "poster1.jpg",
                             CategoryList = new Dictionary<int, string>(){ { 1, "Category 1"}, { 2, "Category 2" } }
                         },
                        new MovieQueryResult
                        {
                            TmdbMovieId = 2,
                            Title = "Movie 2",
                            OverView = "Overview 2",
                            PosterPath = "poster2.jpg",
                            CategoryList = new Dictionary<int, string>(){ { 1, "Category 1"}, { 2, "Category 2" } }
                        }
            };

            _movieQueryServiceMock.Setup(x => x.GetPopularMovies()).ReturnsAsync(movieQueryResult);

            // Act
            var result = await _movieService.GetMovieList();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MovieResult>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].TmdbMovieId);
            Assert.Equal("Movie 1", result[0].Title);
            Assert.Equal("Overview 1", result[0].Overview);
            Assert.Equal("poster1.jpg", result[0].PosterPath);
            Assert.Equal(2, result[1].TmdbMovieId);
            Assert.Equal("Movie 2", result[1].Title);
            Assert.Equal("Overview 2", result[1].Overview);
            Assert.Equal("poster2.jpg", result[1].PosterPath);
            Assert.Equal(2, result[0].Category.Count);
            Assert.Equal("Category 1", result[0].Category[1]);
        }

        /// <summary>
        /// Searchメソッドのテスト
        /// </summary>
        [Fact]
        public async Task Search_ShouldReturnListOfMovieResults()
        {
            // Arrange
            var title = "Movie";

            var movieQueryResult = new MovieQueryResult
            {
                TmdbMovieId = 1,
                Title = "Movie 1",
                OverView = "Overview 1",
                PosterPath = "poster1.jpg",
                CategoryList = new Dictionary<int, string>() { { 1, "Category 1" }, { 2, "Category 2" } }
            };

            _movieQueryServiceMock.Setup(x => x.SearchCollection(title)).ReturnsAsync(movieQueryResult);

            // Act
            var result = await _movieService.Search(title);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MovieResult>>(result);
            Assert.Equal(1, result.Count);
            Assert.Equal(1, result[0].TmdbMovieId);
            Assert.Equal("Movie 1", result[0].Title);
            Assert.Equal("Overview 1", result[0].Overview);
        }

        /// <summary>
        /// GetDetailsメソッドのテスト
        /// </summary>
        [Fact]
        public async Task GetDetails_ShouldReturnMovieResult()
        {
            // Arrange
            var tmdbId = 1;

            var movieQueryResult = new MovieQueryResult
            {
                TmdbMovieId = 1,
                Title = "Movie 1",
                OverView = "Overview 1",
                PosterPath= "poster1.jpg",
                ReleaseDate = DateTime.Parse("2022-01-01"),
                CategoryList = new Dictionary<int, string>()
            };

            _movieQueryServiceMock.Setup(x => x.GetDetails(tmdbId)).ReturnsAsync(movieQueryResult);

            // Act
            var result = await _movieService.GetDetails(tmdbId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MovieResult>(result);
            Assert.Equal(1, result.TmdbMovieId);
            Assert.Equal("Movie 1", result.Title);
            Assert.Equal("Overview 1", result.Overview);
            Assert.Equal(DateTime.Parse("2022-01-01"), result.ReleaseDate);
        }
    }
}
