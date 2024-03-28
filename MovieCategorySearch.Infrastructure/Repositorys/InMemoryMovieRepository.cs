using MovieCategorySearch.Domain.Categories;
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

        public bool AddCategory(int TmdbId, Category category)
        {
            var movie = _dbContext.Movie.Find(TmdbId);

            if(movie == null)
            {
                movie = new Data.Entity.Movie();
                movie.TmdbMovieId = TmdbId;
                movie.CreateUserId = category.CreateUserId; // TODO
                movie.UpdateUserId = category.CreateUserId;
                movie.DeletedFlg = "0";
                _dbContext.Movie.Add(movie);
            }

            var cty = new Data.Entity.Category();
            cty.Name = category.CategoryName.Value;
            cty.Description = category.Description.Value;
            cty.CreateUserId = category.CreateUserId;
            cty.UpdateUserId = category.CreateUserId;
            cty.DeletedFlg = "0";

            var ctyMap = new Data.Entity.CategoryMap();
            ctyMap.MovieId = movie.TmdbMovieId;
            ctyMap.CategoryId = cty.Id;
            ctyMap.CategoryId = TmdbId;
            ctyMap.CreateUserId = category.CreateUserId;
            ctyMap.UpdateUserId = category.CreateUserId;
            ctyMap.DeletedFlg = "0";

            ctyMap.Category = cty;
            ctyMap.Movie = movie;
            movie.CategoryMaps = new List<Data.Entity.CategoryMap> { ctyMap };

            var result = _dbContext.SaveChanges();

            if(result == 0) return false;

            return true;
        }

    }
}
