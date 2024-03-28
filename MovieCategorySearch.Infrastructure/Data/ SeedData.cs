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
                    Name = "�L���������Ă݂����f��",
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
                    Name = "�J�̓��Ɋς����f��",
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
                    Name = "�F�����Ɗς����f��",
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
                    Name = "�΂���f��",
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
                    Name = "�[��Ɍ������f��",
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
                    Name = "�[��Ɍ������f��",
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
                    Name = "�A�x��������",
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
                    Name = "�v�v�v�v�v�v�v�v�v�v�v�v�v�v�v�v",
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
