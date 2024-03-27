using Merino.Domain;
using MovieCategorySearch.Application.Domain.Categories.ValueObject;

namespace MovieCategorySearch.Application.Domain.Categories
{
    public class Category //: MainteNanceValueObject
    {
        public Category(int? id, CategoryName categoryName, int userId, Description? description = null) //: base(userId)
        {

            if (categoryName == null) throw new ArgumentNullException(nameof(categoryName));
            if (userId == null) throw new ArgumentNullException(nameof(userId));

            Id = id;
            CategoryName = categoryName;
            Description = description;
            CreateUserId = userId;

        }

        public int? Id { get; }

        public CategoryName CategoryName { get; private set; }

        public Description Description { get; private set; }

        public int CreateUserId { get; private set; }

        internal void ChangeName(CategoryName name, Description description = null)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            CategoryName = name;
            if (description != null)
            {
                Description = description;
            }

        }

    }
}
