using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCategorySearch.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("ユーザーID")]
        [Required]
        [RegularExpression("[0-9a-zA-Z]*", ErrorMessage = "{0}は半角英数字で入力してください。")]
        public string LoginId { get; set; }

        [DisplayName("パスワード")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
