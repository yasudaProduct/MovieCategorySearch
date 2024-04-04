using MovieCategorySearch.Models;
using System.ComponentModel;

namespace MovieCategorySearch.ViewModels
{
    internal class MovieDetailsViewModel : BaseViewModel
    {
        internal MovieViewModel Movie { get; set; }

        [DisplayName("ジャンル")]
        public string[] Genres { get; set; }

        [DisplayName("公開日")]
        public DateTime ReleaseDate { get; set; }

        public CreateCategoryModel CreateCategoryModel { get; set; }

        public IEnumerable<CategoryModel> CategoryModelList { get; set; } = new List<CategoryModel>();
    }
}
