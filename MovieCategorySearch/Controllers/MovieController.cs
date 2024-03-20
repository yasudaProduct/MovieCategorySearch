using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySearch.Controllers
{
    /// <summary>
    /// 映画を管理するためのコントローラーです。
    /// </summary>
    [Authorize]
    public class MovieController : Controller
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
                    Id = movie.Id,
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
            var movieList = _movieQueryService.SearchMovieList(title);

            MovieListViewModel model = new MovieListViewModel();

            movieList.ForEach(movie =>
            {
                model.MovieList.Add(new MovieViewModel()
                {
                    Id = movie.Id,
                    TmdbMovieId = movie.TmdbMovieId,
                    Title = movie.Title,
                });
            });

            return View("Index", model);
        }

        /// <summary>
        /// 映画の詳細を表示します。
        /// </summary>
        /// <param name="id">映画のID。</param>
        /// <returns>映画の詳細を含むビュー。</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// 映画の作成フォームを表示します。
        /// </summary>
        /// <returns>映画の作成フォームを含むビュー。</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新しい映画を作成します。
        /// </summary>
        /// <param name="collection">映画データを含むフォームコレクション。</param>
        /// <returns>アクションの結果。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
