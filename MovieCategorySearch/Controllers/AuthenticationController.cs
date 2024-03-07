
using Merino.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.ViewModels;

namespace MovieCategorySearch.Controllers
{

    [AllowAnonymous]
    public class AuthenticationController : MerinoController
    {
        private readonly ILogger _logger;
        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
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
            //TODO: 認証処理を実装　UseCaseクラスへ
            // AuthRequest req = new AuthRequest(model.LoginId, model.Password);
            // AuthResponse res = _authService.Auth(req);
            // if (res == null)
            // {
            //     ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
            //     return View();
            // }

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

