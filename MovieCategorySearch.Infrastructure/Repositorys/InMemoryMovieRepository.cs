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

    }
}
