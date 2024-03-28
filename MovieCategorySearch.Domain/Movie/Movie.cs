namespace MovieCategorySearch.Domain.Movie
{
    public class Movie
    {

        public Movie(int TmdbMovieId, string Title)
        {
            this.TmdbMovieId = TmdbMovieId;
            this.Title = Title;
        }

        public int TmdbMovieId { get; }
        
        public string Title { get; }

    }
}
