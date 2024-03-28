using MovieCategorySearch.Application.Movie.Dto;
using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.UseCase.Movie
{
    public interface IMovieService
    {
        public Task<List<MovieResult>> GetMovieList();

        public Task<List<MovieResult>> Search(string title);

        public Task<MovieResult> GetDetails(int tmdbId);

        public Task<bool> AddMovieCreate(AddCategoryRequest request);
    }
}
