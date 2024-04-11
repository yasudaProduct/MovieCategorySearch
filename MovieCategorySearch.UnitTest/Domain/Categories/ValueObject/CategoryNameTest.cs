using Merino.Test;
using MovieCategorySearch.Domain.Categories.ValueObject;

namespace MovieCategorySearch.UnitTest.Domain.Categories.ValueObject
{
    public class CategoryNameTest : MerinoUnitTest
    {
        [Fact]
        public void CategoryName_ValidValue_CreatesInstance()
        {
            // Arrange
            string value = "Action";

            // Act
            CategoryName categoryName = new CategoryName(value);

            // Assert
            Assert.NotNull(categoryName);
            Assert.Equal(value, categoryName.Value);
        }

        [Fact]
        public void CategoryName_NullValue_ThrowsArgumentException()
        {
            // Arrange
            string value = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CategoryName(value));
        }

        [Fact]
        public void CategoryName_EmptyValue_ThrowsArgumentException()
        {
            // Arrange
            string value = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CategoryName(value));
        }

        [Fact]
        public void CategoryName_WhitespaceValue_ThrowsArgumentException()
        {
            // Arrange
            string value = "   ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CategoryName(value));
        }

        [Fact]
        public void CategoryName_LongValue_ThrowsArgumentException()
        {
            // Arrange
            string value = "This is a very long category name that exceeds the maximum allowed length of 50 characters";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CategoryName(value));
        }
    }
}
