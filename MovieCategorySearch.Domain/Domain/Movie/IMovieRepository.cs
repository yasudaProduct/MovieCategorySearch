namespace MovieCategorySearch.Application.Domain.Movie
{
    public interface IMovieRepository
    {
        public List<Movie> FindAll();
    }
}
