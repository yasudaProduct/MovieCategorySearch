using Microsoft.Extensions.Logging;
using MovieCategorySearch.Application.Usecase.Category.Dto;
using MovieCategorySearch.Application.Domain.Categorys;
using MovieCategorySearch.Application.Domain.Categorys.ValueObject;

namespace MovieCategorySearch.Application.UseCase.Category
{
    public interface ICategoryService
    {
        public void Create(CreateCategoryCommand commnad);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ILogger _logger;

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
            ILogger<CategoryService> logger,
            ICategoryRepository categoryRepository
        )
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public void Create(CreateCategoryCommand command)
        {
            //ドメインモデル作成
            var category = new Domain.Categorys.Category(
                null,
                new CategoryName(command.CategoryName),
                new Description(command.Description)
                );

            //リポジトリに保存
            _categoryRepository.Save(category);
        }
    }
}