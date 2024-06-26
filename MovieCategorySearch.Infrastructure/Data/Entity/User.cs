﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Merino.Infrastructure.Entity;

namespace MovieCategorySearch.Infrastructure.Data.Entity
{
    [Description("ユーザー")]
    [Table("user")]
    public class User : BaseEntity
    {
        [Description("ユーザーID")]
        [Key]
        [Column("user_id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Description("メールアドレス")]
        [Column("mail_address")]
        [Required]
        [MaxLength(319)]
        public string EmailAdress { get; set; }

        [Description("ユーザー名")]
        [Column("name")]
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Description("ユーザー区分")]
        [Column("user_cls")]
        [Required]
        [MaxLength(1)]
        public string UserCls { get; set; }

        [Description("削除フラグ")]
        [Column("deleted_flg")]
        [Required]
        [DefaultValue("0")]
        [MaxLength(1)]
        public string? DeletedFlg { get; set; }

        public ICollection<Category> Categorys { get; set; }

    }
}
