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
            var movie = _dbContext.Movie.FirstOrDefault(x => x.TmdbMovieId == tmdbId);

            if (movie == null)
            {
                return null;
            }

            return new MovieQueryResult()
            {
                TmdbMovieId = movie.TmdbMovieId,
            };
        }

        /// <summary>
        /// 指定されたタイトルに基づいて映画リストを検索します。
        /// </summary>
        /// <param name="title">検索するタイトル。</param>
        /// <returns>映画の結果のリスト。</returns>
        //public List<MovieQueryResult> SearchMovieList(string title)
        //{
        //    //TODO TmdbApiから取得した映画情報を取得

        //    Queue<Expression<Func<Movie, bool>>> condList = new Queue<Expression<Func<Movie, bool>>>();

        //    //検索条件を追加
        //    if (!string.IsNullOrWhiteSpace(title))
        //    {
        //        condList.Enqueue(x => x.Title.Contains(title));
        //    }

        //    //検索条件を追加
        //    var query = _dbContext.Movie.AsQueryable();
        //    while (condList.Count != 0)
        //    {
        //        query = query.Where(condList.Dequeue());
        //    }

        //    //クエリ実行
        //    var movieList = query.ToList();

        //    List<MovieQueryResult> result = new List<MovieQueryResult>();
        //    foreach (var movie in movieList)
        //    {
        //        result.Add(new MovieQueryResult()
        //        {
        //            TmdbMovieId = movie.TmdbMovieId,
        //        });
        //    }

        //    return result;
        //}

    }
}
