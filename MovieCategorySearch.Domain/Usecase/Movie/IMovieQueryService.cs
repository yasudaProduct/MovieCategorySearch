using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public interface IMovieQueryService
    {
        public MovieQueryResult GetbyTmdbId(int tmdbId);
        public List<MovieQueryResult> SearchMovieList(string title);
    }
}
