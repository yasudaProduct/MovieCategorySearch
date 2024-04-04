using MovieCategorySearch.Models;

namespace MovieCategorySearch.ViewModels
{
    public class CreateCategoryViewModel: BaseViewModel
    {

        public MovieViewModel Movie { get; set; }

        public CreateCategoryModel CreateCategoryModel { get; set; }

    }
}
