using MovieCategorySearch.Domain.User;

namespace MovieCategorySearch.UseCase.Interface
{
    public interface IUserRepository
    {
        public User Find(string mailAddress);
    }
}
