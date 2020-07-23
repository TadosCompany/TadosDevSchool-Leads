namespace Events.Stores.Abstractions
{
    using System.Collections.Generic;
    using Events.Abstractions;

    public interface IEventStore<TEvent>
        where TEvent : IEvent
    {
        void Save<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;

        IEnumerable<TEvent> LoadAll();
    }
}
