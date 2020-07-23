namespace Domain.Events.Stores.Processors.Abstractions
{
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Stores.Processors.Abstractions;

    public interface IAsyncDomainEventStoreProcessor<TAnotherEvent> : IAsyncEventStoreProcessor<IDomainEvent, TAnotherEvent>
        where TAnotherEvent : IEvent
    {
    }
}
