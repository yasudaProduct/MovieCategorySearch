using MovieCategorySearch.Models;

namespace MovieCategorySearch.ViewModels
{
    internal class MovieListViewModel : BaseViewModel
    {

        public List<MovieViewModel> MovieList { get; set; } = new List<MovieViewModel>();

    }
}
