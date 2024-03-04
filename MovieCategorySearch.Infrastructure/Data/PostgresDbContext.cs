using Microsoft.EntityFrameworkCore;
using MovieCategorySearch.Infrastructure.Data.Entity;

namespace MovieCategorySearch.Infrastructure.Data;

public class PostgresDbContext: DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<User> User { get; set; } = default!;

}
