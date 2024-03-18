using MovieCategorySearch.Application.Domain.Movie;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Repositorys
{
    public class InMemoryMovieRepository : IMovieRepository
    {

        private readonly PostgresDbContext _dbContext;

        public InMemoryMovieRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> FindAll()
        {

            var movieList = _dbContext.Movie.ToList();


            List<Movie> result = new List<Movie>();
            foreach (var movie in movieList)
            {
                result.Add(new Movie(
                    Id: movie.Id,
                    TmdbMovieId: movie.TmdbMovieId,
                    Title: movie.Title
                    ));
            }

            return result;
        }
    }
}
