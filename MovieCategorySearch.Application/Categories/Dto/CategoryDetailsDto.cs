using MovieCategorySearch.Application.UseCase.Movie.Dto;

namespace MovieCategorySearch.Application.Usecase.Categories.Dto
{
    public class CategoryDetailsDto
    {
        public CategoryDetailsDto(int id, string categoryName, string description, List<MovieResult> movies = null)
        {
            this.Id = id;
            this.CategoryName = categoryName;
            this.Description = description;
            this.Movies = movies;
        }

        public int Id { get; private set; }

        public string CategoryName { get; private set; }

        public string Description { get; private set; }

        public List<MovieResult>? Movies { get; private set; }
    }
}
