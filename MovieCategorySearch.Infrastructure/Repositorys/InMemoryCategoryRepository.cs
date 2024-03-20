using MovieCategorySearch.Application.Domain.Categories;
using MovieCategorySearch.Application.Domain.Categories.ValueObject;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Repositorys
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {

        private readonly PostgresDbContext _dbContext;

        public InMemoryCategoryRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Save(Category category)
        {
            var entity = new Data.Entity.Category()
            {
                Name = category.CategoryName.Value,
                Description = category.Description?.Value,
                CreateUserId = 1,
                DeletedFlg = "0",
            };

            _dbContext.Category.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }

        public Category Find(int id)
        {
            var entity = _dbContext.Category.Find(id);

            return new Category(
                entity.Id,
                new CategoryName(entity.Name),
                entity.Description != null ? new Description(entity.Description): null
                );
        }

    }
}
