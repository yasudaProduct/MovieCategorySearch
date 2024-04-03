using Microsoft.Extensions.Logging;
using MovieCategorySearch.Application.Movie.Dto;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;
using MovieCategorySearch.Domain.Movie;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public class MovieService : IMovieService
    {
        private readonly ILogger _logger;

        private readonly IMovieRepository _movieRpository;

        private readonly IMovieQueryService _movieQueryService;

        public MovieService(
            ILogger<MovieService> logger,
            IMovieRepository movieRpository,
            IMovieQueryService movieQueryService
        )
        {
            _logger = logger;
            _movieRpository = movieRpository;
            _movieQueryService = movieQueryService;
        }

        public async Task<List<MovieResult>> GetMovieList()
        {
            List<MovieResult> movieResultList = new List<MovieResult>();

            List<MovieQueryResult> list =  await _movieQueryService.GetPopularMovies(); 

            // MovieResultを作成 TODO Factoryにする？
            foreach(var movie in list)
            {
                movieResultList.Add(new MovieResult
                {
                    TmdbMovieId = movie.TmdbMovieId,
                    Title = movie.Title,
                    Overview = movie.OverView,
                    Category = list.Where(m => m.TmdbMovieId == movie.TmdbMovieId).Select(c => c.CategoryList).FirstOrDefault(),
                    PosterPath = movie.PosterPath
                });

            }

            return movieResultList;
        }

        public async Task<List<MovieResult>> Search(string title)
        {
            //TmdbApiからデータを取得
            MovieQueryResult result = await _movieQueryService.SearchCollection(title);

            List<MovieResult> movieResultList = new List<MovieResult>();

                movieResultList.Add(new MovieResult
                {
                    TmdbMovieId = result.TmdbMovieId,
                    Title = result.Title,
                    Overview = result.OverView,
                });

            return movieResultList;
        }

        public async Task<MovieResult> GetDetails(int tmdbId)
        {
            MovieQueryResult result = await _movieQueryService.GetDetails(tmdbId);

            return new MovieResult()
            {
                TmdbMovieId = result.TmdbMovieId,
                Title = result.Title,
                Overview = result.OverView,
                ReleaseDate = result.ReleaseDate,
                PosterPath = result.PosterPath,
                Category = result.CategoryList
            };
        }

        public async Task<int> AddMovieCreate(AddCategoryRequest request)
        {
            // Idチェック

            // Category作成
            // TODO Factoryにする
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