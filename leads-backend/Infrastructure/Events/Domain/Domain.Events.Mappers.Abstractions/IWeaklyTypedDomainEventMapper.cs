namespace Domain.Events.Mappers.Abstractions
{
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Mappers.Abstractions;

    public interface IWeaklyTypedDomainEventMapper<out TAnotherEvent> : IWeaklyTypedEventMapper<IDomainEvent, TAnotherEvent>
        where TAnotherEvent : IEvent
    {
    }
}
