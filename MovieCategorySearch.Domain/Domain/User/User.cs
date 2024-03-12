namespace MovieCategorySearch.Application.Domain.User
{
    public class User
    {
        public User(int userId, string mailAddress, string userCls){
            UserId = userId;
            MailAddress = mailAddress;
            UserCls = userCls;
        }

        public int UserId { get; }

        public string MailAddress { get; }

        public string UserCls { get; }

    }
}
