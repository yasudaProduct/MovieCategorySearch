using Microsoft.AspNetCore.Mvc;

namespace MovieCategorySearch.Models
{
    public class BaseViewModel
    {
        [ViewData]
        public string Messenge { get; set; } = "基底モデルからのメッセージです。";
    }
}