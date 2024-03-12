namespace MovieCategorySearch.Application.Domain.User
{
    public interface IUserRepository
    {
        public User Find(string mailAddress);
    }
}
