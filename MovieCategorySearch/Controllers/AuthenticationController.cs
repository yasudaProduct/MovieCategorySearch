
using Merino.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCategorySearch.ViewModels;
using MovieCategorySearch.Application.UseCase.Auth;
using MovieCategorySearch.Application.UseCase.Auth.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MovieCategorySearch.Application.Auth.Dto;

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
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        internal IActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // ユーザー登録Service呼び出し
            _authService.SignUp(new SignUpRequest
            {
                LoginId = model.LoginId,
                Password = model.Password,
                Name = model.Name,
                Email = model.LoginId
            });

            return RedirectToAction(nameof(this.Login), "Authentication", new { ReturnUrl = model.ReturnUrl });
        }

        [HttpGet]
        public IActionResult Login(string? ReturnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = ReturnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //入力チェック
            if (!ModelState.IsValid) return View(model);

            //認証
            var res = _authService.Auth(new AuthRequest(model.LoginId, model.Password));
            if (!res)
            {
                ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
                return View();
            }

            //ユーザー取得

            //認証Cookie作成
            //base.AddCookie<AppCookieDto>(new AppCookieDto() 
            //    { 
            //        Id = 1,
            //        Name = "めりの",
            //    });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.LoginId),
                new Claim("UserId", "1"),
                new Claim(ClaimTypes.Role, "Administrator"),
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

            
            return String.IsNullOrEmpty(model.ReturnUrl) ? RedirectToAction(nameof(MovieController.Index),"Movie") : Redirect(model.ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

