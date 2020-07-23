namespace Leads.WebApi.Application.Events.UserCreated
{
    using System;
    using Domain.Users.Objects.Entities;
    using global::Application.Events.Abstractions;

    public class UserCreatedApplicationEvent : IApplicationEvent
    {
        public UserCreatedApplicationEvent(User user)
        {
            if (user == null) 
                throw new ArgumentNullException(nameof(user));

            Email = user.Email;
        }



        public string Email { get; }
    }
}
