namespace Leads.WebApi.Test.Client.Users.Requests
{
    using Data;


    public class EditUserRequest
    {
        public EditUserRequest(long id, string email, UserRoles role)
        {
            Id = id;
            Email = email;
            Role = role;
        }


        public long Id { get; }

        public string Email { get; }

        public UserRoles Role { get; }
    }
}