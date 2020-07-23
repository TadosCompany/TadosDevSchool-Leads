namespace Domain.Events.Mappers.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Abstractions;
    using global::Events.Mappers.Default;

    public class DefaultDomainEventMapper<TConcreteEvent, TAnotherEvent> : DefaultEventMapper<TConcreteEvent, IDomainEvent, TAnotherEvent>, IDomainEventMapper<TConcreteEvent, TAnotherEvent>
        where TConcreteEvent : IDomainEvent
        where TAnotherEvent : IEvent
    {
    }
}
