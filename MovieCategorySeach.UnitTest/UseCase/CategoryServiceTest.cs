using Merino.Test;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.UseCase.Categories;
using MovieCategorySearch.Domain.Movie;

namespace MovieCategorySeach.UnitTest.UseCase
{
    /// <summary>
    /// カテゴリサービスのテストクラスです。
    /// </summary>
    public class CategoryServiceTest : MerinoUnitTest
    {
        private CategoryService _service;

        private Mock<ICategoryRepository> _mockICategoryRepository;

        /// <summary>
        /// CategoryServiceTest のコンストラクタです。
        /// </summary>
        public CategoryServiceTest()
        {
            //Arrange
            Mock<ILogger<CategoryService>> mockILogger = new Mock<ILogger<CategoryService>>();

            _mockICategoryRepository = new Mock<ICategoryRepository>();
            _service = new CategoryService(mockILogger.Object, _mockICategoryRepository.Object);
        }      

        /// <summary>
        /// Find メソッドがカテゴリを見つけた場合に CategoryDetailsDto を返すことをテストします。
        /// </summary>
        [Fact]
        public async void Find_ReturnsCategoryDetailsDto_WhenCategoryFound()
        {

            //Arrange
            _mockICategoryRepository.Setup(mock => mock.Find(1))
                .ReturnsAsync(new Category(1, 1, new CategoryName("カテゴリ名１"), new Description("説明１"), new List<Movie>()));

            //Act
            var result = await _service.Find(1);

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

            //Arrange
            _mockICategoryRepository.Setup(mock => mock.Find(2)).ReturnsAsync((Category)null);

            //Act
            var result = _service.Find(2);

            //Assert
            Assert.Null(result.Result);
        }

        /// <summary>
        /// FindAll メソッドが CategoryDetailsDto のリストを返すことをテストします。
        /// </summary>
        [Fact]
        public async void FindAll_ReturnsCategoryDetailsDtoList()
        {
            //Arrange
            _mockICategoryRepository.Setup(mock => mock.FindAll())
                .Returns(new List<Category>()
                {
                        new Category(1,1, new CategoryName("テスト１"), new Description("テスト２"), new List<Movie>()),
                        new Category(1,1, new CategoryName("テスト１"), new Description("テスト２"), new List<Movie>()),
                        new Category(1,1, new CategoryName("テスト１"), new Description("テスト２"), new List<Movie>())
                });

            //Act
            var result = _service.FindAll();

            //Assert
            //Assert.IsType<IEnumerable<CategoryDetailsDto>>(result);
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
            _mockICategoryRepository.Setup(repo => repo.Save(It.IsAny<Category>())).Returns(1);

            // Act
            var result = _service.Create(command);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
