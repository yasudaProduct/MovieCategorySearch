using System;

namespace MovieCategorySearch.Domain.Auth
{

    internal interface IAuthDomain
    {
        bool Login(string mailAddress, string password);
    }

    public class AuthDomain :IAuthDomain
    {
        public bool Login(string mailAddress, string password)
        {
            
            
            return true;
        }
    }
}
