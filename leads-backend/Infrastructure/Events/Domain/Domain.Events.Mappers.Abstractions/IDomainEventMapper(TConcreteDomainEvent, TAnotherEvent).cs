namespace Domain.Events.Mappers.Abstractions
{
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Mappers.Abstractions;

    public interface IDomainEventMapper<in TConcreteDomainEvent, out TAnotherEvent> : IEventMapper<TConcreteDomainEvent, IDomainEvent, TAnotherEvent>, IWeaklyTypedDomainEventMapper<TAnotherEvent>
        where TConcreteDomainEvent : IDomainEvent
        where TAnotherEvent : IEvent
    {
    }
}
