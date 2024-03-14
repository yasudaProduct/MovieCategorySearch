using Microsoft.EntityFrameworkCore;

namespace MovieCategorySearch.Infrastructure.Data
{
    internal class InMemoryDbContext: DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options) { }
    }
}
