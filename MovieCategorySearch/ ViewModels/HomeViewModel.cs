using MovieCategorySearch.Models;

namespace MovieCategorySearch.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryModel>  CategoryModelList { get; set; } = new List<CategoryModel>();

        public IEnumerable<MovieViewModel> MovieList { get; set; } = new List<MovieViewModel>();
    }
}
