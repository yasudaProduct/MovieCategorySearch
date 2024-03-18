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
            #region Movie
            if (!context.Movie.Any())
            {

                context.Movie.AddRange(
                    new Movie
                    {
                        TmdbMovieId = 1,
                        Title = "When Harry Met Sally",
                        DeletedFlg = "0",
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
                        DeletedFlg = "0",
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
                        DeletedFlg = "0",
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
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    }
                );
            }
            #endregion

            #region User
            if (!context.User.Any())
            {

                context.User.AddRange(
                    new User
                    {
                        UserId = 1,
                        MailAdress = "seed01@example.com",
                        UserCls = "1",
                        DeletedFlg = "0",
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
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    }
                    );
            }
            #endregion

            context.SaveChanges();
        }
    }
}
