using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieCategorySearch.ViewModels
{
    public class CategoryViewModel
    {

        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("カテゴリ名")]
        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [DisplayName("説明")]
        [StringLength(100)]
        public string? Description { get; set; }

        public List<MovieViewModel> MovieList { get; set; } = new List<MovieViewModel>();
    }
}
