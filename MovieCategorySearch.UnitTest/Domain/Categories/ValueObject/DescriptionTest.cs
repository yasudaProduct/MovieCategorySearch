using Merino.Test;
using MovieCategorySearch.Domain.Categories.ValueObject;

namespace MovieCategorySearch.UnitTest.Domain.Categories.ValueObject
{
    /// <summary>
    /// ディスクリプションのテストクラスです。
    /// </summary>
    public class DescriptionTest : MerinoUnitTest
    {
        /// <summary>
        /// 有効な値を使用してディスクリプションのインスタンスが作成されることをテストします。
        /// </summary>
        [Fact]
        public void Description_WithValidValue_ShouldCreateInstance()
        {
            // Arrange
            string validValue = "Valid Description";

            // Act
            Description description = new Description(validValue);

            // Assert
            Assert.Equal(validValue, description.Value);
        }

        /// <summary>
        /// 無効な値を使用した場合に引数例外がスローされることをテストします。
        /// </summary>
        /// <param name="invalidValue">無効な値</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Description_WithInvalidValue_ShouldThrowArgumentException(string invalidValue)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Description(invalidValue));
        }

        /// <summary>
        /// 最大文字数を超える値を使用した場合に引数例外がスローされることをテストします。
        /// </summary>
        [Fact]
        public void Description_WithValueExceedingMaxLength_ShouldThrowArgumentException()
        {
            // Arrange
            string valueExceedingMaxLength = new string('A', 101);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Description(valueExceedingMaxLength));
        }
    }
}
