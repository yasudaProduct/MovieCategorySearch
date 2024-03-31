using MovieCategorySearch.Application.Usecase.Movie;

namespace MovieCategorySearch.Infrastructure.Factory
{
    public class MovieFactory : IMovieFactory
    {

        private readonly ITmdbApiClient _tmdbApiClient;

        public MovieFactory(ITmdbApiClient tmdbApiClient)
        {
            _tmdbApiClient = tmdbApiClient;
        }

        public async Task<Domain.Movie.Movie> CreateMovie(int tmdbId)
        {
            var result = await _tmdbApiClient.GetDetails(tmdbId);

            return new Domain.Movie.Movie(
                    result.id,
                    result.title,
                    result.overview,
                    result.poster_path,
                    result.release_date
                    );
        }
    }
}
