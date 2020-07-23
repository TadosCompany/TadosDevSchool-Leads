namespace Leads.WebApi.Application.Events.UserPasswordReseted
{
    using global::Application.Events.Abstractions;

    public class UserPasswordResetedApplicationEvent : IApplicationEvent
    {
        public UserPasswordResetedApplicationEvent(string email, string password)
        {
            Email = email;
            Password = password;
        }



        public string Email { get; }

        public string Password { get; }
    }
}
