namespace MovieCategorySearch.Application.Domain.Categories
{
    public interface ICategoryRepository
    {
        public Category Find(int id);
        public int Save(Category category);
    }
}
