using MovieCategorySearch.Domain.User;
using MovieCategorySearch.Domain.User.ValueObject;
using MovieCategorySearch.Infrastructure.Data;

namespace MovieCategorySearch.Infrastructure.Users
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
            var user = _dbContext.User.FirstOrDefault(x => x.EmailAdress == mailAddress);

            if (user == null) return null;

            return new User(user.UserId, user.Name, new EmailAddress(user.EmailAdress), (UserCls)int.Parse(user.UserCls));
        }

        public void Save(User user)
        {
            Data.Entity.User userEntity = new Data.Entity.User
            {
                UserId = user.UserId,
                Name = user.Name,
                EmailAdress = user.EmailAddress.Value,
                UserCls = user.UserCls.GetHashCode().ToString(),
                DeletedFlg = "0"
            };

            _dbContext.User.Add(userEntity);
            _dbContext.SaveChanges();

        }
    }
}
