using Microsoft.EntityFrameworkCore;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Infrastructure.Data;
using System.Collections.Generic;

namespace MovieCategorySearch.Infrastructure.QueryServices
{

    /// <summary>
    /// 映画データをクエリするためのメソッドを提供します。
    /// </summary>
    public class MovieQueryService : IMovieQueryService
    {
        private readonly PostgresDbContext _dbContext;

        /// <summary>
        /// <see cref="MovieQueryService"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="dbContext">データベースコンテキスト。</param>
        public MovieQueryService(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 指定されたTMDb IDに基づいて映画を取得します。
        /// </summary>
        public MovieQueryResult? GetbyTmdbId(int tmdbId)
        {
            var movie = _dbContext.Movie
                .Include(a => a.CategoryMaps).ThenInclude(map => map.Category)
                .Where(x => x.TmdbMovieId == tmdbId).ToList().FirstOrDefault();

            if (movie == null) return null;

            var category = _dbContext.CategoryMap.FirstOrDefault();

            Dictionary<int, string> dic = new Dictionary<int, string>();

            foreach (var map in movie.CategoryMaps)
            {
                dic.Add(map.Category.Id, map.Category.Name);
            }
            

            return new MovieQueryResult()
            {
                TmdbMovieId = movie.TmdbMovieId,
                CategoryList = dic
            };
        }

    }
}
