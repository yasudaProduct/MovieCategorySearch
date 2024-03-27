using Merino.Test;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Domain.Movie;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.Usecase.Movie.Dto;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySeach.UnitTest.UseCase
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
                _movieQueryServiceMock.Object,
                _tmdbApiClientMock.Object
            );
        }

        /// <summary>
        /// GetMovieListメソッドのテスト
        /// </summary>
        [Fact]
        public async Task GetMovieList_ShouldReturnListOfMovieResults()
        {
            // Arrange
            var tmdbApiResponse = new TmdbApiResponce
            {
                results = new Result[] {
                         new Result
                         {
                             id = 1,
                             title = "Movie 1",
                             overview = "Overview 1",
                             poster_path = "poster1.jpg"
                         },
                        new Result
                        {
                            id = 2,
                            title = "Movie 2",
                            overview = "Overview 2",
                            poster_path = "poster2.jpg"
                        }
                    }
            };

            _tmdbApiClientMock.Setup(x => x.GetPopular()).ReturnsAsync(tmdbApiResponse);

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
        }

        /// <summary>
        /// Searchメソッドのテスト
        /// </summary>
        [Fact]
        public async Task Search_ShouldReturnListOfMovieResults()
        {
            // Arrange
            var title = "Movie";

            var tmdbApiResponse = new TmdbApiResponce
            {
                results = new Result[] {
                         new Result
                         {
                             id = 1,
                             title = "Movie 1",
                             overview = "Overview 1",
                             poster_path = "poster1.jpg"
                         },
                        new Result
                        {
                            id = 2,
                            title = "Movie 2",
                            overview = "Overview 2",
                            poster_path = "poster2.jpg"
                        }
                    }
            };

            _tmdbApiClientMock.Setup(x => x.SearchCollection(title)).ReturnsAsync(tmdbApiResponse);

            // Act
            var result = await _movieService.Search(title);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MovieResult>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].TmdbMovieId);
            Assert.Equal("Movie 1", result[0].Title);
            Assert.Equal("Overview 1", result[0].Overview);
            Assert.Equal(2, result[1].TmdbMovieId);
            Assert.Equal("Movie 2", result[1].Title);
            Assert.Equal("Overview 2", result[1].Overview);
        }

        /// <summary>
        /// GetDetailsメソッドのテスト
        /// </summary>
        [Fact]
        public async Task GetDetails_ShouldReturnMovieResult()
        {
            // Arrange
            var tmdbId = 1;

            var tmdbMovieDetailsResponse = new TmdbMovieDetailsResponce
            {
                id = 1,
                title = "Movie 1",
                overview = "Overview 1",
                release_date = DateTime.Parse("2022-01-01")
            };

            _tmdbApiClientMock.Setup(x => x.GetDetails(tmdbId)).ReturnsAsync(tmdbMovieDetailsResponse);

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
