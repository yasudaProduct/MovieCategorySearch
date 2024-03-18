using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Infrastructure.Data;
using MovieCategorySearch.Infrastructure.Data.Entity;
using System.Linq.Expressions;
using Merino.Utils;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace MovieCategorySearch.Infrastructure.QueryServices
{
    public class MovieQueryService : IMovieQueryService
    {
        private readonly PostgresDbContext _dbContext;

        public MovieQueryService(PostgresDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<MovieResult> SearchMovieList(string title)
        {
            //条件作成
            Expression<Func<Movie, bool>> condition1 = x => x.Title == "When Harry Met Sally";
            Expression<Func<Movie, bool>> condition2 = x => x.TmdbMovieId == 1;           

            // 条件を組み合わせて動的に構築します。
            var parameter = Expression.Parameter(typeof(Movie), "e");
            var combinedCondition = Expression.Lambda<Func<Movie, bool>>(
                Expression.AndAlso(
                    Expression.Invoke(condition1, parameter),
                    Expression.Invoke(condition2, parameter)
                ),
                parameter
            );

            var movieList = _dbContext.Movie.Where(combinedCondition);

            List<MovieResult> result = new List<MovieResult>();
            foreach (var movie in movieList)
            {
                result.Add(new MovieResult()
                {
                    Id = movie.Id,
                    TmdbMovieId = movie.TmdbMovieId,
                    Title = movie.Title
                });
            }

            return result;
        }


    }

}
class ParameterReplacer<T> : ExpressionVisitor
{
    public ParameterExpression Parameter { get; }

    public ParameterReplacer(ParameterExpression? p = null)
    {
        Parameter = p ?? Expression.Parameter(typeof(T), "x");
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return Parameter;
    }
}
