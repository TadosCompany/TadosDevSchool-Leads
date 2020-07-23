namespace Events.Mappers.Abstractions
{
    using Events.Abstractions;

    public interface IWeaklyTypedEventMapper<in TEvent, out TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
        TAnotherEvent MapFrom(TEvent @event);
    }
}
