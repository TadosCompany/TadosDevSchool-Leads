namespace Application.Events.Mappers.Factories.Abstractions
{
    using Domain.Events.Mappers.Factories.Abstractions;
    using Events.Abstractions;

    public interface IDomainToApplicationEventMapperFactory : IDomainEventMapperFactory<IApplicationEvent>
    {
    }
}
