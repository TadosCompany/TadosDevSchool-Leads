namespace Domain.Events.Mappers.Factories.Abstractions
{
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Mappers.Factories.Abstractions;

    public interface IDomainEventMapperFactory<out TAnotherEvent> : IEventMapperFactory<IDomainEvent, TAnotherEvent>
        where TAnotherEvent : IEvent
    {
    }
}
