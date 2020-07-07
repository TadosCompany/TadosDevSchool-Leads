namespace Leads.WebApi.Test.Client.Account.Requests
{
    public class SignInRequest
    {
        public SignInRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
        
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}