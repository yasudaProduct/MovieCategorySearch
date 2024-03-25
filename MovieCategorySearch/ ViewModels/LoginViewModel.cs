using Merino.Attribute;
using MovieCategorySearch.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCategorySearch.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("メールアドレス")]
        [MerinoRequired]
        //[EmailAddress(ErrorMessageResourceName = nameof(UIMessageResource.Validator_EmailAddressAttribute),ErrorMessageResourceType = typeof(UIMessageResource))]
        [MerinoEmailAddress(nameof(ValidateMessageResource.Validator_EmailAddressAttribute))]
        public string LoginId { get; set; }

        [DisplayName("パスワード")]
        [DataType(DataType.Password)]
        [MerinoRequired(nameof(ValidateMessageResource.MS0001))]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
