using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCategorySearch.ViewModels
{
    public class AddCategoryViewModel
    {

        public MovieViewModel Movie { get; set; }

        [DisplayName("カテゴリ名")]
        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [DisplayName("説明")]
        [StringLength(100)]
        public string? Description { get; set; }

    }
}
