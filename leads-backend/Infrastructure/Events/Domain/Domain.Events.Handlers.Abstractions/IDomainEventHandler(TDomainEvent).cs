namespace Domain.Events.Handlers.Abstractions
{
    using Events.Abstractions;
    using global::Events.Handlers.Abstractions;

    public interface IDomainEventHandler<in TDomainEvent> : IEventHandler<IDomainEvent, TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
    }
}
