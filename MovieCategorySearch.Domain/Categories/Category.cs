using MovieCategorySearch.Domain.Categories.ValueObject;

namespace MovieCategorySearch.Domain.Categories
{
    public class Category //: MainteNanceValueObject
    {
        public Category(
            int? id,
            int userId,
            CategoryName categoryName,
            Description? description = null,
            List<Domain.Movie.Movie> movies = null)
        {

            if (categoryName == null) throw new ArgumentNullException(nameof(categoryName));
            if (userId == null) throw new ArgumentNullException(nameof(userId));

            Id = id;
            CategoryName = categoryName;
            Description = description;
            CreateUserId = userId;
            Movies = movies;
        }

        public int? Id { get; }

        public CategoryName CategoryName { get; private set; }

        public Description Description { get; private set; }

        public int CreateUserId { get; private set; }

        public List<Domain.Movie.Movie> Movies { get; private set; }

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
