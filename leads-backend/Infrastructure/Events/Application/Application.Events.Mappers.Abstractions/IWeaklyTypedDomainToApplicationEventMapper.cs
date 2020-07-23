namespace Application.Events.Mappers.Abstractions
{
    using Domain.Events.Mappers.Abstractions;
    using Events.Abstractions;

    public interface IWeaklyTypedDomainToApplicationEventMapper : IWeaklyTypedDomainEventMapper<IApplicationEvent>
    {
    }
}
