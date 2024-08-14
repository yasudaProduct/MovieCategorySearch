using MovieCategorySearch.Application.UseCase.Auth.Dto;
using MovieCategorySearch.Application.Auth.Dto;
using MovieCategorySearch.Application.Auth;
using Merino.Logging;
using MovieCategorySearch.Domain.User;

namespace MovieCategorySearch.Application.UseCase.Auth
{

    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRpository;

        private readonly IUserFactory _userFactory;

        public AuthService(
            IUserRepository userRpository,
            IUserFactory userFactory
        )
        {
            _userRpository = userRpository;
            _userFactory = userFactory;
        }

        public bool Auth(AuthRequest req)
        {
            MerinoLogger.Trace("AuthService Auth");

            //new EmailAddress(req.emailaddres)　//ValuesObject作成

            //TODO 認証 ここからFirebaseへ
            User user = _userRpository.Find(req.LoginId);

            if (user == null) return false;

            return true;
        }

        public bool SignUp(SignUpRequest req)
        {
            // UserFactoryを使ってUserモデルを作成
            User user = _userFactory.CreateUser(req.Name, req.Password, req.Name, req.Email);

            _userRpository.Save(user);

            return true;
        }
    }
}