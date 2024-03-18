using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Infrastructure.Data;
using MovieCategorySearch.Infrastructure.Data.Entity;
using System.Linq.Expressions;

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
          
            Queue<Expression<Func<Movie, bool>>> condList = new Queue<Expression<Func<Movie, bool>>>();

            if (!string.IsNullOrWhiteSpace(title))
            {
                condList.Enqueue(x => x.Title.Contains(title));
            }

            var query = _dbContext.Movie.AsQueryable();

            while (condList.Count != 0)
            {
                //Queryを追加しているだけ
                query = query.Where(condList.Dequeue());
            }

            //Query実行
            var movieList = query.ToList();

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
