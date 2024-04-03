using System.Diagnostics;
using System.Security.Claims;
using Merino.Controller;
using Merino.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.Application.Usecase.Categories.Dto;
using MovieCategorySearch.Application.UseCase.Categories;
using MovieCategorySearch.Application.UseCase.Movie;
using MovieCategorySearch.Application.UseCase.Movie.Dto;
using MovieCategorySearch.Models;
using MovieCategorySearch.ViewModels;


namespace MovieCategorySearch.Controllers;

[AllowAnonymous]
public class HomeController : MerinoController
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICategoryService _categoryService;

    private readonly IMovieService _movieService;

    #region コンストラクタ
    public HomeController(
        ILogger<HomeController> logger,
        ICategoryService categoryService,
        IMovieService movieService
        )
    {
        _logger = logger;
        _categoryService = categoryService;
        _movieService = movieService;
    }
    #endregion  
        

    public async Task<IActionResult> Index()
    {
        List<CategoryDetailsDto> list = _categoryService.FindAll().ToList();

        List<CategoryModel> categoryModelList = new List<CategoryModel>();
        foreach (var item in list)
        {
            categoryModelList.Add(new CategoryModel()
            {
                Id= item.Id,
                CategoryName = item.CategoryName,
            });
        }

        List<MovieResult> movieResultList = await _movieService.GetMovieList();

        List<MovieViewModel> movieViewModelList = new List<MovieViewModel>();
        foreach (var item in movieResultList)
        {
            movieViewModelList.Add(new MovieViewModel()
            {
                TmdbMovieId = item.TmdbMovieId,
                Title = item.Title,
                Overview = item.Overview,
                PosterPath = item.PosterPath,
                Category = item.Category,
            });
        }

        return View(
            new HomeViewModel() {
                CategoryModelList = categoryModelList,
                MovieList = movieViewModelList 
            });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
