using Merino.Attribute;
using MovieCategorySearch.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCategorySearch.ViewModels
{
    public class SignUpViewModel
    {
        [DisplayName("ユーザー名")]
        [MerinoRequired]
        [StringLength(10)]
        public string Name { get; set; }

        [DisplayName("メールアドレス")]
        [MerinoRequired]
        [MerinoEmailAddress(nameof(ValidateMessageResource.Validator_EmailAddressAttribute))]
        public string LoginId { get; set; }

        [DisplayName("パスワード")]
        [DataType(DataType.Password)]
        [MerinoRequired(nameof(ValidateMessageResource.MS0001))]
        public string Password { get; set; }

        [DisplayName("パスワード(確認用)")]
        [DataType(DataType.Password)]
        [MerinoRequired(nameof(ValidateMessageResource.MS0001))]
        public string CheckPassword { get; set; }
    }
}
