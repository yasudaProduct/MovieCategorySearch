using System.ComponentModel;

namespace MovieCategorySearch.ViewModels
{
    public class MovieDetailsViewModel
    {
        public MovieViewModel Movie { get; set; }

        [DisplayName("ジャンル")]
        public string[] Genres { get; set; }

        [DisplayName("公開日")]
        public DateTime ReleaseDate { get; set; }
    }
}
