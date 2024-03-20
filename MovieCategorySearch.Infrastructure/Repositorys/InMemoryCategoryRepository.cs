using MovieCategorySearch.Application.Domain.Categorys;
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

        public void Save(Category category)
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
        }
    }
}
