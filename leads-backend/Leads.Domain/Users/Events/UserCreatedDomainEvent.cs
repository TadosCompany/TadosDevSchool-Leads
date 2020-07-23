﻿namespace Leads.Domain.Users.Events
{
    using Enums;
    using global::Domain.Events.Abstractions;

    public class UserCreatedDomainEvent : IDomainEvent
    {
        public UserCreatedDomainEvent(string email, string password, UserRoles role)
        {
            Email = email;
            Password = password;
            Role = role;
        }



        public string Email { get; }

        public string Password { get; }

        public UserRoles Role { get; }
    }
}
