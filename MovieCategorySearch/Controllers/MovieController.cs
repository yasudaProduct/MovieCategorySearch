using Merino.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.Application.Movie.Dto;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySearch.Controllers
{
    /// <summary>
    /// 映画を管理するためのコントローラーです。
    /// </summary>
    [Authorize]
    public class MovieController : MerinoController
    {
        private readonly ILogger _logger;

        private readonly IMovieService _movieService;

        private readonly IMovieQueryService _movieQueryService;

        /// <summary>
        /// <see cref="MovieController"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="logger">ロガー。</param>
        /// <param name="movieService">映画サービス。</param>
        /// <param name="movieQueryService">映画クエリサービス。</param>
        public MovieController(
            ILogger<MovieController> logger,
            IMovieService movieService,
            IMovieQueryService movieQueryService
            )
        {
            _logger = logger;
            _movieService = movieService;
            _movieQueryService = movieQueryService;
        }

        /// <summary>
        /// 映画の一覧を表示します。
        /// </summary>
        /// <returns>映画の一覧を含むビュー。</returns>
        public async Task<ActionResult> Index()
        {
            var movieList = await _movieService.GetMovieList();

            MovieListViewModel model = new MovieListViewModel();

            movieList.ForEach(movie =>
            {
                model.MovieList.Add(new MovieViewModel()
                {
                    TmdbMovieId = movie.TmdbMovieId,
                    Title = movie.Title,
                    Overview = movie.Overview
                });
            });

            return View(model);
        }

        /// <summary>
        /// 指定されたタイトルで映画を検索します。
        /// </summary>
        /// <param name="title">検索するタイトル。</param>
        /// <returns>検索結果を含むビュー。</returns>
        public async Task<IActionResult> Search(string title)
        {
            var movieList = await _movieService.Search(title);

            MovieListViewModel model = new MovieListViewModel();

            movieList.ForEach(movie =>
            {
                model.MovieList.Add(new MovieViewModel()
                {
                    TmdbMovieId = movie.TmdbMovieId,
                    Title = movie.Title,
                    Overview = movie.Overview
                });
            });

            return View("Index", model);
        }

        /// <summary>
        /// 映画の詳細を表示します。
        /// </summary>
        /// <param name="id">映画のID。</param>
        /// <returns>映画の詳細を含むビュー。</returns>
        public async Task<ActionResult> Details(int id)
        {
            MovieResult result =  await _movieService.GetDetails(id);

            MovieViewModel movie = new MovieViewModel()
            {
                TmdbMovieId = result.TmdbMovieId,
                Title = result.Title,
                Overview = result.Overview,
                PosterPath = result.PosterPath,
                Category = result.Category
            };

            MovieDetailsViewModel model = new MovieDetailsViewModel()
            {
                Movie = movie,
                Genres = result.Genres,
                ReleaseDate = result.ReleaseDate
            };

            return View(model);
        }

        /// <summary>
        /// 映画のカテゴリを追加する画面を表示します。
        /// </summary>
        /// <param name="id">映画のID。</param>
        /// <returns>映画の詳細を含むビュー。</returns>
        public async Task<ActionResult> AddCategory(int id)
        {
            MovieResult result = await _movieService.GetDetails(id);

            MovieViewModel movie = new MovieViewModel()
            {
                TmdbMovieId = result.TmdbMovieId,
                Title = result.Title,
                Overview = result.Overview
            };

            AddCategoryViewModel model = new AddCategoryViewModel()
            {
                Movie = movie                
            };

            return View(model);
        }

        /// <summary>
        /// 新しい映画を作成します。
        /// </summary>
        /// <param name="collection">映画データを含むフォームコレクション。</param>
        /// <returns>アクションの結果。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddCategoryViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("AddCategory",viewModel);
            }

            var request = new AddCategoryRequest {
                TmdbId = viewModel.Movie.TmdbMovieId,
                UserId = int.Parse(base.UserId),
                CategoryName = viewModel.CategoryName,
                Description = viewModel.Description
            };

            // MovieService
            var id = await _movieService.AddMovieCreate(request);

            return RedirectToAction(nameof(MovieController.Details), "Movie",new { id = viewModel.Movie.TmdbMovieId });

        }

        /// <summary>
        /// 映画の編集フォームを表示します。
        /// </summary>
        /// <param name="id">映画のID。</param>
        /// <returns>映画の編集フォームを含むビュー。</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// 映画を更新します。
        /// </summary>
        /// <param name="id">映画のID。</param>
        /// <param name="collection">更新された映画データを含むフォームコレクション。</param>
        /// <returns>アクションの結果。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// 削除確認ページを表示します。
        /// </summary>
        /// <param name="id">映画のID。</param>
        /// <returns>削除確認ページを含むビュー。</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// 映画を削除します。
        /// </summary>
        /// <param name="id">映画のID。</param>
        /// <param name="collection">フォームコレクション。</param>
        /// <returns>アクションの結果。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
