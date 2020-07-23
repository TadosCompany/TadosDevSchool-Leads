namespace Domain.Events.Stores.Processors.Abstractions
{
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Stores.Processors.Abstractions;

    public interface IDomainEventStoreProcessor<TAnotherEvent> : IEventStoreProcessor<IDomainEvent, TAnotherEvent>
        where TAnotherEvent : IEvent
    {
    }
}
