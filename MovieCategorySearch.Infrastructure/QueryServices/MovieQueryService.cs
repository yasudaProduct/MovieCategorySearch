using Microsoft.EntityFrameworkCore;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.QueryServices
{

    /// <summary>
    /// 映画データをクエリするためのメソッドを提供します。
    /// </summary>
    public class MovieQueryService : IMovieQueryService
    {
        private readonly PostgresDbContext _dbContext;

        private readonly ITmdbApiClient _tmdbApiClient;

        /// <summary>
        /// <see cref="MovieQueryService"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="dbContext">データベースコンテキスト。</param>
        public MovieQueryService(PostgresDbContext dbContext, ITmdbApiClient tmdbApiClient)
        {
            _dbContext = dbContext;
            _tmdbApiClient = tmdbApiClient;
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

            //var category = _dbContext.CategoryMap.FirstOrDefault();

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

        public async Task<List<MovieQueryResult>> GetPopularMovies()
        {
            // TmdbApiからデータを取得
            var responce = await _tmdbApiClient.GetPopular();

            // 映画に紐づくカテゴリを取得
            //var movie = _dbContext.Movie
            //    .Include(a => a.CategoryMaps).ThenInclude(map => map.Category)
            //    .Where(x => responce.results.Select(r => r.id).Contains(x.TmdbMovieId))
            //    .ToList();

            var result = new List<MovieQueryResult>();
            foreach (var item in responce.results)
            {
                var categoryMap = _dbContext.CategoryMap.Where(cm => cm.MovieId == item.id).Include(a => a.Category).ToList();

                result.Add(new MovieQueryResult() { 
                    TmdbMovieId = item.id,
                    Title = item.title,
                    OverView = item.overview,
                    PosterPath = item.poster_path,
                    CategoryList = categoryMap.ToDictionary(cm => cm.Category.Id, cm => cm.Category.Name)
                });
            }

            return result;
        }

        public async Task<MovieQueryResult> SearchCollection(string title)
        {
            var responce = await _tmdbApiClient.SearchCollection(title);

            return new MovieQueryResult()
            {
                TmdbMovieId = responce.results[0].id,
                Title = responce.results[0].title,
                OverView = responce.results[0].overview
            };
        }

        public async Task<MovieQueryResult> GetDetails(int tmdbId)
        {
            var responce = await _tmdbApiClient.GetDetails(tmdbId);

            return new MovieQueryResult()
            {
                TmdbMovieId = responce.id,
                Title = responce.title,
                OverView = responce.overview
            };
        }

    }
}
