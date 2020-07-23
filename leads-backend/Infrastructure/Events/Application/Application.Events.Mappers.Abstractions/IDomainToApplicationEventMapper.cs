namespace Application.Events.Mappers.Abstractions
{
    using Domain.Events.Abstractions;
    using Domain.Events.Mappers.Abstractions;
    using Events.Abstractions;

    public interface IDomainToApplicationEventMapper<in TConcreteDomainEvent> : IDomainEventMapper<TConcreteDomainEvent, IApplicationEvent>, IWeaklyTypedDomainToApplicationEventMapper
        where TConcreteDomainEvent : IDomainEvent
    {
    }
}
