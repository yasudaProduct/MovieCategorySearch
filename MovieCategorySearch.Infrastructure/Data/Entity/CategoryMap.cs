using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Merino.Infrastructure.Entity;

namespace MovieCategorySearch.Infrastructure.Data.Entity
{
    [Description("カテゴリマップ")]
    [Table("category_map")]
    public class CategoryMap : BaseEntity
    {
        [Description("カテゴリマップID")]
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Description("映画ID")]
        [Column("movie_id")]
        [Required]
        public int MovieId { get; set; }

        [Description("カテゴリID")]
        [Column("category_id")]
        [Required]
        public int CategoryId { get; set; }

        [Description("削除フラグ")]
        [Column("deleted_flg")]
        [Required]
        [DefaultValue("0")]
        [MaxLength(1)]
        public string? DeletedFlg { get; set; }

        public Movie Movie { get; set; }

        public Category Category { get; set; }

    }
}
