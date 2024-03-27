namespace MovieCategorySearch.Application.UseCase.Auth.Dto
{

    public class AuthRequest
    {

        public AuthRequest(string loginId, string password)
        {
            LoginId = loginId;
            Password = password;
        }
        
        public string LoginId { get; set; }
        public string Password { get; set; }

        
    }

}


