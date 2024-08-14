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

            //new EmailAddress(req.emailaddres)�@//ValuesObject�쐬

            //TODO �F�� ��������Firebase��
            User user = _userRpository.Find(req.LoginId);

            if (user == null) return false;

            return true;
        }

        public bool SignUp(SignUpRequest req)
        {
            // UserFactory���g����User���f�����쐬
            User user = _userFactory.CreateUser(req.Name, req.Password, req.Name, req.Email);

            _userRpository.Save(user);

            return true;
        }
    }
}