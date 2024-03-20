using MovieCategorySearch.Application.Usecase.Movie.Dto;

namespace MovieCategorySearch.Application.Usecase.Movie
{
    public interface ITmdbApiClient
    {

        public Task<TmdbApiResponce> RunAsync();

        public Task<TmdbApiResponce> GetPopular();

        public Task<TmdbApiResponce> SearchCollection(string title);
    }
}
