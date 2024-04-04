using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieCategorySearch.Models
{
    public class BaseViewModel
    {
        [ValidateNever]
        public string Messenge { get; set; } = "基底モデルからのメッセージです。";

        [ValidateNever]
        public string PageScript { get; set; }

        public string GetViewIdentifier()
        {
            return this.GetType().ToString();
        }
    }
}