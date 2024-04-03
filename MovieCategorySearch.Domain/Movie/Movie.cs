using MovieCategorySearch.Domain.Categories;

namespace MovieCategorySearch.Domain.Movie
{
    public class Movie
    {

        public Movie(
            int tmdbMovieId,
            string title,
            string overview,
            string posterPath,
            DateTime releaseDate,
            List<Category> categorys)
        {
            this.TmdbMovieId = tmdbMovieId;
            this.Title = title;
            this.Overview = overview;
            this.PosterPath = posterPath;
            this.ReleaseDate = releaseDate;
            this.Categorys = categorys;
        }

        public int TmdbMovieId { get; }
        
        public string Title { get; }

        public string Overview { get; }

        public string PosterPath { get; }

        public DateTime ReleaseDate { get; }

        public List<Category> Categorys { get; }

    }
}
