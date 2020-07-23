namespace Domain.Events.Mappers.Builders.Abstractions
{
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Mappers.Builders.Abstractions;

    public interface IDomainEventMapperBuilder<out TAnotherEvent> : IEventMapperBuilder<IDomainEvent, TAnotherEvent>
        where TAnotherEvent : IEvent
    {
    }
}
