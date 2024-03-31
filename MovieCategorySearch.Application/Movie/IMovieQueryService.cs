using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public interface IMovieQueryService
    {
        public MovieQueryResult GetbyTmdbId(int tmdbId);
        
        public Task<List<MovieQueryResult>> GetPopularMovies();

        public Task<MovieQueryResult> SearchCollection(string title);

        public Task<MovieQueryResult> GetDetails(int tmdbId);
    }
}
