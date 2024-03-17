using System;

namespace MovieCategorySearch.Application.Domain.Auth
{

    internal interface IAuthDomainService
    {
        bool Login(string mailAddress, string password);
    }

    internal class AuthDomainService :IAuthDomainService
    {
        public bool Login(string mailAddress, string password)
        {
            return true;
        }
    }
}
