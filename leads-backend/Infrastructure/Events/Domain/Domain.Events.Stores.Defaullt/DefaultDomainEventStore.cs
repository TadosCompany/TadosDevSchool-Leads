namespace Domain.Events.Stores.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Stores.Default;

    public class DefaultDomainEventStore : DefaultEventStore<IDomainEvent>, IDomainEventStore
    {
    }
}
