namespace Leads.WebApi.Application.Events.UserPasswordReseted
{
    using System;
    using Domain.Users.Events;
    using global::Application.Events.Abstractions;
    using global::Application.Events.Mappers.Base;

    public class UserPasswordResetedDomainToApplicationEventMapper : DomainToApplicationEventMapperBase<UserPasswordResetedDomainEvent>
    {
        protected override IApplicationEvent MapFrom(UserPasswordResetedDomainEvent @event)
        {
            if (@event == null) 
                throw new ArgumentNullException(nameof(@event));

            return new UserPasswordResetedApplicationEvent(@event.Email, @event.Password);
        }
    }
}
