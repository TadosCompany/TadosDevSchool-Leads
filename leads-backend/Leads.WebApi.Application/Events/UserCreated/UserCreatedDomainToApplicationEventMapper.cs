namespace Leads.WebApi.Application.Events.UserCreated
{
    using System;
    using Domain.Users.Events;
    using global::Application.Events.Abstractions;
    using global::Application.Events.Mappers.Base;

    public class UserCreatedDomainToApplicationEventMapper : DomainToApplicationEventMapperBase<UserCreatedDomainEvent>
    {
        protected override IApplicationEvent MapFrom(UserCreatedDomainEvent @event)
        {
            if (@event == null) 
                throw new ArgumentNullException(nameof(@event));

            return new UserCreatedApplicationEvent(@event.Email, @event.Password);
        }
    }
}
