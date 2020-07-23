namespace Events.Raisers.Abstractions
{
    using Events.Abstractions;

    public interface IEventRaiser<in TEvent>
        where TEvent : IEvent
    {
        void Raise<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;
    }
}
