namespace Leads.Domain.Users.Events
{
    using System;
    using global::Domain.Events.Abstractions;
    using Objects.Entities;

    public class UserCreatedDomainEvent : IDomainEvent
    {
        public UserCreatedDomainEvent(User user)
        {
            if (user == null) 
                throw new ArgumentNullException(nameof(user));

            User = user;
        }



        public User User { get; }
    }
}
