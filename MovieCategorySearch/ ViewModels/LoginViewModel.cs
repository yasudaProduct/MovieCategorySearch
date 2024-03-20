using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCategorySearch.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("メールアドレス")]
        [Required]
        [EmailAddress]
        public string LoginId { get; set; }

        [DisplayName("パスワード")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
