namespace Events.Dispatchers.Abstractions
{
    using Events.Abstractions;

    public interface IEventDispatcher<in TEvent>
        where TEvent : IEvent
    {
        void Dispatch<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;
    }
}
