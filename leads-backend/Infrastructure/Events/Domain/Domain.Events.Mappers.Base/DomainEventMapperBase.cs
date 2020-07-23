namespace Domain.Events.Mappers.Base
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Mappers.Base;

    public abstract class DomainEventMapperBase<TConcreteEvent, TAnotherEvent> : EventMapperBase<TConcreteEvent, IDomainEvent, TAnotherEvent>, IWeaklyTypedDomainEventMapper<TAnotherEvent>
        where TConcreteEvent : IDomainEvent
        where TAnotherEvent : IEvent
    {
    }
}