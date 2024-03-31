using Microsoft.EntityFrameworkCore;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.Usecase.Movie.Dto;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;
using MovieCategorySearch.Domain.Movie;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Repositorys
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {

        private readonly PostgresDbContext _dbContext;

        private readonly ITmdbApiClient _tmdbApiClient;

        public InMemoryCategoryRepository(PostgresDbContext dbContext, ITmdbApiClient tmdbApiClient)
        {
            _dbContext = dbContext;
            _tmdbApiClient = tmdbApiClient;
        }


        public async Task<Category> Find(int id)
        {
            // Category‚ðŽæ“¾
            var entity = _dbContext.Category
                .Include(x => x.CategoryMaps).ThenInclude(x => x.Movie).ToList()
                .Find(x => x.Id == id);

            // 
            List<Movie> movies = new List<Movie>();
            foreach (var categoryMap in entity.CategoryMaps)
            {
                TmdbMovieDetailsResponce responce = await _tmdbApiClient.GetDetails(categoryMap.Movie.TmdbMovieId);

                movies.Add(new Movie(
                    responce.id,
                    responce.title,
                    responce.overview,
                    responce.poster_path,
                    responce.release_date
                        ));
            }

            return new Category(
                entity.Id,
                1,
                new CategoryName(entity.Name),
                entity.Description != null ? new Description(entity.Description): null,
                movies
                );
        }

        public List<Category> FindAll()
        {
            return _dbContext.Category.ToList().Select(x => new Category(
                               x.Id,
                               x.CreateUserId,
                               new CategoryName(x.Name),
                               x.Description != null ? new Description(x.Description) : null
                               )).ToList();
        }

        public int Save(Category category)
        {
            var entity = new Data.Entity.Category()
            {
                Name = category.CategoryName.Value,
                Description = category.Description?.Value,
                CreateUserId = category.CreateUserId,
                UpdateUserId = category.CreateUserId,
                DeletedFlg = "0",
            };

            _dbContext.Category.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }

    }
}
