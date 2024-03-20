namespace MovieCategorySearch.Application.Usecase.Categories.Dto
{
    public class CreateCategoryCommand
    {
        public CreateCategoryCommand(string CategoryName, string Description , int createUserId)
        {
            this.CategoryName = CategoryName;
            this.Description = Description;
            this.CreateUserId = createUserId;
        }

        public string CategoryName { get; private set; }

        public string Description { get; private set; }

        public int CreateUserId { get; private set; }
    }
}
