using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieCategorySearch.Infrastructure.Data.Entity;

namespace MovieCategorySearch.Infrastructure.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PostgresDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PostgresDbContext>>()))
        {

            if (!context.Movie.Any())
            {

                context.Movie.AddRange(
                    new Movie
                    {
                        TmdbMovieId = 1,
                        Title = "When Harry Met Sally",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new Movie
                    {
                        TmdbMovieId = 2,
                        Title = "Ghostbusters ",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new Movie
                    {
                        TmdbMovieId = 3,
                        Title = "Ghostbusters 2",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new Movie
                    {
                        TmdbMovieId = 4,
                        Title = "Rio Bravo",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    }
                );
            }

            if (!context.User.Any())
            {

                context.User.AddRange(
                    new User
                    {
                        UserId = 1,
                        MailAdress = "seed01@example.com",
                        UserCls = "1",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new User
                    {
                        UserId = 2,
                        MailAdress = "seed02@example.com",
                        UserCls = "1",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    }
                    );
            }

            context.SaveChanges();
        }
    }
}
