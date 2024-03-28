using Merino.Test;
using Microsoft.EntityFrameworkCore;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Infrastructure.Data;
using MovieCategorySearch.Infrastructure.QueryServices;

namespace MovieCategorySeach.UnitTest.Infrastructure.QueryServices
{
    public class MovieQueryServiceTest : MerinoUnitTest
    {

        PostgresDbContext _dbContext;

        public MovieQueryServiceTest()
        {
            // Arrange
            _dbContext = new PostgresDbContext(
                new DbContextOptionsBuilder<PostgresDbContext>().UseInMemoryDatabase("InMemory").Options
                );
            
            SeedData.InitTestData(_dbContext);
        }


        [Fact]
        public void GetbyTmdbId_Should_Return_MovieQueryResult_When_Movie_Exists()
        {
            // Arrange
            int tmdbId = 763215;
            var movieQueryService = new MovieQueryService(_dbContext);

            // Act
            var result = movieQueryService.GetbyTmdbId(tmdbId);

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
            var movieQueryService = new MovieQueryService(_dbContext);

            // Act
            var result = movieQueryService.GetbyTmdbId(tmdbId);

            // Assert
            Assert.Null(result);
        }
    }
}
