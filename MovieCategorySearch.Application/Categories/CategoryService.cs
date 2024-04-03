using Microsoft.Extensions.Logging;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;
using MovieCategorySearch.Domain.Movie;

namespace MovieCategorySearch.Application.UseCase.Categories
{
    public interface ICategoryService
    {
        public Task<CategoryDetailsDto> Find(int id);

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


        public async Task<CategoryDetailsDto> Find(int id)
        {
            // Categoryを取得
            Category category = await _categoryRepository.Find(id) ?? null;

            if (category == null) return null;

            List<MovieResult> movies = category.Movies.Select(m =>  new MovieResult
            {
                TmdbMovieId = m.TmdbMovieId,
                Title = m.Title,
                Overview = m.Overview,
                PosterPath = m.PosterPath,
                ReleaseDate = m.ReleaseDate,
                Category = m.Categorys != null ? m.Categorys.ToDictionary(x => (int)x.Id, x => x.CategoryName.Value) : null
            }).ToList();

            return new CategoryDetailsDto(
                category.Id.Value,
                category.CategoryName.Value,
                category.Description?.Value,
                movies
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
                command.CreateUserId,
                new CategoryName(command.CategoryName),
                command.Description != null ? new Description(command.Description) : null
                );

            //リポジトリに保存
            return _categoryRepository.Save(category);
        }

    }
}