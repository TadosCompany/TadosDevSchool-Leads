namespace Events.Mappers.Builders.Abstractions
{
    using Events.Abstractions;

    public interface IEventMapperBuilder<in TEvent, out TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
        TAnotherEvent MapFrom<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;
    }
}
