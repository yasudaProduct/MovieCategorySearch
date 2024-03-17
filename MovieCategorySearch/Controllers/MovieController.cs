using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySearch.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly ILogger _logger;

        private readonly IMovieService _movieService;

        private readonly IMovieQueryService _movieQueryService;

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

        // GET: MoviesController
        public ActionResult Index()
        {
            var movieList = _movieService.GetMovieList();

            MovieListViewModel model = new MovieListViewModel();

            movieList.ForEach(movie =>
            {
                model.MovieList.Add(new MovieViewModel()
                {
                    Id = movie.Id,
                    Title = movie.Title
                });
            });

            return View(model);
        }

        public async Task<IActionResult> Search(string title)
        {
            var movieList = _movieQueryService.SearchMovieList(title);

            MovieListViewModel model = new MovieListViewModel();

            movieList.ForEach(movie =>
            {
                model.MovieList.Add(new MovieViewModel()
                {
                    Id = movie.Id,
                    Title = movie.Title
                });
            });

            return View("Index", model);
        }   

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
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

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoviesController/Edit/5
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

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoviesController/Delete/5
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
