using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public interface IMovieService
    {
        public Task<List<MovieResult>> GetMovieList();

        public Task<List<MovieResult>> Search(string title);
    }
}
