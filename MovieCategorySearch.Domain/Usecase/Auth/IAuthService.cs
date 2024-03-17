using MovieCategorySearch.Application.UseCase.Auth.Dto;

namespace MovieCategorySearch.Application.UseCase.Auth
{
    public interface IMovieService
    {
        public bool Auth(AuthRequest req);
    }
}
