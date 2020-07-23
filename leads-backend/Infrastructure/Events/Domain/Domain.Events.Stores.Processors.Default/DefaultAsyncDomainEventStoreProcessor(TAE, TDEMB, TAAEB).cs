namespace Domain.Events.Stores.Processors.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Buses.Abstractions;
    using global::Events.Stores.Processors.Default;
    using Mappers.Builders.Abstractions;
    using Stores.Abstractions;

    public class DefaultAsyncDomainEventStoreProcessor<TAnotherEvent, TDomainEventMapperBuilder, TAsyncAnotherEventBus> : DefaultAsyncEventStoreProcessor<IDomainEvent, TAnotherEvent, IAsyncDomainEventStore, TDomainEventMapperBuilder, TAsyncAnotherEventBus>, IAsyncDomainEventStoreProcessor<TAnotherEvent>
        where TAnotherEvent : class, IEvent
        where TDomainEventMapperBuilder : class, IDomainEventMapperBuilder<TAnotherEvent>
        where TAsyncAnotherEventBus : class, IAsyncEventBus<TAnotherEvent>
    {
        public DefaultAsyncDomainEventStoreProcessor(
            IAsyncDomainEventStore asyncDomainEventStore, 
            TDomainEventMapperBuilder eventDomainMapperBuilder, 
            TAsyncAnotherEventBus asyncAnotherEventBus) 
            : base(
                asyncDomainEventStore,
                eventDomainMapperBuilder,
                asyncAnotherEventBus)
        {
        }
    }
}
