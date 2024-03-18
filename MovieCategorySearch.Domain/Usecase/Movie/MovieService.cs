using Microsoft.Extensions.Logging;
using MovieCategorySearch.Application.Domain.Movie;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.Usecase.Movie.Dto;
using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public class MovieService : IMovieService
    {
        private readonly ILogger _logger;

        private readonly IMovieRepository _movieRpository;

        private readonly ITmdbApiClient _tmdbApiClient;
        public MovieService(
            ILogger<MovieService> logger,
            IMovieRepository movieRpository,
            ITmdbApiClient tmdbApiClient
        )
        {
            _logger = logger;
            _movieRpository = movieRpository;
            _tmdbApiClient = tmdbApiClient;
        }

        public async Task<List<MovieResult>> GetMovieList()
        {

            //TmdbApiからデータを取得
            TmdbApiResponce reqest = await _tmdbApiClient.RunAsync();

            //TODO TmdbIdを元にDBからデータを取得
            //Factoryを使ってデータを作成？
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
