namespace Application.Events.Stores.Processors.Default
{
    using Abstractions;
    using Buses.Abstractions;
    using Domain.Events.Stores.Abstractions;
    using Domain.Events.Stores.Processors.Default;
    using Events.Abstractions;
    using Mappers.Builders.Abstractions;

    public class DefaultDomainToApplicationEventStoreProcessor : DefaultDomainEventStoreProcessor<IApplicationEvent, IDomainToApplicationEventMapperBuilder, IApplicationEventBus>, IDomainToApplicationEventStoreProcessor
    {
        public DefaultDomainToApplicationEventStoreProcessor(
            IDomainEventStore domainEventStore, 
            IDomainToApplicationEventMapperBuilder domainToApplicationEventMapperBuilder, 
            IApplicationEventBus applicationEventBus) 
            : base(
                domainEventStore,
                domainToApplicationEventMapperBuilder,
                applicationEventBus)
        {
        }
    }
}
