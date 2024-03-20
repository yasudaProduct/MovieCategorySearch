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

        private readonly IMovieQueryService _movieQueryService;

        private readonly ITmdbApiClient _tmdbApiClient;
        public MovieService(
            ILogger<MovieService> logger,
            IMovieRepository movieRpository,
            IMovieQueryService movieQueryService,
            ITmdbApiClient tmdbApiClient
        )
        {
            _logger = logger;
            _movieRpository = movieRpository;
            _movieQueryService = movieQueryService;
            _tmdbApiClient = tmdbApiClient;
        }

        public async Task<List<MovieResult>> GetMovieList()
        {

            //TmdbApiからデータを取得
            TmdbApiResponce reqest = await _tmdbApiClient.GetPopular();

            List<MovieResult> movieResultList = new List<MovieResult>();

            //MovieResultを作成 TODO Factoryにする？
            foreach(var movie in reqest.results)
            {

                movieResultList.Add(new MovieResult
                {
                    TmdbMovieId = movie.id,
                    Title = movie.title,
                    Overview = movie.overview,
                });

            }

            return movieResultList;
        }

        public async Task<List<MovieResult>> Search(string title)
        {
            //TmdbApiからデータを取得
            TmdbApiResponce reqest = await _tmdbApiClient.SearchCollection(title);

            List<MovieResult> movieResultList = new List<MovieResult>();

            foreach (var movie in reqest.results)
            {

                movieResultList.Add(new MovieResult
                {
                    TmdbMovieId = movie.id,
                    Title = movie.title,
                    Overview = movie.overview,
                });

            }

            return movieResultList;
        }
    }
}