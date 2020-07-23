namespace Application.Events.Mappers.Default
{
    using Abstractions;
    using Domain.Events.Abstractions;
    using Domain.Events.Mappers.Default;
    using Events.Abstractions;

    public class DefaultDomainToApplicationEventMapper<TConcreteEvent> : DefaultDomainEventMapper<TConcreteEvent, IApplicationEvent>, IDomainToApplicationEventMapper<TConcreteEvent>
        where TConcreteEvent : IDomainEvent
    {
    }
}
