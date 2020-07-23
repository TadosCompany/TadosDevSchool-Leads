namespace Domain.Events.Raisers.Default
{
    using Abstractions;
    using Dispatchers.Abstractions;
    using Events.Abstractions;
    using global::Events.Raisers.Default;
    using Stores.Abstractions;

    public class DefaultAsyncDomainEventRaiser : DefaultAsyncEventRaiser<IDomainEvent, IAsyncDomainEventStore, IAsyncDomainEventDispatcher>, IAsyncDomainEventRaiser
    {
        public DefaultAsyncDomainEventRaiser(IAsyncDomainEventStore eventStore, IAsyncDomainEventDispatcher eventDispatcher) 
            : base(eventStore, eventDispatcher)
        {
        }
    }
}
