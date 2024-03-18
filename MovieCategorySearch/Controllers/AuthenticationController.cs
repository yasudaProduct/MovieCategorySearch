
using Merino.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.ViewModels;
using MovieCategorySearch.Application.UseCase.Auth;
using MovieCategorySearch.Application.UseCase.Auth.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MovieCategorySearch.Controllers
{

    [AllowAnonymous]
    public class AuthenticationController : MerinoController
    {
        private readonly ILogger _logger;

        private readonly IMovieService _authService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IMovieService authService
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
            if (!_authService.Auth(req))
            {
                ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
                return View();
            }

            //認証Cookie作成
            //base.AddCookie<AppCookieDto>(new AppCookieDto() 
            //    { 
            //        Id = 1,
            //        Name = "めりの",
            //    });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.LoginId),
                //new Claim("FullName", "yasuda yuta"),
                //new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaims(claims);


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    // Cookie をブラウザー セッション間で永続化するか？（ブラウザを閉じてもログアウトしないかどうか）
                    IsPersistent = false,
                    //ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                });

            return RedirectToAction(nameof(MovieController.Index),"Movie");
        }

        //[HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

