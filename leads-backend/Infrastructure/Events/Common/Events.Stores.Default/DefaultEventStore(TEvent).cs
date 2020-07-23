namespace Events.Stores.Default
{
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;
    using Events.Abstractions;

    public class DefaultEventStore<TEvent> : IEventStore<TEvent>
        where TEvent : IEvent
    {
        private readonly ISet<TEvent> _events = new HashSet<TEvent>();



        public void Save<TConcreteEvent>(TConcreteEvent @event) 
            where TConcreteEvent : TEvent
        {
            _events.Add(@event);
        }

        public IEnumerable<TEvent> LoadAll()
        {
            IEnumerable<TEvent> events = _events.AsEnumerable();

            _events.Clear();

            return events;
        }
    }
}
