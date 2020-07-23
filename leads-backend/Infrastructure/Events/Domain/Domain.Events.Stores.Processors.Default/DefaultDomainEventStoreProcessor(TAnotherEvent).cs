namespace Domain.Events.Stores.Processors.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Buses.Abstractions;
    using global::Events.Stores.Processors.Default;
    using Mappers.Builders.Abstractions;
    using Stores.Abstractions;

    public class DefaultDomainEventStoreProcessor<TAnotherEvent, TDomainEventMapperBuilder, TAnotherEventBus> : DefaultEventStoreProcessor<IDomainEvent, TAnotherEvent, IDomainEventStore, TDomainEventMapperBuilder, TAnotherEventBus>, IDomainEventStoreProcessor<TAnotherEvent>
        where TAnotherEvent : class, IEvent
        where TDomainEventMapperBuilder : class, IDomainEventMapperBuilder<TAnotherEvent>
        where TAnotherEventBus : class, IEventBus<TAnotherEvent>
    {
        public DefaultDomainEventStoreProcessor(
            IDomainEventStore domainEventStore,
            TDomainEventMapperBuilder domainEventMapperBuilder,
            TAnotherEventBus anotherEventBus)
            : base(
                domainEventStore,
                domainEventMapperBuilder,
                anotherEventBus)
        {
        }
    }
}
