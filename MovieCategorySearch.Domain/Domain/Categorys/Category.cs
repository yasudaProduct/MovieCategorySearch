using MovieCategorySearch.Application.Domain.Categorys.ValueObject;

namespace MovieCategorySearch.Application.Domain.Categorys
{
    public class Category
    {
        public Category(int? id, CategoryName categoryName, Description? description = null)
        {
            if (categoryName == null) throw new ArgumentNullException(nameof(categoryName));

            Id = id;
            CategoryName = categoryName;
            Description = description;
        }

        public int? Id { get; }

        public CategoryName CategoryName { get; private set; }

        public Description Description { get; private set; }

        internal void ChangeName(CategoryName name, Description description = null)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            CategoryName = name;
            if(description != null)
            {
                Description = description;
            }
            
        }

    }
}
