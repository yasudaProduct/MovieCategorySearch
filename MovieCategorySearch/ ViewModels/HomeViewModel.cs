using MovieCategorySearch.Models;

namespace MovieCategorySearch.ViewModels
{
    internal class HomeViewModel : BaseViewModel
    {
        public IEnumerable<CategoryModel>  CategoryModelList { get; set; } = new List<CategoryModel>();

        public IEnumerable<MovieViewModel> MovieList { get; set; } = new List<MovieViewModel>();
    }
}
