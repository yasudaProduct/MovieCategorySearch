using MovieCategorySearch.Models;

namespace MovieCategorySearch.ViewModels
{
    internal class CreateCategoryViewModel: BaseViewModel
    {

        public MovieViewModel Movie { get; set; }

        public CreateCategoryModel CreateCategoryModel { get; set; }

    }
}
