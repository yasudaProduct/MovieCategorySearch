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

            //TmdbApi����f�[�^���擾
            TmdbApiResponce reqest = await _tmdbApiClient.GetPopular();

            List<MovieResult> movieResultList = new List<MovieResult>();

            //MovieResult���쐬 TODO Factory�ɂ���H
            foreach(var movie in reqest.results)
            {

                MovieResult mr = new MovieResult
                {
                    TmdbMovieId = movie.id,
                    Title = movie.title,
                    Overview = movie.overview,
                };

                MovieQueryResult res = _movieQueryService.GetbyTmdbId(movie.id);
                if(res != null)
                {
                    mr.Id = res.Id;
                }

                //TmdbId������DB����f�[�^���擾
                movieResultList.Add(mr);
            }

            return movieResultList;
        }
    }
}