namespace MovieCategorySearch.Domain.Movie
{
    public interface IMovieRepository
    {
        public int? GetById(int id);
    }
}
