namespace Events.Mappers.Abstractions
{
    using Events.Abstractions;

    public interface IEventMapper<in TConcreteEvent, in TEvent, out TAnotherEvent> : IWeaklyTypedEventMapper<TEvent, TAnotherEvent>
        where TConcreteEvent : TEvent
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
    }
}
