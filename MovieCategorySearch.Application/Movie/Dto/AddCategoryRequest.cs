namespace MovieCategorySearch.Application.Movie.Dto
{
    public class AddCategoryRequest
    {

        public int TmdbId { get; set; }

        public int UserId { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}
