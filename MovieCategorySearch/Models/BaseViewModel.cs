using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieCategorySearch.Models
{
    public class BaseViewModel : PageModel
    {
        public string Messenge { get; set; } = "基底モデルからのメッセージです。";

        public string PageScript { get; set; }

        public string GetViewIdentifier()
        {
            return this.GetType().ToString();
        }
    }
}