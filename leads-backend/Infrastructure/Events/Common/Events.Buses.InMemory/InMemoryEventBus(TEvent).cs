namespace Events.Buses.InMemory
{
    using System;
    using Abstractions;
    using Events.Abstractions;

    public class InMemoryEventBus<TEvent> : IEventBus<TEvent>
        where TEvent : IEvent
    {
        private readonly InMemoryEventsSubscriptions<TEvent> _eventsSubscriptions = new InMemoryEventsSubscriptions<TEvent>();
        private readonly InMemoryEventSubscriptionTokensMap<TEvent> _eventSubscriptionTokens = new InMemoryEventSubscriptionTokensMap<TEvent>();



        public IEventSubscriptionToken Subscribe<TConcreteEvent>(Action<TConcreteEvent> action) 
            where TConcreteEvent : class, TEvent
        {
            InMemoryEventSubscription<TEvent> subscription = InMemoryEventSubscription<TEvent>.Create(action);

            _eventsSubscriptions.AddOrUpdate(
                typeof(TConcreteEvent),
                _ =>
                {
                    var eventSubscriptions = new InMemoryEventSubscriptions<TEvent>();

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

            return subscription.Token;
        }

        public void Unsubscribe(IEventSubscriptionToken eventSubscriptionToken)
        {
            _eventSubscriptionTokens[eventSubscriptionToken].TryRemove(eventSubscriptionToken, out _);
        }

        public void Publish<TConcreteEvent>(TConcreteEvent @event) 
            where TConcreteEvent : TEvent
        {
            foreach (InMemoryEventSubscription<TEvent> eventSubscription in _eventsSubscriptions[@event.GetType()].Values)
            {
                eventSubscription.Action(@event);
            }
        }
    }
}
