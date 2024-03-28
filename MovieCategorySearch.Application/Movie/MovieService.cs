using Microsoft.Extensions.Logging;
using MovieCategorySearch.Domain.Movie;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.Usecase.Movie.Dto;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Application.Movie.Dto;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;

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
            List<MovieResult> movieResultList = new List<MovieResult>();

            // TmdbApiからデータを取得
            TmdbApiResponce reqest = await _tmdbApiClient.GetPopular();

            List<MovieQueryResult> list = new List<MovieQueryResult>();

            foreach (var movie in reqest.results)
            {
                // MovieRositoryからデータを取得
                var res = _movieQueryService.GetbyTmdbId(movie.id);
                if(res != null) list.Add(res);
            }
                       

            // MovieResultを作成 TODO Factoryにする？
            foreach(var movie in reqest.results)
            {

                movieResultList.Add(new MovieResult
                {
                    TmdbMovieId = movie.id,
                    Title = movie.title,
                    Overview = movie.overview,
                    Category = list.Where(m => m.TmdbMovieId == movie.id).Select(c => c.CategoryList).FirstOrDefault(),
                    PosterPath = movie.poster_path
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

        public async Task<MovieResult> GetDetails(int tmdbId)
        {
            TmdbMovieDetailsResponce reqest = await _tmdbApiClient.GetDetails(tmdbId);

            MovieResult result = new MovieResult()
            {
                TmdbMovieId = reqest.id,
                Title = reqest.title,
                Overview = reqest.overview,
                ReleaseDate = reqest.release_date,
            };

            return result;
        }

        public async Task<bool> AddMovieCreate(AddCategoryRequest request)
        {
            // Idチェック

            // Category作成
            var category = new Category(
                null,
                request.UserId,
                new CategoryName(request.CategoryName),
                new Description(request.Description)
                );

            return _movieRpository.AddCategory(request.TmdbId, category);
        }

    }
}