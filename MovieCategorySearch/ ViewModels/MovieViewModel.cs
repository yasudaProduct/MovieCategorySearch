using System.ComponentModel;

namespace MovieCategorySearch.ViewModels
{
    public class MovieViewModel
    {
        public int? Id { get; set; }

        public int TmdbMovieId { get; set; }
        
        [DisplayName("タイトル")]
        public string Title { get; set; }

        [DisplayName("内容")]
        public string Overview { get; set; }

    }
}
