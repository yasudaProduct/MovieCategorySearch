using MovieCategorySearch.Domain.User;
using MovieCategorySearch.UseCase.Interface;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Repositorys
{
    public class UserRepository : IUserRepository
    {

        private readonly PostgresDbContext _dbContext;

        public UserRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Find(string mailAddress)
        {
            User user = _dbContext.User.FirstOrDefault(x => x.MailAdress == MailAdress);
            return new User(user.userId, user.mailAddress, user.userCls);
        }
    }
}
