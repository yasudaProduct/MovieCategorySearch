namespace MovieCategorySearch.Application.UseCase.Movie.Dto
{

    public class MovieQueryResult
    {

        public int TmdbMovieId { get; set; }

        public string Title { get; set; }

        public string OverView { get; set; }

        public string PosterPath { get; set; }

        public Dictionary<int, string> CategoryList { get; set; }

    }

}


