namespace Events.Raisers.Default
{
    using System;
    using Abstractions;
    using Dispatchers.Abstractions;
    using Events.Abstractions;
    using Stores.Abstractions;

    public class DefaultEventRaiser<TEvent, TEventStore, TEventDispatcher> : IEventRaiser<TEvent>
        where TEvent : IEvent
        where TEventStore : IEventStore<TEvent>
        where TEventDispatcher : IEventDispatcher<TEvent>
    {
        private readonly TEventStore _eventStore;
        private readonly TEventDispatcher _eventDispatcher;



        public DefaultEventRaiser(TEventStore eventStore, TEventDispatcher eventDispatcher)
        {
            if (eventStore == null)
                throw new ArgumentNullException(nameof(eventStore));

            if (eventDispatcher == null)
                throw new ArgumentNullException(nameof(eventDispatcher));

            _eventStore = eventStore;
            _eventDispatcher = eventDispatcher;
        }



        public void Raise<TConcreteEvent>(TConcreteEvent @event) 
            where TConcreteEvent : TEvent
        {
            _eventStore.Save(@event);

            _eventDispatcher.Dispatch(@event);
        }
    }
}
