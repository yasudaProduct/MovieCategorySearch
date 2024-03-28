namespace MovieCategorySearch.Application.UseCase.Movie.Dto
{

    public class MovieResult
    {

        public int TmdbMovieId { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        public string[] Genres { get; set; }

        public Dictionary<int,string> Category { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PosterPath { get; set; }

    }

}


