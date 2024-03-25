using Microsoft.Extensions.Logging;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.Domain.Categories;
using MovieCategorySearch.Application.Domain.Categories.ValueObject;

namespace MovieCategorySearch.Application.UseCase.Categories
{
    public interface ICategoryService
    {
        public CategoryDetailsDto Find(int id);

        public IEnumerable<CategoryDetailsDto> FindAll();

        public int Create(CreateCategoryCommand commnad);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ILogger _logger;

        private readonly ICategoryRepository _categoryRepository;

        #region コンストラクタ
        public CategoryService(
            ILogger<CategoryService> logger,
            ICategoryRepository categoryRepository
        )
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        #endregion


        public CategoryDetailsDto Find(int id)
        {

            Category category = _categoryRepository.Find(id) ?? null;

            if (category == null) return null;

            return new CategoryDetailsDto(
                category.Id.Value,
                category.CategoryName.Value,
                category.Description?.Value
                );
        }

        public IEnumerable<CategoryDetailsDto> FindAll()
        {
            var categoryList = _categoryRepository.FindAll();

            foreach (var category in categoryList)
            {
                yield return new CategoryDetailsDto(
                    category.Id.Value,
                    category.CategoryName.Value,
                    category.Description?.Value
                    );
            }
        }

        public int Create(CreateCategoryCommand command)
        {
            //ドメインモデル作成
            var category = new Category(
                null,
                new CategoryName(command.CategoryName),
                command.CreateUserId,
                command.Description != null ? new Description(command.Description) : null
                );

            //リポジトリに保存
            return _categoryRepository.Save(category);
        }

    }
}