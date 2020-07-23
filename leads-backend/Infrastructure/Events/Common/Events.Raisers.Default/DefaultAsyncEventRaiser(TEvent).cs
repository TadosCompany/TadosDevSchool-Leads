namespace Events.Raisers.Default
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Dispatchers.Abstractions;
    using Events.Abstractions;
    using Stores.Abstractions;

    public class DefaultAsyncEventRaiser<TEvent, TAsyncEventStore, TAsyncEventDispatcher> : IAsyncEventRaiser<TEvent>
        where TEvent : IEvent
        where TAsyncEventStore : class, IAsyncEventStore<TEvent>
        where TAsyncEventDispatcher : class, IAsyncEventDispatcher<TEvent>
    {
        private readonly TAsyncEventStore _eventStore;
        private readonly TAsyncEventDispatcher _eventDispatcher;



        public DefaultAsyncEventRaiser(TAsyncEventStore eventStore, TAsyncEventDispatcher eventDispatcher)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
        }



        public async Task RaiseAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken = default) 
            where TConcreteEvent : TEvent
        {
            await _eventStore.SaveAsync(@event, cancellationToken);

            await _eventDispatcher.DispatchAsync(@event, cancellationToken);
        }
    }
}
