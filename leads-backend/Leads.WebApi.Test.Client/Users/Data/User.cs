namespace Leads.WebApi.Test.Client.Users.Data
{
    public class User
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public UserRoles Role { get; set; }

        public bool IsDeleted { get; set; }
    }
}