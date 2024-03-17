using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.QueryServices
{
    public class MovieQueryService : IMovieQueryService
    {
        private readonly PostgresDbContext _dbContext;

        public MovieQueryService(PostgresDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<MovieResult> SearchMovieList(string title)
        {
            var movieList = _dbContext.Movie.Where(m => m.Title.Contains(title)).ToList();

            List<MovieResult> result = new List<MovieResult>();
            foreach (var movie in movieList)
            {
                result.Add(new MovieResult()
                {
                    Id = movie.Id,
                    TmdbMovieId = movie.TmdbMovieId,
                    Title = movie.Title
                });
            }

            return result;
        }
    }
}
