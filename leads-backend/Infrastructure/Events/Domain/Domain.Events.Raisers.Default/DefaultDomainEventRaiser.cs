namespace Domain.Events.Raisers.Default
{
    using Abstractions;
    using Dispatchers.Abstractions;
    using Events.Abstractions;
    using global::Events.Raisers.Default;
    using Stores.Abstractions;

    public class DefaultDomainEventRaiser : DefaultEventRaiser<IDomainEvent, IDomainEventStore, IDomainEventDispatcher>, IDomainEventRaiser
    {
        public DefaultDomainEventRaiser(IDomainEventStore eventStore, IDomainEventDispatcher eventDispatcher) 
            : base(eventStore, eventDispatcher)
        {
        }
    }
}
