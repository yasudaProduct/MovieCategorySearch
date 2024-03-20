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


        public Category Find(int id)
        {
            var entity = _dbContext.Category.Find(id);

            return new Category(
                entity.Id,
                new CategoryName(entity.Name),
                1,
                entity.Description != null ? new Description(entity.Description): null
                );
        }

        public List<Category> FindAll()
        {
            return _dbContext.Category.ToList().Select(x => new Category(
                               x.Id,
                               new CategoryName(x.Name),
                               x.CreateUserId,
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
