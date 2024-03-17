using MovieCategorySearch.Application.Domain.User;
using MovieCategorySearch.Application.UseCase.Auth.Dto;

namespace MovieCategorySearch.Application.UseCase.Auth
{

    public class AuthService : IMovieService
    {
        //private readonly ILogger _logger;

        private readonly IUserRepository _userRpository;

        public AuthService(
            //ILogger<AuthService> logger
            IUserRepository userRpository
        )
        {
            //_logger = logger;
            _userRpository = userRpository;
        }

        public bool Auth(AuthRequest req)
        {
            //_logger.LogInformation("Auth");

            //new EmailAddress(req.emailaddres)Å@//ValuesObjectçÏê¨

            //TODO îFèÿ Ç±Ç±Ç©ÇÁFirebaseÇ÷
            User user = _userRpository.Find(req.LoginId);

            if (user == null) return false;

            return true;
        }
    }
}