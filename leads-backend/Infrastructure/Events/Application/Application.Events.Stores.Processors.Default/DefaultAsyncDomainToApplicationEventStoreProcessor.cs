namespace Application.Events.Stores.Processors.Default
{
    using Abstractions;
    using Buses.Abstractions;
    using Domain.Events.Stores.Abstractions;
    using Domain.Events.Stores.Processors.Default;
    using Events.Abstractions;
    using Mappers.Builders.Abstractions;

    public class DefaultAsyncDomainToApplicationEventStoreProcessor : DefaultAsyncDomainEventStoreProcessor<IApplicationEvent, IDomainToApplicationEventMapperBuilder, IAsyncApplicationEventBus>, IAsyncDomainToApplicationEventStoreProcessor
    {
        public DefaultAsyncDomainToApplicationEventStoreProcessor(
            IAsyncDomainEventStore asyncDomainEventStore, 
            IDomainToApplicationEventMapperBuilder domainToApplicationEventMapperBuilder, 
            IAsyncApplicationEventBus asyncApplicationEventBus) 
            : base(
                asyncDomainEventStore,
                domainToApplicationEventMapperBuilder,
                asyncApplicationEventBus)
        {
        }
    }
}
