using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.Application.Usecase.Category.Dto;
using MovieCategorySearch.Application.UseCase.Category;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySearch.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger _logger;

        private readonly ICategoryService _categoryService;
        public CategoryController(
            ILogger<CategoryController> logger,
            ICategoryService categoryService
            )
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //category serviceを呼び出す
            _categoryService.Create(new CreateCategoryCommand(
                viewModel.CategoryName,
                viewModel.Description)
                );

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
