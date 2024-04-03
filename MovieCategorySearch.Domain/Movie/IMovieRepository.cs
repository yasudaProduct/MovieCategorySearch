using MovieCategorySearch.Domain.Categories;

namespace MovieCategorySearch.Domain.Movie
{
    public interface IMovieRepository
    {
        public int? GetById(int id);

        public int AddCategory(int TmdbId, Category category);
    }
}
