namespace MovieCategorySearch.Domain.Categories
{
    public interface ICategoryRepository
    {
        public Task<Category> Find(int id);

        public List<Category> FindAll();

        public int Save(Category category);
    }
}
