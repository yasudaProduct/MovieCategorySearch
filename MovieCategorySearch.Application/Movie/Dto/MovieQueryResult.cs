namespace MovieCategorySearch.Application.UseCase.Movie.Dto
{

    public class MovieQueryResult
    {

        public int TmdbMovieId { get; set; }

        public Dictionary<int, string> CategoryList { get; set; }

    }

}


