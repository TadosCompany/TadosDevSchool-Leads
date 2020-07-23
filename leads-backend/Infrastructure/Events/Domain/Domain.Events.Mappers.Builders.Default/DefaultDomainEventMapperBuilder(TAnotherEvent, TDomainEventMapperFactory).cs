namespace Domain.Events.Mappers.Builders.Default
{
    using Abstractions;
    using Events.Abstractions;
    using Factories.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Mappers.Builders.Default;

    public class DefaultDomainEventMapperBuilder<TAnotherEvent, TDomainEventMapperFactory> :  DefaultEventMapperBuilder<IDomainEvent, TAnotherEvent, TDomainEventMapperFactory>, IDomainEventMapperBuilder<TAnotherEvent>
        where TAnotherEvent : IEvent
        where TDomainEventMapperFactory : IDomainEventMapperFactory<TAnotherEvent>
    {
        public DefaultDomainEventMapperBuilder(TDomainEventMapperFactory domainEventMapperFactory)
            : base(domainEventMapperFactory)
        {
        }
    }
}
