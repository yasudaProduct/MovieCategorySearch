using Merino.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.UseCase.Categories;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySearch.Controllers
{
    [Authorize]
    public class CategoryController : MerinoController
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
            if (id == null) return RedirectToAction(nameof(HomeController.Index));

            CategoryDetailsDto dto =  _categoryService.Find(id);

            CategoryViewModel viewModel = new CategoryViewModel()
            {
                Id = dto.Id,
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };

            return View(viewModel);
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
            int id = _categoryService.Create(new CreateCategoryCommand(
                viewModel.CategoryName,
                viewModel.Description,
                int.Parse(UserId))
                );

            return RedirectToAction(nameof(Details), new { id = id });
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
