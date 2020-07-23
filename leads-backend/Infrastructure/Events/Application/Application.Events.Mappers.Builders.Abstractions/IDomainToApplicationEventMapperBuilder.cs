namespace Application.Events.Mappers.Builders.Abstractions
{
    using Domain.Events.Mappers.Builders.Abstractions;
    using Events.Abstractions;

    public interface IDomainToApplicationEventMapperBuilder : IDomainEventMapperBuilder<IApplicationEvent>
    {
    }
}
