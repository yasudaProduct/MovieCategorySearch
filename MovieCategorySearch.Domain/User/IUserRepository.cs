namespace MovieCategorySearch.Domain.User
{
    public interface IUserRepository
    {
        public User Find(string mailAddress);

        public void Save(User user);
    }
}
