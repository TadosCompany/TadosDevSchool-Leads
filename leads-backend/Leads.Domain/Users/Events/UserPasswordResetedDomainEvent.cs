namespace Leads.Domain.Users.Events
{
    using global::Domain.Events.Abstractions;

    public class UserPasswordResetedDomainEvent : IDomainEvent
    {
        public UserPasswordResetedDomainEvent(string email, string password)
        {
            Email = email;
            Password = password;
        }



        public string Email { get; }

        public string Password { get; }
    }
}
