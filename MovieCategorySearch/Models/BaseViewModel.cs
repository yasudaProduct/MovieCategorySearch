using Microsoft.AspNetCore.Mvc;

namespace MovieCategorySearch.Models
{
    internal class BaseViewModel
    {
        [ViewData]
        public string Messenge { get; set; } = "基底モデルからのメッセージです。";
    }
}