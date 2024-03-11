using System;
using MovieCategorySearch.UseCase.Auth.Dto;

namespace MovieCategorySearch.UseCase.Auth
{
    public interface IAuthService
    {
        public bool Auth(AuthRequest req);
    }
}
