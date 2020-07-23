namespace Events.Stores.Processors.Default
{
    using System;
    using System.Collections.Generic;
    using Abstractions;
    using Buses.Abstractions;
    using Events.Abstractions;
    using Mappers.Builders.Abstractions;
    using Stores.Abstractions;

    public class DefaultEventStoreProcessor<TEvent, TAnotherEvent, TEventStore, TEventMapperBuilder, TAnotherEventBus> : IEventStoreProcessor<TEvent, TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : class, IEvent
        where TEventStore : class, IEventStore<TEvent>
        where TEventMapperBuilder : class, IEventMapperBuilder<TEvent, TAnotherEvent>
        where TAnotherEventBus : class, IEventBus<TAnotherEvent>
    {
        private readonly TEventStore _eventStore;
        private readonly TEventMapperBuilder _eventMapperBuilder;
        private readonly TAnotherEventBus _anotherEventBus;



        public DefaultEventStoreProcessor(
            TEventStore eventStore,
            TEventMapperBuilder eventMapperBuilder,
            TAnotherEventBus anotherEventBus)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _eventMapperBuilder = eventMapperBuilder ?? throw new ArgumentNullException(nameof(eventMapperBuilder));
            _anotherEventBus = anotherEventBus ?? throw new ArgumentNullException(nameof(anotherEventBus));
        }



        public void Process()
        {
            IEnumerable<TEvent> events = _eventStore.LoadAll();

            foreach (TEvent @event in events)
            {
                TAnotherEvent anotherEvent = _eventMapperBuilder.MapFrom(@event);

                if (anotherEvent != default)
                {
                    _anotherEventBus.Publish(anotherEvent);
                }
            }
        }
    }
}
