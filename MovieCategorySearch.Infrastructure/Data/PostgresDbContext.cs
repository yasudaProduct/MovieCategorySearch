using Microsoft.EntityFrameworkCore;
using MovieCategorySearch.Infrastructure.Data.Entity;

namespace MovieCategorySearch.Infrastructure.Data;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<User> User { get; set; } = default!;

    public DbSet<Movie> Movie { get; set; } = default!;

    public DbSet<Category> Category { get; set; } = default!;

    public DbSet<CategoryMap> CategoryMap { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.DeletedFlg).HasDefaultValue("0");
        modelBuilder.Entity<User>()
            .HasMany(u => u.Categorys)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.CreateUserId);


        modelBuilder.Entity<Movie>()
            .Property(m => m.DeletedFlg).HasDefaultValue("0");
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.CategoryMaps)
            .WithOne(c => c.Movie)
            .HasForeignKey(c => c.MovieId);

        modelBuilder.Entity<Category>()
            .Property(c => c.DeletedFlg).HasDefaultValue("0");
        modelBuilder.Entity<Category>()
            .HasMany(c => c.CategoryMaps)
            .WithOne(cm => cm.Category)
            .HasForeignKey(cm => cm.CategoryId);
    }

}
