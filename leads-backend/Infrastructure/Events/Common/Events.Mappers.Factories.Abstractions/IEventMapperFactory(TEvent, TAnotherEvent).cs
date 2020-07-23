namespace Events.Mappers.Factories.Abstractions
{
    using Events.Abstractions;
    using Mappers.Abstractions;

    public interface IEventMapperFactory<in TEvent, out TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
        IEventMapper<TConcreteEvent, TEvent, TAnotherEvent> CreateFor<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;
    }
}
