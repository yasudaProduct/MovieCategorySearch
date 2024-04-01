using MovieCategorySearch.Domain.User.ValueObject;

namespace MovieCategorySearch.Domain.User
{
    public class User
    {
        public User(int userId, string name, EmailAddress mailAddress, UserCls userCls){
            UserId = userId;
            Name = name;
            EmailAddress = mailAddress;
            UserCls = userCls;
        }

        public int UserId { get; }

        public string Name { get; }

        public EmailAddress EmailAddress { get; }

        public UserCls UserCls { get; }

    }
}
