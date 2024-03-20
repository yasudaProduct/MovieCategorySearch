using MovieCategorySearch.Application.UseCase.Auth.Dto;

namespace MovieCategorySearch.Application.UseCase.Auth
{
    public interface IAuthService
    {
        public bool Auth(AuthRequest req);
    }
}
