namespace MovieCategorySearch.Domain.Auth
{

    public interface IAuthDomainService
    {
        bool Login(string mailAddress, string password);
    }

    public class AuthDomainService :IAuthDomainService
    {
        public bool Login(string mailAddress, string password)
        {
            return true;
        }
    }
}
