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
            InitSeedData(context);
        }
    }

    public static void InitTestData(PostgresDbContext context)
    {
        InitSeedData(context);
    }

    private static void InitSeedData(PostgresDbContext context)
    {
        #region Movie
        if (!context.Movie.Any())
        {

            context.Movie.AddRange(
                new Movie
                {
                    TmdbMovieId = 1011985,
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
                    TmdbMovieId = 634492,
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
                    TmdbMovieId = 763215,
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
                    EmailAdress = "seed01@example.com",
                    Name = "Seed01",
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
                    EmailAdress = "seed02@example.com",
                    Name = "Seed02",
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
                },
                new Category
                {
                    Name = "笑える映画",
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
                    Name = "深夜に見たい映画",
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
                    Name = "深夜に見たい映画",
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
                    Name = "連休おすすめ",
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
                    Name = "12345",
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
                    Name = "ＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷ",
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

        #region CategoryMap
        if (!context.CategoryMap.Any())
        {

            context.CategoryMap.AddRange(
                new CategoryMap { 
                    MovieId = 1011985,
                    CategoryId = 1,
                    DeletedFlg = "0",
                    CreatePgmId = "Seed",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now,
                    UpdatePgmId = "Seed",
                    UpdateUserId = 1,
                    UpdateDate = DateTime.Now,
                },
                new CategoryMap
                {
                    MovieId = 1011985,
                    CategoryId = 2,
                    DeletedFlg = "0",
                    CreatePgmId = "Seed",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now,
                    UpdatePgmId = "Seed",
                    UpdateUserId = 1,
                    UpdateDate = DateTime.Now,
                },
                new CategoryMap
                {
                    MovieId = 1011985,
                    CategoryId = 3,
                    DeletedFlg = "0",
                    CreatePgmId = "Seed",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now,
                    UpdatePgmId = "Seed",
                    UpdateUserId = 1,
                    UpdateDate = DateTime.Now,
                },
                new CategoryMap
                {
                    MovieId = 634492,
                    CategoryId = 1,
                    DeletedFlg = "0",
                    CreatePgmId = "Seed",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now,
                    UpdatePgmId = "Seed",
                    UpdateUserId = 1,
                    UpdateDate = DateTime.Now,
                },
                new CategoryMap
                {
                    MovieId = 763215,
                    CategoryId = 1,
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

        context.SaveChanges();

    }
}
