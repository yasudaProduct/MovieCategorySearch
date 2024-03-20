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
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = 1,
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    },
                    new Movie
                    {
                        TmdbMovieId = 2,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = 1,
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    },
                    new Movie
                    {
                        TmdbMovieId = 3,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = 1,
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    },
                    new Movie
                    {
                        TmdbMovieId = 4,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = 1,
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
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
                        CreateUserId = 1,
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    },
                    new User
                    {
                        UserId = 2,
                        MailAdress = "seed02@example.com",
                        UserCls = "1",
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = 1,
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    }
                    );
            }
            #endregion

            #region Category
            if (!context.Category.Any())
            {

                context.Category.AddRange(
                    new Category
                    {
                        Name = "記憶を消してみたい映画",
                        Description = "Seed Date",
                        CreateUserId = 1,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    },
                    new Category
                    {
                        Name = "雨の日に観たい映画",
                        Description = "Seed Date",
                        CreateUserId = 2,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    },
                    new Category
                    {
                        Name = "友だちと観たい映画",
                        Description = "Seed Date",
                        CreateUserId = 1,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = 1,
                        UpdateDate = DateTime.Now,
                    }
                    );
            }
            #endregion

            context.SaveChanges();
        }
    }
}
