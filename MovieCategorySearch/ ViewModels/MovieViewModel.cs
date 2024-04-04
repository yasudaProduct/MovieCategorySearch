using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MovieCategorySearch.Models;
using System.ComponentModel;

namespace MovieCategorySearch.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        public int TmdbMovieId { get; set; }
        
        [DisplayName("タイトル")]
        [ValidateNever]
        public string Title { get; set; }

        [DisplayName("内容")]
        [ValidateNever]
        public string Overview { get; set; }

        [ValidateNever]
        public string PosterPath { get; set; }

        [ValidateNever]
        public DateTime ReleaseDate { get; set; }

        [ValidateNever]
        public Dictionary<int, string>? Category { get; set; } = new Dictionary<int, string>();

    }
}
