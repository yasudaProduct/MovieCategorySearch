using Merino.Test;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Infrastructure.Data;
using MovieCategorySearch.Infrastructure.QueryServices;

namespace MovieCategorySearch.UnitTest.Infrastructure.QueryServices
{
    public class MovieQueryServiceTest : MerinoUnitTest
    {
        IMovieQueryService _queryService;

        PostgresDbContext _dbContext;

        public MovieQueryServiceTest()
        {
            // Arrange
            _dbContext = new PostgresDbContext(
                new DbContextOptionsBuilder<PostgresDbContext>().UseInMemoryDatabase("InMemory").Options
                );
            SeedData.InitTestData(_dbContext);


            Mock<ITmdbApiClient> mockITmdbApiClient = new Mock<ITmdbApiClient>();           

            _queryService = new MovieQueryService(_dbContext, mockITmdbApiClient.Object);
        }


        [Fact]
        public void GetbyTmdbId_Should_Return_MovieQueryResult_When_Movie_Exists()
        {
            // Arrange
            int tmdbId = 763215;

            // Act
            var result = _queryService.GetbyTmdbId(tmdbId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MovieQueryResult>(result);
            Assert.Equal(tmdbId, result.TmdbMovieId);
        }

        [Fact]
        public void GetbyTmdbId_Should_Return_Null_When_Movie_Does_Not_Exist()
        {
            // Arrange
            int tmdbId = 1;

            // Act
            var result = _queryService.GetbyTmdbId(tmdbId);

            // Assert
            Assert.Null(result);
        }
    }
}
