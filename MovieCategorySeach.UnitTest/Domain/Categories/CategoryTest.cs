using Merino.Test;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;

namespace MovieCategorySeach.UnitTest.Domain.Categories
{
    /// <summary>
    /// テストクラスの説明
    /// </summary>
    public class CategoryTest : MerinoUnitTest
    {
        /// <summary>
        /// ChangeNameメソッドのテスト
        /// </summary>
        [Fact]
        public void ChangeName_ShouldUpdateCategoryName()
        {
            // Arrange
            var id = 1;
            var categoryName = new CategoryName("Action");
            var userId = 100;
            var category = new Category(id, categoryName, userId);

            var newName = new CategoryName("Adventure");

            // Act
            category.ChangeName(newName);

            // Assert
            Assert.Equal(newName, category.CategoryName);
        }

        /// <summary>
        /// ChangeNameメソッドのテスト
        /// </summary>
        [Fact]
        public void ChangeName_ShouldUpdateCategoryDescription()
        {
            // Arrange
            var id = 1;
            var categoryName = new CategoryName("Action");
            var userId = 100;
            var category = new Category(id, categoryName, userId, new Description("Action movies"));

            var newName = new CategoryName("Adventure");
            var newDescription = new Description("Adventure movies");

            // Act
            category.ChangeName(newName, newDescription);

            // Assert
            Assert.Equal(newName, category.CategoryName);
            Assert.Equal(newDescription, category.Description);
        }
    }
}
