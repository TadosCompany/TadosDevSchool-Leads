namespace Events.Buses.InMemory.Async
{
    using System.Collections.Concurrent;
    using Abstractions;
    using Events.Abstractions;

    internal class InMemoryAsyncEventSubscriptionTokensMap<TEvent> : ConcurrentDictionary<IEventSubscriptionToken, InMemoryAsyncEventSubscriptions<TEvent>>
        where TEvent : IEvent
    {
    }
}
