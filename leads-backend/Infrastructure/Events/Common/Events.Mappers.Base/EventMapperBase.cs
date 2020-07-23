namespace Events.Mappers.Base
{
    using Abstractions;
    using Events.Abstractions;

    public abstract class EventMapperBase<TConcreteEvent, TEvent, TAnotherEvent> : IEventMapper<TConcreteEvent, TEvent, TAnotherEvent>
        where TConcreteEvent : TEvent
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
        protected abstract TAnotherEvent MapFrom(TConcreteEvent @event);



        TAnotherEvent IWeaklyTypedEventMapper<TEvent, TAnotherEvent>.MapFrom(TEvent @event)
            => MapFrom((TConcreteEvent)@event);
    }
}