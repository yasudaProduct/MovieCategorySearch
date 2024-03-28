using Microsoft.EntityFrameworkCore;
using MovieCategorySearch.Infrastructure.Data.Entity;

namespace MovieCategorySearch.Infrastructure.Data
{
    internal class InMemoryDbContext: DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options) { }

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

            #region Test Data
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    TmdbMovieId = 1,
                    DeletedFlg = "0",
                    CreatePgmId = "Seed",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now,
                    UpdatePgmId = "Seed",
                    UpdateUserId = 1,
                    UpdateDate = DateTime.Now,
                }, new Movie
                {
                    TmdbMovieId = 2,
                    DeletedFlg = "0",
                    CreatePgmId = "Seed",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now,
                    UpdatePgmId = "Seed",
                    UpdateUserId = 1,
                    UpdateDate = DateTime.Now,
                }, new Movie
                {
                    TmdbMovieId = 3,
                    DeletedFlg = "0",
                    CreatePgmId = "Seed",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now,
                    UpdatePgmId = "Seed",
                    UpdateUserId = 1,
                    UpdateDate = DateTime.Now,
                });
            #endregion
        }
    }
}
