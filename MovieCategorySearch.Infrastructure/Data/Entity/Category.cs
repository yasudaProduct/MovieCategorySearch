using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Merino.Entity;

namespace MovieCategorySearch.Infrastructure.Data.Entity
{
    [Description("カテゴリ")]
    [Table("category")]
    public class Category : BaseEntity
    {
        [Description("カテゴリID")]
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Description("カテゴリ名")]
        [Column("name")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Description("説明")]
        [Column("description")]
        [MaxLength(100)]
        public string? Description { get; set; }

        [Description("作成者ID")]
        [Column("create_user_id")]
        [Required]
        public int CreateUserId { get; set; }

        [Description("削除フラグ")]
        [Column("deleted_flg")]
        [Required]
        [DefaultValue("0")]
        [MaxLength(1)]
        public string? DeletedFlg { get; set; }

        public ICollection<CategoryMap> CategoryMaps { get; set; }

        public User User { get; set; }

    }
}
