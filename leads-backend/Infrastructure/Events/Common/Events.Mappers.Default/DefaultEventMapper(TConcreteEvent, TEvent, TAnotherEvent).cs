namespace Events.Mappers.Default
{
    using Base;
    using Events.Abstractions;

    public class DefaultEventMapper<TConcreteEvent, TEvent, TAnotherEvent> : EventMapperBase<TConcreteEvent, TEvent, TAnotherEvent>
        where TConcreteEvent : TEvent
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
        protected override TAnotherEvent MapFrom(TConcreteEvent @event) => default;
    }
}
