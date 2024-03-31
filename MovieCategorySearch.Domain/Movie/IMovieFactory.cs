namespace MovieCategorySearch.Application.Usecase.Movie
{

    public interface IMovieFactory
    {
        Task<Domain.Movie.Movie> CreateMovie(int tmdbId);
    }
}
