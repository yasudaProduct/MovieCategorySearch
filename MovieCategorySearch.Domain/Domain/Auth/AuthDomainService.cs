using System;

namespace MovieCategorySearch.Application.Domain.Auth
{

    internal interface IAuthDomainService
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
