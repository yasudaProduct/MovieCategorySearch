using Microsoft.Extensions.Logging;
using MovieCategorySearch.UseCase.Auth.Dto;

namespace MovieCategorySearch.UseCase.Auth
{

    public class AuthService : IAuthService
    {
        private readonly ILogger _logger;

        public AuthService(
            ILogger<AuthService> logger
        )
        {
            _logger = logger;
        }

        public bool Auth(AuthRequest req)
        {
            _logger.LogInformation("Auth");
            return true;
        }
    }
}