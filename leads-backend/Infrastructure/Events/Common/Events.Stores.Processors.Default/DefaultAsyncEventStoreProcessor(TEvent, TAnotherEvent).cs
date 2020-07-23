namespace Events.Stores.Processors.Default
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Buses.Abstractions;
    using Events.Abstractions;
    using Mappers.Builders.Abstractions;
    using Stores.Abstractions;

    public class DefaultAsyncEventStoreProcessor<TEvent, TAnotherEvent, TAsyncEventStore, TEventMapperBuilder, TAsyncAnotherEventBus> : IAsyncEventStoreProcessor<TEvent, TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : class, IEvent
        where TAsyncEventStore : class, IAsyncEventStore<TEvent>
        where TEventMapperBuilder : class, IEventMapperBuilder<TEvent, TAnotherEvent>
        where TAsyncAnotherEventBus : class, IAsyncEventBus<TAnotherEvent>
    {
        private readonly TAsyncEventStore _asyncEventStore;
        private readonly TEventMapperBuilder _eventMapperBuilder;
        private readonly TAsyncAnotherEventBus _asyncAnotherEventBus;



        public DefaultAsyncEventStoreProcessor(
            TAsyncEventStore asyncEventStore,
            TEventMapperBuilder eventMapperBuilder,
            TAsyncAnotherEventBus asyncAnotherEventBus)
        {
            _asyncEventStore = asyncEventStore ?? throw new ArgumentNullException(nameof(asyncEventStore));
            _eventMapperBuilder = eventMapperBuilder ?? throw new ArgumentNullException(nameof(eventMapperBuilder));
            _asyncAnotherEventBus = asyncAnotherEventBus ?? throw new ArgumentNullException(nameof(asyncAnotherEventBus));
        }



        public async Task ProcessAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEvent> events = await _asyncEventStore.LoadAllAsync(cancellationToken);

            foreach (TEvent @event in events)
            {
                TAnotherEvent anotherEvent = _eventMapperBuilder.MapFrom(@event);

                if (anotherEvent != default)
                {
                    await _asyncAnotherEventBus.PublishAsync(anotherEvent);
                }
            }
        }
    }
}
