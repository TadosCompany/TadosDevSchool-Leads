namespace Application.Events.Mappers.Base
{
    using Abstractions;
    using Domain.Events.Abstractions;
    using Domain.Events.Mappers.Base;
    using Events.Abstractions;

    public abstract class DomainToApplicationEventMapperBase<TConcreteEvent> : DomainEventMapperBase<TConcreteEvent, IApplicationEvent>, IDomainToApplicationEventMapper<TConcreteEvent>
        where TConcreteEvent : IDomainEvent
    {
    }
}
