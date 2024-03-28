using MovieCategorySearch.Domain.Movie;
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

        public int? GetById(int id)
        {
            var movie = _dbContext.Movie.Find(id);

            if (movie == null) return null;

            return movie.TmdbMovieId;

        }

    }
}
