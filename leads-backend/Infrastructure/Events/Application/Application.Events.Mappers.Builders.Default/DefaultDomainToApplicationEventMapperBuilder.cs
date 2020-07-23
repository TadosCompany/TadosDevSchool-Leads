namespace Application.Events.Mappers.Builders.Default
{
    using Abstractions;
    using Domain.Events.Mappers.Builders.Default;
    using Events.Abstractions;
    using Factories.Abstractions;

    public class DefaultDomainToApplicationEventMapperBuilder : DefaultDomainEventMapperBuilder<IApplicationEvent, IDomainToApplicationEventMapperFactory>, IDomainToApplicationEventMapperBuilder
    {
        public DefaultDomainToApplicationEventMapperBuilder(IDomainToApplicationEventMapperFactory domainToApplicationEventMapperFactory)
            : base(domainToApplicationEventMapperFactory)
        {
        }
    }
}
