using MovieCategorySearch.Domain.User;

namespace MovieCategorySearch.Application.Auth
{
    public interface IUserFactory
    {
        public User CreateUser(string loginId, string password, string name, string email);
    }
}
