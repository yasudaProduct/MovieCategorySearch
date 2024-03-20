namespace MovieCategorySearch.Application.Usecase.Categories.Dto
{
    public class CategoryDetailsDto
    {
        public CategoryDetailsDto(int id, string categoryName, string description)
        {
            this.Id = id;
            this.CategoryName = categoryName;
            this.Description = description;
        }

        public int Id { get; private set; }

        public string CategoryName { get; private set; }

        public string Description { get; private set; }
    }
}
