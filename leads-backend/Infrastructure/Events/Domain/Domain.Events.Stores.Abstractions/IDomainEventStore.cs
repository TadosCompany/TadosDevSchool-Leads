namespace Domain.Events.Stores.Abstractions
{
    using Events.Abstractions;
    using global::Events.Stores.Abstractions;

    public interface IDomainEventStore : IEventStore<IDomainEvent>
    {
    }
}
