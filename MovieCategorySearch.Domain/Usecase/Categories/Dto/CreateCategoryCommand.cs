namespace MovieCategorySearch.Application.Usecase.Categories.Dto
{
    public class CreateCategoryCommand
    {
        public CreateCategoryCommand(string CategoryName, string Description)
        {
            this.CategoryName = CategoryName;
            this.Description = Description;
        }

        public string CategoryName { get; private set; }

        public string Description { get; private set; }
    }
}
