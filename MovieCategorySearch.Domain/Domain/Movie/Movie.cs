namespace MovieCategorySearch.Application.Domain.Movie
{
    public class Movie
    {

        public Movie(int Id, int TmdbMovieId, string Title)
        {
            this.Id = Id;
            this.TmdbMovieId = TmdbMovieId;
            this.Title = Title;
        }

        public int Id { get; }

        public int TmdbMovieId { get; }
        
        public string Title { get; }

    }
}
