using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Merino.Entity;

namespace MovieCategorySearch.Infrastructure.Data.Entity
{
    [Description("映画")]
    [Table("movie")]
    public class Movie : BaseEntity
    {
        [Description("映画ID")]
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Description("TMDb映画ID")]
        [Column("tmdb_movie_id")]
        [Required]
        public int TmdbMovieId { get; set; }

        [Description("タイトル")]
        [Column("title")]
        [Required]
        public string Title { get; set; }

        [Description("削除フラグ")]
        [Column("deleted_flg")]
        [Required]
        [DefaultValue("0")]
        [MaxLength(1)]
        public string? DeletedFlg { get; set; }

        public ICollection<CategoryMap> CategoryMaps { get; set; }

    }
}
