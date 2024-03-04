
using Merino.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}

