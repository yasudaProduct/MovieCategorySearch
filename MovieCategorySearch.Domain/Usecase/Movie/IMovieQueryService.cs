using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public interface IMovieQueryService
    {
        public List<MovieResult> SearchMovieList(string title);
    }
}
