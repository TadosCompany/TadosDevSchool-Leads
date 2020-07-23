namespace Events.Handlers.Abstractions
{
    using Events.Abstractions;

    public interface IEventHandler<TEvent, in TConcreteEvent>
        where TEvent : IEvent
        where TConcreteEvent : TEvent
    {
        void Handle(TConcreteEvent @event);
    }
}
