namespace Events.Buses.InMemory.Async
{
    using System;
    using System.Threading.Tasks;
    using Abstractions;
    using Events.Abstractions;

    public class InMemoryAsyncEventBus<TEvent> : IAsyncEventBus<TEvent>
        where TEvent : IEvent
    {
        private readonly InMemoryAsyncEventsSubscriptions<TEvent> _eventsSubscriptions = new InMemoryAsyncEventsSubscriptions<TEvent>();
        private readonly InMemoryAsyncEventSubscriptionTokensMap<TEvent> _eventSubscriptionTokens = new InMemoryAsyncEventSubscriptionTokensMap<TEvent>();



        public Task<IEventSubscriptionToken> SubscribeAsync<TConcreteEvent>(Func<TConcreteEvent, Task> action) 
            where TConcreteEvent : class, TEvent
        {
            InMemoryAsyncEventSubscription<TEvent> subscription = InMemoryAsyncEventSubscription<TEvent>.Create(action);

            _eventsSubscriptions.AddOrUpdate(
                typeof(TConcreteEvent),
                _ =>
                {
                    var eventSubscriptions = new InMemoryAsyncEventSubscriptions<TEvent>();

                    eventSubscriptions.TryAdd(subscription.Token, subscription);


                    _eventSubscriptionTokens.TryAdd(subscription.Token, eventSubscriptions);


                    return eventSubscriptions;
                },
                (_, eventSubscriptions) =>
                {
                    eventSubscriptions.TryAdd(subscription.Token, subscription);


                    _eventSubscriptionTokens.TryAdd(subscription.Token, eventSubscriptions);


                    return eventSubscriptions;
                });

            return Task.FromResult(subscription.Token);
        }

        public Task UnsubscribeAsync(IEventSubscriptionToken eventSubscriptionToken)
        {
            _eventSubscriptionTokens[eventSubscriptionToken].TryRemove(eventSubscriptionToken, out _);

            return Task.CompletedTask;
        }

        public async Task PublishAsync<TConcreteEvent>(TConcreteEvent @event) 
            where TConcreteEvent : TEvent
        {
            foreach (InMemoryAsyncEventSubscription<TEvent> eventSubscription in _eventsSubscriptions[@event.GetType()].Values)
            {
                await eventSubscription.Action(@event);
            }
        }
    }
}
