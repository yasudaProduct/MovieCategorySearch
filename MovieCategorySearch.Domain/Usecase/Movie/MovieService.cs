using Microsoft.Extensions.Logging;
using MovieCategorySearch.Application.Domain.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public class MovieService : IMovieService
    {
        private readonly ILogger _logger;

        private readonly IMovieRepository _movieRpository;
        public MovieService(
            ILogger<MovieService> logger,
            IMovieRepository movieRpository
        )
        {
            _logger = logger;
            _movieRpository = movieRpository;
        }

        public List<MovieResult> GetMovieList()
        {
            List<Domain.Movie.Movie> movieList = _movieRpository.FindAll();


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
