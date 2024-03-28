using Merino.Test;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.UseCase.Categories;

namespace MovieCategorySeach.UnitTest.UseCase
{
    /// <summary>
    /// カテゴリサービスのテストクラスです。
    /// </summary>
    public class CategoryServiceTest : MerinoUnitTest
    {
        private CategoryService _service;

        /// <summary>
        /// CategoryServiceTest のコンストラクタです。
        /// </summary>
        public CategoryServiceTest()
        {
            //Arrange
            Mock<ILogger<CategoryService>> mockILogger = new Mock<ILogger<CategoryService>>();

            Mock<ICategoryRepository> mockICategoryRepository = new Mock<ICategoryRepository>();
            mockICategoryRepository.Setup(mock => mock.Find(1))
                .Returns(new Category(1, 1, new CategoryName("カテゴリ名１"), new Description("説明１")));

            mockICategoryRepository.Setup(mock => mock.FindAll())
                .Returns(new List<Category>()
                {
                        new Category(1,1, new CategoryName("テスト１"), new Description("テスト２")),
                        new Category(1,1, new CategoryName("テスト１"), new Description("テスト２")),
                        new Category(1,1, new CategoryName("テスト１"), new Description("テスト２"))
                });

            mockICategoryRepository.Setup(repo => repo.Save(It.IsAny<Category>())).Returns(1);

            _service = new CategoryService(mockILogger.Object, mockICategoryRepository.Object);
        }      

        /// <summary>
        /// Find メソッドがカテゴリを見つけた場合に CategoryDetailsDto を返すことをテストします。
        /// </summary>
        [Fact]
        public async void Find_ReturnsCategoryDetailsDto_WhenCategoryFound()
        {
            //Act
            var result = _service.Find(1);

            //Assert
            Assert.IsType<CategoryDetailsDto>(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("カテゴリ名１", result.CategoryName);
            Assert.Equal("説明１", result.Description);

        }

        /// <summary>
        /// Find メソッドがカテゴリを見つけられなかった場合に null を返すことをテストします。
        /// </summary>
        [Fact]
        public async void Find_ReturnsNull_WhenCategoryNotFound()
        {
            //Act
            var result = _service.Find(2);

            //Assert
            Assert.Null(result);
        }

        /// <summary>
        /// FindAll メソッドが CategoryDetailsDto のリストを返すことをテストします。
        /// </summary>
        [Fact]
        public async void FindAll_ReturnsCategoryDetailsDtoList()
        {
            //Act
            var result = _service.FindAll();

            //Assert
            Assert.IsType<IEnumerable<CategoryDetailsDto>>(result);
            Assert.Equal(3, result.Count());
        }

        /// <summary>
        /// Create メソッドがカテゴリを作成した場合にカテゴリの ID を返すことをテストします。
        /// </summary>
        [Fact]
        public void Create_ShouldReturnCategoryId_WhenCategoryIsCreated()
        {
            // Arrange
            var command = new CreateCategoryCommand("Action", "Action movies", 1);

            // Act
            var result = _service.Create(command);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
