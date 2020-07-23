namespace Events.Buses.InMemory.Sync
{
    using System.Collections.Concurrent;
    using Abstractions;
    using Events.Abstractions;

    internal class InMemoryEventSubscriptionTokensMap<TEvent> : ConcurrentDictionary<IEventSubscriptionToken, InMemoryEventSubscriptions<TEvent>>
        where TEvent : IEvent
    {
    }
}
