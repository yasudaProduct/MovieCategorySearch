using MovieCategorySearch.Application.Auth;
using MovieCategorySearch.Domain.User;
using MovieCategorySearch.Domain.User.ValueObject;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Users
{
    public class InMemoryUserFactory : IUserFactory
    {

        private readonly PostgresDbContext _dbContext;

        public InMemoryUserFactory
            (
            PostgresDbContext dbContext
            )
        {
            _dbContext = dbContext;
        }

        public User CreateUser(string loginId, string password, string name, string email)
        {
            // UserId採番
            int newUserId = _dbContext.User.OrderByDescending(x => x.UserId).FirstOrDefault().UserId + 1;

            return new User(newUserId, name, new EmailAddress(email), UserCls.Normal);
        }
    }
}
