namespace Events.Buses.InMemory
{
    using System.Collections.Concurrent;
    using Abstractions;
    using Events.Abstractions;

    internal class InMemoryEventSubscriptions<TEvent> : ConcurrentDictionary<IEventSubscriptionToken, InMemoryEventSubscription<TEvent>>
        where TEvent : IEvent
    {
    }
}
