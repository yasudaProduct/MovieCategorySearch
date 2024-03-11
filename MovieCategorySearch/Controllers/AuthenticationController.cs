
using Merino.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.ViewModels;
using MovieCategorySearch.UseCase.Auth.Dto;
using MovieCategorySearch.UseCase.Auth;

namespace MovieCategorySearch.Controllers
{

    [AllowAnonymous]
    public class AuthenticationController : MerinoController
    {
        private readonly ILogger _logger;

        private readonly IAuthService _authService;
        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IAuthService authService
            )
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //入力チェック
            if (!ModelState.IsValid) return View(model);

            //認証
            AuthRequest req = new AuthRequest(model.LoginId, model.Password);
            if (_authService.Auth(req))
            {
                ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
                return View();
            }

            //認証Cookie作成
            base.AddCookie<AppCookieDto>(new AppCookieDto() 
                { 
                    Id = 1,
                    Name = "めりの",
                });

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

