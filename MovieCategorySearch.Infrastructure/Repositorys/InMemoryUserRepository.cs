using MovieCategorySearch.Application.Domain.User;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Repositorys
{
    public class InMemoryUserRepository : IUserRepository
    {

        private readonly PostgresDbContext _dbContext;

        public InMemoryUserRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Find(string mailAddress)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.MailAdress == mailAddress);

            return new User(user.UserId, user.MailAdress, user.UserCls);
        }
    }
}
