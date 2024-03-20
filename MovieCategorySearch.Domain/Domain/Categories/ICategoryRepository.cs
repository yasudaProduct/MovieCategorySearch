namespace MovieCategorySearch.Application.Domain.Categories
{
    public interface ICategoryRepository
    {
        public Category Find(int id);

        public List<Category> FindAll();

        public int Save(Category category);
    }
}
