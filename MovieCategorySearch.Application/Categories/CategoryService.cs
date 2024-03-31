using Microsoft.Extensions.Logging;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Domain.Categories;
using MovieCategorySearch.Domain.Categories.ValueObject;

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

            var movies = new List<MovieResult>();
            foreach(Domain.Movie.Movie movie in category.Movies)
            {
                movies.Add(new MovieResult {
                    TmdbMovieId = movie.TmdbMovieId,
                    Title = movie.Title,
                    Overview = movie.Overview,
                    PosterPath = movie.PosterPath,
                    ReleaseDate = movie.ReleaseDate
                    });
            }

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