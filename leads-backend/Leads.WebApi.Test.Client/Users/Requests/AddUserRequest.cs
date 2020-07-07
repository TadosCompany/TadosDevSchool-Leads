namespace Leads.WebApi.Test.Client.Users.Requests
{
    using Data;


    public class AddUserRequest
    {
        public AddUserRequest(string email, UserRoles role)
        {
            Email = email;
            Role = role;
        }


        public string Email { get; }

        public UserRoles Role { get; }
    }
}