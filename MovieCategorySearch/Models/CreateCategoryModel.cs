using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieCategorySearch.Models
{
    public class CreateCategoryModel
    {

        [DisplayName("カテゴリ名")]
        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [DisplayName("説明")]
        [StringLength(100)]
        public string? Description { get; set; }
    }
}
