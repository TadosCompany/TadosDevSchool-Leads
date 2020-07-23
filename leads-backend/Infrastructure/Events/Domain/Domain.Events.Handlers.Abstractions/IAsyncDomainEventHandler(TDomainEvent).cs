namespace Domain.Events.Handlers.Abstractions
{
    using Events.Abstractions;
    using global::Events.Handlers.Abstractions;

    public interface IAsyncDomainEventHandler<in TDomainEvent> : IAsyncEventHandler<IDomainEvent, TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
    }
}
