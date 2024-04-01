using MovieCategorySearch.Domain.User;
using MovieCategorySearch.Domain.User.ValueObject;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Repositorys
{
    public class PostgreSqlUserRepository : IUserRepository
    {

        private readonly PostgresDbContext _dbContext;

        public PostgreSqlUserRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Find(string mailAddress)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.EmailAdress == mailAddress);

            return new User(user.UserId, user.Name, new EmailAddress(user.EmailAdress), (UserCls)int.Parse(user.UserCls));
        }
    }
}
